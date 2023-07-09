using API.VisionAuditiva.Interfaces;
using API.VisionAuditiva.Message;
using API.VisionAuditiva.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.VisionAuditiva.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;
        protected Response _response;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
            _response = new Response();
        }


        [HttpPost]
        public async Task<IActionResult> SaveImage(Image image)
        {
            try
            {
                var url = await _imageService.SaveImageFromBase64Async(image.imageBase64, image.filename);
                url.imageBase64 = $"https://localhost:7135/Image/{url.filename}";
                _response.Result = url;
                _response.DisplayMessage = "Image Uploaded";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error saving image";
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                throw;
            }
            return Ok(_response);
        }
    }
}
