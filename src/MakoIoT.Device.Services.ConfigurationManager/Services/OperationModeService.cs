using MakoIoT.Device.Services.Interface;

namespace MakoIoT.Device.Services.ConfigurationManager.Services
{
    public class OperationModeService : IOperationModeService
    {
        public const string OperationModeFileName = "OperationMode.sys";

        private readonly IStorageService _storageService;

        public OperationModeService(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public void SetOperationMode(OperationMode mode)
        {
            _storageService.WriteToFile(OperationModeFileName, mode.ToString());
        }

        public OperationMode GetOperationMode()
        {
            if (!_storageService.FileExists(OperationModeFileName))
                return OperationMode.Normal;

            return (OperationMode)int.Parse(_storageService.ReadFile(OperationModeFileName));
        }
    }
}
