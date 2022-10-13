namespace MakoIoT.Device.Services.ConfigurationManager.Interface
{
    public interface IDeviceControl
    {
        void Reboot();
        void SignalConfigMode();
        void SignalNormalMode();
    }
}
