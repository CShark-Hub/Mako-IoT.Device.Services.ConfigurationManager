using System;
using MakoIoT.Device.Services.ConfigurationManager.Events;
using MakoIoT.Device.Services.ConfigurationManager.Interface;
using MakoIoT.Device.Services.ConfigurationManager.Services;
using MakoIoT.Device.Services.Interface;
using MakoIoT.Device.Services.Mediator;
using MakoIoT.Device.Services.WiFi.AP;

namespace MakoIoT.Device.Services.ConfigurationManager
{
    public class ConfigManager : IConfigManager, IEventHandler
    {
        private readonly IOperationModeService _operationModeService;
        private readonly INetworkInterfaceManager _interfaceManager;
        private readonly IDeviceControl _device;
        private readonly IServer _apiServer;
        private readonly IConfigurationService _configurationService;
        private readonly ILog _logger;

        public ConfigManager(IOperationModeService operationModeService, INetworkInterfaceManager interfaceManager, IDeviceControl device, IServer apiServer, ILog logger, IConfigurationService configurationService)
        {
            _operationModeService = operationModeService;
            _interfaceManager = interfaceManager;
            _device = device;
            _apiServer = apiServer;
            _logger = logger;
            _configurationService = configurationService;
        }

        /// <inheritdoc />
        public void StartConfigMode()
        {
            if (_operationModeService.GetOperationMode() == OperationMode.Normal)
            {
                _operationModeService.SetOperationMode(OperationMode.ConfigurationStart);
                ProcessOperationMode(OperationMode.ConfigurationStart);
            }
        }

        /// <inheritdoc />
        public void StopConfigMode()
        {
            if (_operationModeService.GetOperationMode() == OperationMode.Configuration)
            {
                _operationModeService.SetOperationMode(OperationMode.ConfigurationExit);
                ProcessOperationMode(OperationMode.ConfigurationExit);
            }
        }

        /// <inheritdoc />
        public bool ProcessOperationMode(OperationMode mode)
        {
            _logger.Trace($"Processing state {mode}");
            switch (mode)
            {
                case OperationMode.Normal:
                    _device.SignalNormalMode();
                    return true;
                case OperationMode.ConfigurationStart:
                    _device.SignalConfigMode();
                    ProcessConfigStart();
                    break;
                case OperationMode.Configuration:
                    _device.SignalConfigMode();
                    ProcessConfig();
                    break;
                case OperationMode.ConfigurationExit:
                    _device.SignalConfigMode();
                    ProcessConfigExit();
                    break;
            }
            return false;
        }

        /// <inheritdoc />
        public void ResetToDefaults()
        {
            _configurationService.ClearAll();
            _logger.Trace("All config files cleared");
            if (_operationModeService.GetOperationMode() != OperationMode.Normal)
            {
                try
                {
                    ProcessConfigExit();
                }
                catch (Exception e)
                {
                    _logger.Trace(e, "Error exiting config mode");
                    _operationModeService.SetOperationMode(OperationMode.Normal);
                    _device.Reboot();
                }
            }
            else
            {
                _device.Reboot();
            }
        }

        private void ProcessConfigStart()
        {
            _interfaceManager.DisconnectWifi();
            _interfaceManager.DisableWiFi();
            _interfaceManager.EnableAP();

            _logger.Trace("Setting operation mode to Configuration");
            _operationModeService.SetOperationMode(OperationMode.Configuration);

            _logger.Trace("Rebooting");
            _device.Reboot();
        }

        private void ProcessConfig()
        {
            //PHASE 2

            _logger.Trace($"IsApEnabled:{_interfaceManager.IsApEnabled}, IsWifiEnabled:{_interfaceManager.IsWifiEnabled}");
            if (!_interfaceManager.IsApEnabled || _interfaceManager.IsWifiEnabled)
            {
                _logger.Trace("Setting operation mode to ConfigurationStart");
                _operationModeService.SetOperationMode(OperationMode.ConfigurationStart);
                ProcessOperationMode(OperationMode.ConfigurationStart);
                return;
            }

            _interfaceManager.StartDhcp();

            _logger.Trace("Starting WebServer");
            _apiServer.Initialize();
            _apiServer.Start();
        }

        private void ProcessConfigExit()
        {
            _logger.Trace("Stopping WebServer");
            _apiServer.Stop();

            _interfaceManager.StopDhcp();
            _interfaceManager.DisableAP();
            _interfaceManager.EnableWiFi();

            _logger.Trace("Setting operation mode to Normal");
            _operationModeService.SetOperationMode(OperationMode.Normal);

            //reboot
            _logger.Trace("Rebooting");
            _device.Reboot(); 
        }

        /// <summary>
        /// Handles event(s) from Mediator
        /// </summary>
        /// <param name="event">The event</param>
        public void Handle(IEvent @event)
        {
            if (@event is ConfigModeToggleEvent e)
            {
                switch (e.Mode)
                {
                    case SwitchMode.On: StartConfigMode(); break;
                    case SwitchMode.Off: StopConfigMode(); break;
                    case SwitchMode.Toggle:
                        if (_operationModeService.GetOperationMode() == OperationMode.Normal)
                            StartConfigMode();
                        else
                            StopConfigMode();
                        break;
                }

            }
            else if (@event is ResetToDefaultsEvent)
            {
                ResetToDefaults();
            }
        }
    }
}
