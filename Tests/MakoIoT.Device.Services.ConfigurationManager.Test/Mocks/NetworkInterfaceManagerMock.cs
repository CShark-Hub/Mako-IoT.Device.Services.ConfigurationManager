using MakoIoT.Device.Services.WiFi.AP;
using MakoIoT.Device.Services.WiFi.AP.Model;
using System;

namespace MakoIoT.Device.Services.ConfigurationManager.Test.Mocks
{
    internal class NetworkInterfaceManagerMock : INetworkInterfaceManager
    {
        public bool IsWifiEnabled => throw new NotImplementedException();

        public bool IsApEnabled => throw new NotImplementedException();

        public string WifiIpAddress => throw new NotImplementedException();

        public string ApIpAddress => throw new NotImplementedException();

        public bool HasPendingChanges => throw new NotImplementedException();

        public void DisableAP()
        {
            throw new NotImplementedException();
        }

        public void DisableWiFi()
        {
            throw new NotImplementedException();
        }

        public void DisconnectWifi()
        {
            throw new NotImplementedException();
        }

        public void EnableAP()
        {
            throw new NotImplementedException();
        }

        public void EnableWiFi()
        {
            throw new NotImplementedException();
        }

        public WiFiNetworkInfo[] GetAvailableNetworks()
        {
            throw new NotImplementedException();
        }

        public void StartDhcp()
        {
            throw new NotImplementedException();
        }

        public void StopDhcp()
        {
            throw new NotImplementedException();
        }
    }
}
