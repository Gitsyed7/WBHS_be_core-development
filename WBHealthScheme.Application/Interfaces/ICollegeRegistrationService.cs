using WBHealthScheme.Application.Dtos;

namespace WBHealthScheme.Application.Interfaces
{
public interface ICollegeRegistrationService
{
    Task<CheckHRMSResponse>
      CheckHRMSAsync
      (
      CheckHRMSRequest request
      );
}
}