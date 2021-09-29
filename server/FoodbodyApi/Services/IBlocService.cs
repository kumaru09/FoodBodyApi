using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FoodbodyApi.Services {
    public interface IBlobService {
        Task<string> UploadFoodImageFileAsync(IFormFile formfile);
    }
}