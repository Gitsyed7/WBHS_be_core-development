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

        Task<SaveCollegeRegistrationResponse>
        SaveCollegeRegistrationAsync(
          SaveCollegeRegistrationRequest request
        );
        Task<List<GenderDto>> GetGenderAsync();
        Task<List<MaritalStatusDto>> GetMaritalStatusAsync();
        Task<List<DistrictDto>> GetDistrictAsync();
  }
}