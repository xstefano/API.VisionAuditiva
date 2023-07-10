using API.VisionAuditiva.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.VisionAuditiva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CognitiveVisionController : ControllerBase
    {
        private readonly ICognitiveVisionService _cognitiveVisionService;

        public CognitiveVisionController(ICognitiveVisionService service)
        {
            _cognitiveVisionService = service;
        }

        [HttpGet("analyze")]
        public async Task<IActionResult> AnalyzeFromUrlAsync(string imageUrl)
        {
            var description = await _cognitiveVisionService.AnalyzeFromUrlAsync(imageUrl);
            return Ok(description);
        }
        [HttpGet("describe")]
        public async Task<IActionResult> DescribeFromUrlAsync(string imageUrl)
        {
            var description = await _cognitiveVisionService.DescribeFromUrlAsync(imageUrl);
            return Ok(description);
        }


        [HttpGet("read")]
        public async Task<IActionResult> ReadImageUrlAsync(string imageUrl)
        {
            var text = await _cognitiveVisionService.ReadImageUrlAsync(imageUrl);
            return Ok(text);
        }

        [HttpGet("detectObjects")]
        public async Task<IActionResult> DetectObjectsFromUrlAsync(string imageUrl)
        {
            var text = await _cognitiveVisionService.DetectObjectsFromUrlAsync(imageUrl);
            return Ok(text);
        }
    }
}
