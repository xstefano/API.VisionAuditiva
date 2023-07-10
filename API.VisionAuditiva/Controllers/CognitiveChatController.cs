using API.VisionAuditiva.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.VisionAuditiva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CognitiveChatController : ControllerBase
    {
        private readonly ICognitiveChatService _cognitiveChatService;

        public CognitiveChatController(ICognitiveChatService cognitiveChatService)
        {
            _cognitiveChatService = cognitiveChatService;
        }

        [HttpGet("getResponse")]
        public async Task<IActionResult> getResponse(string request)
        {
            var text = await _cognitiveChatService.getResponse(request);
            return Ok(text);
        }
    }
}
