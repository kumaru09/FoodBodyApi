using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FoodbodyApi.Repositories {
    public interface IBlobRepository {
        Task<string> UploadFoodImageFile(IFormFile formfile);
    }
}