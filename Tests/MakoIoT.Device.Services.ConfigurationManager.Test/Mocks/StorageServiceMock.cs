using MakoIoT.Device.Services.Interface;
using System;

namespace MakoIoT.Device.Services.ConfigurationManager.Test.Mocks
{
    internal class StorageServiceMock : IStorageService
    {
        public void DeleteFile(string fileName)
        {
            throw new NotImplementedException();
        }

        public bool FileExists(string fileName)
        {
            throw new NotImplementedException();
        }

        public string[] GetFileNames()
        {
            throw new NotImplementedException();
        }

        public long GetFileSize(string fileName)
        {
            throw new NotImplementedException();
        }

        public string[] GetFiles()
        {
            throw new NotImplementedException();
        }

        public string ReadFile(string fileName)
        {
            throw new NotImplementedException();
        }

        public void WriteToFile(string fileName, string text)
        {
            throw new NotImplementedException();
        }
    }
}
