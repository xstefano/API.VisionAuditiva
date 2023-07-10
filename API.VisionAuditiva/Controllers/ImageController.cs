using API.VisionAuditiva.Interfaces;
using API.VisionAuditiva.Message;
using API.VisionAuditiva.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> SaveImage(Image image)
        {
            try
            {
                var url = await _imageService.SaveImageFromBase64Async(image.imageBase64, image.filename);
                url.imageBase64 = $"https://visionauditiva.azurewebsites.net/Image/{url.filename}";
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

        [HttpGet("GetImageBase64/{filename}")]
        public async Task<IActionResult> GetImageBase64(string filename)
        {
            try
            {
                var base64 = await _imageService.GetImageAsBase64Async(filename);
                _response.Result = base64;
                _response.DisplayMessage = "Base64 Image";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error";
                _response.ErrorMessages = new List<string>() { ex.ToString() }; 
            }
            return Ok(_response);
        }

        [HttpGet("{filename}")]
        public async Task<IActionResult> GetImage(string filename)
        {
            var stream = await _imageService.GetImageStreamAsync(filename);
            if (stream == null)
            {
                return NotFound();
            }

            return File(stream, "image/jpeg");
        }
    }
}
