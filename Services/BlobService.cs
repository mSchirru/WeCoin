using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Services
{
    public class BlobService
    {
        public CloudStorageAccount StorageAccount { get; private set; }
        private static BlobService _instance;

        private BlobService(CloudStorageAccount cloudStorage)
        {
            //Conta do Azure Storage
            StorageAccount = cloudStorage;
        }

        public static BlobService GetInstance()
        {
            if (_instance == null)
                _instance = new BlobService(Common.GetStorageAccount());
            return _instance;
        }

        public String UploadFile(String container, String fileName, System.IO.Stream inputStream, String contentType)
        {
            //Classe que faz acesso ao Azure Storage Blob
            CloudBlobClient blobClient = StorageAccount.CreateCloudBlobClient();

            //Classe que faz referência a um Container
            CloudBlobContainer blobContainer = blobClient.GetContainerReference(container);

            //Cria um container novo se não existe
            blobContainer.CreateIfNotExists();

            //Referência a uma imagem
            CloudBlockBlob cloudBlockblob = blobContainer.GetBlockBlobReference(fileName);
            cloudBlockblob.Properties.ContentType = contentType;

            //Upload não assíncrono
            cloudBlockblob.UploadFromStream(inputStream);

            //Blob URL
            return cloudBlockblob.Uri.ToString();
        }
    }
}
