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
        Message = "No previous enrolment found. Enter your DOB and register application. ",
        IsSuccess = true
    };
}
if (result.IS_EXISTS == "0")
{
    return new CheckHRMSResponse
    {
        ApplicationId = result.APP_ID,
        SlrNo =result.SLR_NO,
        Dob = DateOnly.Parse(result.DOB),
        Status = result.IS_EXISTS,
        Message = "HRMS ID already registered. Please Complete Enrollment.",
        IsSuccess = true
    };
}
if (result.IS_EXISTS == "1")
{
    return new CheckHRMSResponse
    {
        ApplicationId = result.APP_ID,
        Status = result.IS_EXISTS,
        Message = "Application Submitted and await on verification.",
        IsSuccess = true
    };
}
if (result.IS_EXISTS == "2")
{
    return new CheckHRMSResponse
    {
        ApplicationId = result.APP_ID,
        Status = result.IS_EXISTS,
        Message = "Application Verified. Collect your certificate from concerned authority.",
        IsSuccess = true
    };
}
if(result.IS_EXISTS=="3")
{
    return new CheckHRMSResponse
    {
        ApplicationId = result.APP_ID,
        Status = result.IS_EXISTS,
        Message = "Application Rejected. You can re-apply.",
        IsSuccess = true
    };
}

if (result.IS_EXISTS == "4")
{
    return new CheckHRMSResponse
    {
        ApplicationId = result.APP_ID,
        Status = result.IS_EXISTS,
        Message = "You Opted out of WBHS. Kindly Contact your concerned authority.",
        IsSuccess = true
    };
}

if (result.IS_EXISTS == "5")
{
    return new CheckHRMSResponse
    {
        ApplicationId = result.APP_ID,
        Status = result.IS_EXISTS,
        Message = "Your Enrolment terminated. Kindly Contact your concerned authority.",
        IsSuccess = true
    };
}
    return new CheckHRMSResponse()
    {
        Message = "Unhandled Scenario.",
        IsSuccess = false
    };
}
public async Task<SaveCollegeRegistrationResponse>
    SaveCollegeRegistrationAsync(
        SaveCollegeRegistrationRequest request)
    {
        var dateNow =
            DateTime.Now
        .ToString("yyyyMMddHHmmssfff");

        var slrNo =
            request.HRMSId + dateNow;
        
        var appId =
            request.HRMSId +
            request.DOB
            .ToString("ddMMyyyy");

        var createIp ="0.0.0.0";
        
        var result =
        await _repository
            .SaveCollegeRegistrationAsync(
                request,
                slrNo,
                appId,
                createIp);


        return new SaveCollegeRegistrationResponse()
        {
            ApplicationId = appId,
            SlrNo = slrNo,
            Dob = request.DOB,
            Message = "Application Generated Successfully. Please continue to enrolment.",
            IsSuccess = true
        };
    }

    public async Task<List<GenderDto>> GetGenderAsync()
{
    return await _repository.GetGenderAsync();
}
public async Task<List<MaritalStatusDto>> GetMaritalStatusAsync()
{
    return await _repository.GetMaritalStatusAsync();
}
public async Task<List<DistrictDto>> GetDistrictAsync()
{
    return await _repository.GetDistrictAsync();
}

}

}