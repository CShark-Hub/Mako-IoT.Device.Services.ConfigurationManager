using MakoIoT.Device.Services.ConfigurationManager.Services;
using MakoIoT.Device.Services.Interface;
using Microsoft.Extensions.Logging;
using nanoFramework.DependencyInjection;
using System;

namespace MakoIoT.Device.Services.ConfigurationManager.Behaviors
{
    public class ConfigManagerDeviceBehavior : IDeviceStartBehavior
    {
        private readonly IOperationModeService _operationModeService;
        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;

        public ConfigManagerDeviceBehavior(IOperationModeService operationModeService, ILogger logger, IServiceProvider serviceProvider)
        {
            _operationModeService = operationModeService;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public bool DeviceStarting()
        {
            var mode = _operationModeService.GetOperationMode();
            _logger.LogDebug($"Device starting mode: {mode}");
            if (mode == OperationMode.Normal)
            {
                return true;
            }

            var configManger = (IConfigManager)_serviceProvider.GetRequiredService(typeof(IConfigManager));
            return configManger.ProcessOperationMode(mode);
        }
    }
}
