using WBHealthScheme.Application.Dtos;

namespace WBHealthScheme.Application.Interfaces
{
public interface ICollegeRegistrationRepository
{
    Task<CheckHRMSDbResponse?>
      CheckHRMSAsync
      (
      CheckHRMSRequest request
      );
}
}