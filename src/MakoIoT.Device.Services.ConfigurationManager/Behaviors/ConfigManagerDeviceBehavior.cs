using MakoIoT.Device.Services.ConfigurationManager.Services;
using MakoIoT.Device.Services.DependencyInjection;
using MakoIoT.Device.Services.Interface;
using Microsoft.Extensions.Logging;

namespace MakoIoT.Device.Services.ConfigurationManager.Behaviors
{
    public class ConfigManagerDeviceBehavior : IDeviceStartBehavior
    {
        private readonly IOperationModeService _operationModeService;
        private readonly ILogger _logger;

        public ConfigManagerDeviceBehavior(IOperationModeService operationModeService, ILogger logger)
        {
            _operationModeService = operationModeService;
            _logger = logger;
        }

        public bool DeviceStarting()
        {
            var mode = _operationModeService.GetOperationMode();
            _logger.LogDebug($"Device starting mode: {mode}");

            if (mode == OperationMode.Normal)
                return true;

            return ((ConfigManager)DI.BuildUp(typeof(ConfigManager))).ProcessOperationMode(mode);
        }
    }
}
