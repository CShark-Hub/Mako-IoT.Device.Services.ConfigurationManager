namespace MakoIoT.Device.Services.ConfigurationManager.Services
{
    public interface IOperationModeService
    {
        void SetOperationMode(OperationMode mode);
        OperationMode GetOperationMode();
    }
}
