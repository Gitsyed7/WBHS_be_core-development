using Microsoft.AspNetCore.Mvc;
using WBHealthScheme.Application.Dtos;
using WBHealthScheme.Application.Interfaces;

namespace WBHealthScheme.Api.Controllers // namespace calling
{
    [ApiController] //dont understand
    [Route("api/[controller]")] //dont understand

    //CollegeRegistrationController is inheriting everything from ControllerBase
    public class CollegeRegistrationController : ControllerBase 
    
    {
        private readonly ICollegeRegistrationService _service; 
        //Variable declaration of class ICollegeRegistrationService

        public CollegeRegistrationController(ICollegeRegistrationService service) 
        // controller calling for providing an implementation of ICollegeRegistrationService || Dependency Injection
        {
            _service = service; // local variable calls service
        }

        [HttpPost]
        public async Task<IActionResult> CheckHRMS(CheckHRMSRequest request) // not 100% sure about this line
        {
            var result = await _service.CheckHRMSAsync(request); // I thought this will call CheckHRMSAsync but it gives error

            return Ok(result);
        }
    }
}