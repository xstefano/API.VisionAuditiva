using API.VisionAuditiva.Interfaces;
using API.VisionAuditiva.Models;
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

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

        public async Task<string> GetImageAsBase64Async(string filename)
        {
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(_blobContainerName);
            BlobClient blobClient = containerClient.GetBlobClient(filename);

            Response<BlobProperties> properties = await blobClient.GetPropertiesAsync();

            byte[] bytes = new byte[properties.Value.ContentLength];

            using (var Stream = new MemoryStream(bytes))
            {
                await blobClient.DownloadToAsync(Stream);
            }

            return Convert.ToBase64String(bytes);
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
