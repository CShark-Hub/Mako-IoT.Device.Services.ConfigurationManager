using MakoIoT.Device.Services.ConfigurationManager.Extensions;
using MakoIoT.Device.Services.ConfigurationManager.Interface;
using MakoIoT.Device.Services.ConfigurationManager.Services;
using MakoIoT.Device.Services.ConfigurationManager.Test.Mocks;
using MakoIoT.Device.Services.Interface;
using MakoIoT.Device.Services.Server.Services;
using MakoIoT.Device.Services.WiFi.AP;
using Microsoft.Extensions.Logging;
using nanoFramework.DependencyInjection;
using nanoFramework.TestFramework;

namespace MakoIoT.Device.Services.ConfigurationManager.Test.Extensions
{
    [TestClass]
    public class DeviceBuilderExtensionTests
    {
        [TestMethod]
        public void AddConfigurationManager_Should_RegisterServices()
        {
            var mockBuilder = new DeviceBuilderMock();
            mockBuilder.Services.AddSingleton(typeof(IStorageService), typeof(StorageServiceMock));
            mockBuilder.Services.AddSingleton(typeof(ILogger), typeof(MockLogger));

            mockBuilder.Services.AddSingleton(typeof(INetworkInterfaceManager), typeof(NetworkInterfaceManagerMock));
            mockBuilder.Services.AddSingleton(typeof(IDeviceControl), typeof(DeviceControlMock));
            mockBuilder.Services.AddSingleton(typeof(IServer), typeof(ServerMock));
            mockBuilder.Services.AddSingleton(typeof(IConfigurationService), typeof(ConfigurationServiceMock));


            mockBuilder.AddConfigurationManager();

            var provider = mockBuilder.Services.BuildServiceProvider();
            var service1 = provider.GetService(typeof(IDeviceStartBehavior));
            var service2 = provider.GetService(typeof(IConfigManager));
            var service3 = provider.GetService(typeof(IOperationModeService));
            Assert.IsNotNull(service1);
            Assert.IsNotNull(service2);
            Assert.IsNotNull(service3);
        }
    }
}
