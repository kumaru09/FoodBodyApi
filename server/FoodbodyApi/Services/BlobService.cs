using System.Threading.Tasks;
using FoodbodyApi.Repositories;
using Microsoft.AspNetCore.Http;

namespace FoodbodyApi.Services {
    public class BlobService : IBlobService
    {
        private readonly IBlobRepository _blobRepository;

        public BlobService(IBlobRepository blobRepository) {
            _blobRepository = blobRepository;
        }

        public Task<string> UploadFoodImageFileAsync(IFormFile formfile)
        {
            return _blobRepository.UploadFoodImageFile(formfile);
        }
    }
}