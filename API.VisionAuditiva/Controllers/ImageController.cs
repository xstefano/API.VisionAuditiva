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
    }
}
