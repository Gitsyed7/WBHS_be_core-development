using Microsoft.AspNetCore.Mvc;
namespace WBHealthScheme.Api.Controllers;

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    private readonly EncryptionService _encryptionService;

    public TestController(EncryptionService encryptionService)
    {
        _encryptionService = encryptionService;
    }

    [HttpGet("encrypt")]
    public IActionResult Encrypt()
    {
        var encrypted = _encryptionService.Encrypt("secret123");

        return Ok(new
        {
            original = "secret123",
            encrypted = encrypted
        });
    }
}