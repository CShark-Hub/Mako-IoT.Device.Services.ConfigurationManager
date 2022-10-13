using MakoIoT.Device.Services.ConfigurationManager.Behaviors;
using MakoIoT.Device.Services.ConfigurationManager.Services;
using MakoIoT.Device.Services.DependencyInjection;
using MakoIoT.Device.Services.Interface;

namespace MakoIoT.Device.Services.ConfigurationManager.Extensions
{
    public static class DeviceBuilderExtension
    {
        public static IDeviceBuilder AddConfigurationManager(this IDeviceBuilder builder)
        {
            DI.RegisterSingleton(typeof(IDeviceStartBehavior), typeof(ConfigManagerDeviceBehavior));
            DI.RegisterSingleton(typeof(IConfigManager), typeof(ConfigManager));
            DI.RegisterSingleton(typeof(IOperationModeService), typeof(OperationModeService));

            return builder;
        }
    }
}
