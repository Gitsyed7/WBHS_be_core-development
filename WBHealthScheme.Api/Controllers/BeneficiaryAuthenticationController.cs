using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WBHealthScheme.Application.dtos;
using WBHealthScheme.Application.Dtos;
using WBHealthScheme.Application.Interfaces;
using WBHealthScheme.Domain.Common;
namespace WBHealthScheme.Api.Controllers
{
    [HmacAuth]
    [ApiController]
    [Route("api/v1/beneficiary-auth")]
    public class BeneficiaryAuthenticationController : ControllerBase
    {
        private readonly IBeneficiaryAuthenticationService _service;
        public BeneficiaryAuthenticationController(IBeneficiaryAuthenticationService service)
        {
            _service = service;
        } 

        // ------------------------------------------------------
        // API: For University, By Unique ID
        // ------------------------------------------------------
      
        [HttpGet("univ/{uniqueId}")]
        public async Task<IActionResult> GetByUniqueId(string uniqueId)
        {
            var result = await
            _service.GetBeneficiaryByUniqueIdAsync(uniqueId);

            return Ok(ApiResponse<List<UnivBeneficiaryAuthenticationResponse>>
                .Ok(result, "Beneficiary fetched successfully"));
        }

        // ------------------------------------------------------
        // API: For Govt. Emplyee, By HRMS ID
        // ------------------------------------------------------
        
        [HttpGet("govtemp/{hrmsId}")]
        public async Task<IActionResult> GetwardByappid(string hrmsid)
        {
            var result = await
            _service.GetWardByAppIdAsync(hrmsid);

            return Ok(ApiResponse<List<BeneficiaryWardRespBroto>>
            .Ok(result, "Enrollment fetched successfully")); 
        }

        // ------------------------------------------------------
        // API: For Collage, By HRMS ID
        // ------------------------------------------------------
     
        [HttpGet("clg/{hrmsId}")]
        public async Task<IActionResult> GetByHrmsId(string hrmsId)
        {
            var result = await
            _service.GetBeneficiaryByHrmsIdClgAsync(hrmsId);

            return Ok(ApiResponse<List<ClgBeneficiaryAuthenticationResponse>>
                .Ok(result, "Beneficiary fetched successfully"));
        }

        // ------------------------------------------------------
        // API: For Panchayat Employee, By IOSMS ID
        // ------------------------------------------------------
        [HmacAuth]
        [HttpGet("pnhytEmp/{iosmsId}")]
        public async Task<IActionResult> GetByIosmsId(string iosmsId)
        {
            var result = await
            _service.GetBeneficiaryByIosmsIdAsync(iosmsId);

            return Ok(ApiResponse<List<PnhytEmpBeneficiaryAuthenticationResponse>>
                .Ok(result, "Beneficiary fetched successfully"));
        }

        // ------------------------------------------------------
        // API: For Panchayat Pensioner, By Application ID
        // ------------------------------------------------------
        [HmacAuth]
        [HttpGet("pnhytPen/{*appId}")]
        public async Task<IActionResult> GetByPnhytPenAppId(string appId)
        {
            var result = await
            _service.GetBeneficiaryPnhytPenByAppIdAsync(appId);

            return Ok(ApiResponse<List<PnhytPenBeneficiaryAuthenticationResponse>>
                .Ok(result, "Beneficiary fetched successfully"));
        }

        // ------------------------------------------------------
        // API: For Govt Employee Pensioner, By Application ID
        // ------------------------------------------------------
        [HmacAuth]
        [HttpGet("govtEmpPen/{*appId}")]
        public async Task<IActionResult> GetbyAppliID(string appId)
        {
            var result = await _service.GetBeneficiaryGovtEmpPenByAppIdAsync(appId);

            return Ok(ApiResponse<List<GovtEmpPenBeneficiaryAuthenticationResponse>>
            .Ok(result, "Enrollment fetched successfully"));
        }
      
        // ------------------------------------------------------
        // API: For All Enrolled User, By Mobile No.
        // ------------------------------------------------------
        [HmacAuth]
        [HttpGet("mobile-Number/{mobileNumber}")]
        public async Task<IActionResult> GetByMobileAll(string mobileNumber)
        {
            var result = await
            _service.GetAllBeneficiaryByMobileAsync(mobileNumber);
            
            return Ok(ApiResponse<List<AllBeneficiaryAuthenticationResponseByMobileNo>>
                .Ok(result, "Beneficiary fetched successfully"));
        }

        

    }
}
