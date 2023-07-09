using API.VisionAuditiva.Models;

namespace API.VisionAuditiva.Interfaces
{
    public interface IImageService
    {
        Task<Image> SaveImageFromBase64Async(string base64, string filename);
        Task<string> GetImageAsBase64Async(string filename);
        Task<Stream> GetImageStreamAsync(string filename);
    }
}
