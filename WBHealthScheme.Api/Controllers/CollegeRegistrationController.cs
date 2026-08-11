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

        [HttpPost("check-hrms")]
        public async Task<IActionResult> CheckHRMS(CheckHRMSRequest request) // not 100% sure about this line
        {
            var result = await _service.CheckHRMSAsync(request); // I thought this will call CheckHRMSAsync but it gives error

            return Ok(result);
        }

        [HttpPost("save-college-registration")]
        public async Task<IActionResult> SaveCollegeRegistration(SaveCollegeRegistrationRequest request)
        {
            request.IpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            var result = await _service.SaveCollegeRegistrationAsync(request);
            return Ok(result);
        }
        [HttpGet("gender")]
        public async Task<IActionResult> GetGender()
        {
            var genders = await _service.GetGenderAsync();
            return Ok(genders);
        }

        [HttpGet("maritalStatus")]
        public async Task<IActionResult> GetMaritalStatus()
        {
            var maritalStatuses = await _service.GetMaritalStatusAsync();
            return Ok(maritalStatuses);
        }

        [HttpGet("district")]
        public async Task<IActionResult> GetDistrict()
        {
            var districts = await _service.GetDistrictAsync();
            return Ok(districts);
        }

        [HttpPost("save-personal-information")]
        public async Task<IActionResult> SavePersonalInformation(
    [FromBody] SavePersonalInformationRequest request)
        {
            await _service.SavePersonalInformationAsync(request);

            return Ok(new
            {
                message = "Personal information saved successfully."
            });
        }
    }
}