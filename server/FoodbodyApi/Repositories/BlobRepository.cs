using System;
using System.Threading.Tasks;
using FoodbodyApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace FoodbodyApi.Repositories
{
    public class BlobRepository : IBlobRepository
    {
        private readonly string _connectingString;
        public BlobRepository(IDatabaseSettings databaseSettings)
        {
            _connectingString = databaseSettings.BlobConnectionString;
        }
        public async Task<string> UploadFoodImageFile(IFormFile formfile)
        {
            try
            {
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(_connectingString);
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("food");

                if (await cloudBlobContainer.CreateIfNotExistsAsync())
                {
                    await cloudBlobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
                }

                if (formfile != null)
                {
                    CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(formfile.FileName);
                    cloudBlockBlob.Properties.ContentType = formfile.ContentType;
                    await cloudBlockBlob.UploadFromStreamAsync(formfile.OpenReadStream());
                    return cloudBlockBlob.Uri.AbsoluteUri;
                }
                return "";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}