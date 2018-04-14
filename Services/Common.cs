using Microsoft.WindowsAzure.Storage;

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
