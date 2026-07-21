using WBHealthScheme.Application.Dtos;

namespace WBHealthScheme.Application.Interfaces
{
public interface ICollegeRegistrationRepository
{
    Task<CheckHRMSResponse>
      CheckHRMSAsync
      (
      CheckHRMSRequest request
      );
}
}