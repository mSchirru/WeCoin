using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;

namespace Services
{
    public class Common
    {
        public static CloudStorageAccount GetStorageAccount()
        {
            return CloudStorageAccount.Parse(Services.Properties.Settings.Default.StorageConnectionString);
        }
    }
}
