using MakoIoT.Device.Services.ConfigurationManager.Services;
using MakoIoT.Device.Services.Interface;

namespace MakoIoT.Device.Services.ConfigurationManager.Behaviors
{
    public sealed class ConfigManagerDeviceBehavior : IDeviceStartBehavior
    {
        private readonly IOperationModeService _operationModeService;
        private readonly ILog _logger;
        private readonly IConfigManager _configManger;

        public ConfigManagerDeviceBehavior(IOperationModeService operationModeService, ILog logger, IConfigManager configManger)
        {
            _operationModeService = operationModeService;
            _logger = logger;
            _configManger = configManger;
        }

        public bool DeviceStarting()
        {
            var mode = _operationModeService.GetOperationMode();
            _logger.Trace($"Device starting mode: {mode}");
            if (mode == OperationMode.Normal)
            {
                return true;
            }

            return _configManger.ProcessOperationMode(mode);
        }
    }
}
