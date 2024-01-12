using MakoIoT.Device.Services.ConfigurationManager.Behaviors;
using MakoIoT.Device.Services.ConfigurationManager.Services;
using MakoIoT.Device.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MakoIoT.Device.Services.ConfigurationManager.Extensions
{
    public static class DeviceBuilderExtension
    {
        public static IDeviceBuilder AddConfigurationManager(this IDeviceBuilder builder)
        {
            builder.Services.AddTransient(typeof(IDeviceStartBehavior), typeof(ConfigManagerDeviceBehavior));
            builder.Services.AddTransient(typeof(IConfigManager), typeof(ConfigManager));
            builder.Services.AddTransient(typeof(IOperationModeService), typeof(OperationModeService));

            return builder;
        }
    }
}
