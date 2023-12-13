using MakoIoT.Device.Services.ConfigurationManager.Services;
using MakoIoT.Device.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MakoIoT.Device.Services.ConfigurationManager.Behaviors
{
    internal sealed class ConfigManagerDeviceBehavior : IDeviceStartBehavior
    {
        private readonly IOperationModeService _operationModeService;
        private readonly ILog _logger;
        private readonly IServiceProvider _serviceProvider;

        public ConfigManagerDeviceBehavior(IOperationModeService operationModeService, ILog logger, IServiceProvider serviceProvider)
        {
            _operationModeService = operationModeService;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public bool DeviceStarting()
        {
            var mode = _operationModeService.GetOperationMode();
            _logger.Trace($"Device starting mode: {mode}");
            if (mode == OperationMode.Normal)
            {
                return true;
            }

            var configManger = (IConfigManager)_serviceProvider.GetRequiredService(typeof(IConfigManager));
            return configManger.ProcessOperationMode(mode);
        }
    }
}
