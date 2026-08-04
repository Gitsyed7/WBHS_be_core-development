using Microsoft.AspNetCore.Mvc;
using WBHealthScheme.Application.Dtos;
using WBHealthScheme.Application.Interfaces;

namespace WBHealthScheme.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IfscController : ControllerBase
    {
        private readonly IIfscService _service;

        public IfscController(IIfscService service)
        {
            _service = service;
        }

        [HttpPost("details")]
        public async Task<IActionResult> GetIfscDetails(
            [FromBody] IfscRequest request)
        {
            var result = await _service.GetIfscDetailsAsync(request);

            return Ok(result);
        }
    }
}