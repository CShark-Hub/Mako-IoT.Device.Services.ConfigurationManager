using MakoIoT.Device.Services.ConfigurationManager.Behaviors;
using MakoIoT.Device.Services.ConfigurationManager.Services;
using MakoIoT.Device.Services.Interface;
using nanoFramework.DependencyInjection;

namespace MakoIoT.Device.Services.ConfigurationManager.Extensions
{
    public static class DeviceBuilderExtension
    {
        public static IDeviceBuilder AddConfigurationManager(this IDeviceBuilder builder)
        {
            builder.Services.AddSingleton(typeof(IDeviceStartBehavior), typeof(ConfigManagerDeviceBehavior));
            builder.Services.AddSingleton(typeof(IConfigManager), typeof(ConfigManager));
            builder.Services.AddSingleton(typeof(IOperationModeService), typeof(OperationModeService));

            return builder;
        }
    }
}
