﻿using API.VisionAuditiva.Interfaces;
using API.VisionAuditiva.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> getResponse(string request)
        {
            var text = await _cognitiveChatService.getResponse(request);
            return Ok(text);
        }
    }
}
