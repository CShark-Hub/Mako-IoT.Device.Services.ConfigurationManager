using MakoIoT.Device.Services.ConfigurationManager.Interface;
using System;

namespace MakoIoT.Device.Services.ConfigurationManager.Test.Mocks
{
    internal class DeviceControlMock : IDeviceControl
    {
        public void Reboot()
        {
            throw new NotImplementedException();
        }

        public void SignalConfigMode()
        {
            throw new NotImplementedException();
        }

        public void SignalNormalMode()
        {
            throw new NotImplementedException();
        }
    }
}
