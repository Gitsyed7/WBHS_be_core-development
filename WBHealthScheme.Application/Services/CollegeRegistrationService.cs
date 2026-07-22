using WBHealthScheme.Application.Dtos;
using WBHealthScheme.Application.Interfaces;

namespace WBHealthScheme.Application.Services
{

public class CollegeRegistrationService : ICollegeRegistrationService
{

private readonly ICollegeRegistrationRepository _repository;


public CollegeRegistrationService
(
      ICollegeRegistrationRepository repository
)
{
      _repository=repository;
}


public async Task<CheckHRMSResponse>
CheckHRMSAsync
(
      CheckHRMSRequest request
)
{
      var result =
        await _repository.CheckHRMSAsync(request);

    // Business Logic goes here
    if (result == null)
{
    return new CheckHRMSResponse
    {
        Message = "Fresh Enrollment.",
        IsSuccess = true
    };
}
if (result.IS_EXISTS == "0")
{
    return new CheckHRMSResponse
    {
        ApplicationId = result.APP_ID,
        Status = result.IS_EXISTS,
        Message = "Continue Enrollment.",
        IsSuccess = true
    };
}
if (result.IS_EXISTS == "1")
{
    return new CheckHRMSResponse
    {
        ApplicationId = result.APP_ID,
        Status = result.IS_EXISTS,
        Message = "Application Submitted.",
        IsSuccess = true
    };
}
if (result.IS_EXISTS == "2")
{
    return new CheckHRMSResponse
    {
        ApplicationId = result.APP_ID,
        Status = result.IS_EXISTS,
        Message = "Application Verified.",
        IsSuccess = true
    };
}
if(result.IS_EXISTS=="3")
{
    return new CheckHRMSResponse
    {
        ApplicationId = result.APP_ID,
        Status = result.IS_EXISTS,
        Message = "Application Rejected.",
        IsSuccess = true
    };
}

if (result.IS_EXISTS == "4")
{
    return new CheckHRMSResponse
    {
        ApplicationId = result.APP_ID,
        Status = result.IS_EXISTS,
        Message = "Opted out of WBHS.",
        IsSuccess = true
    };
}

if (result.IS_EXISTS == "5")
{
    return new CheckHRMSResponse
    {
        ApplicationId = result.APP_ID,
        Status = result.IS_EXISTS,
        Message = "Enrolment terminated.",
        IsSuccess = true
    };
}
    return new CheckHRMSResponse()
    {
        Message = "Unhandled Scenario.",
        IsSuccess = false
    };
}


}

}