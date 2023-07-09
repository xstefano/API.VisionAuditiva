using API.VisionAuditiva.Interfaces;
using API.VisionAuditiva.Models;
using Azure.Storage.Blobs;

namespace API.VisionAuditiva.Services
{
    public class ImageService : IImageService
    {
        private readonly IConfiguration _configuration;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _blobContainerName;

        public ImageService(IConfiguration configuration)
        {
            _configuration = configuration;
            _blobServiceClient = new BlobServiceClient(_configuration.GetConnectionString("AzureBlobStorage"));
            _blobContainerName = "image";
        }

        public Task<string> GetImageAsBase64Async(string filename)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> GetImageStreamAsync(string filename)
        {
            throw new NotImplementedException();
        }

        public Task<Image> SaveImageFromBase64Async(string base64, string filename)
        {
            throw new NotImplementedException();
        }
    }
}
