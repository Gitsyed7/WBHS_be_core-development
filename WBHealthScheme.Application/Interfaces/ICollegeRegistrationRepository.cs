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
        Task<bool>
        SaveCollegeRegistrationAsync(
            SaveCollegeRegistrationRequest request,
            string slrNo,
            string appId,
            string createIp
        );
        Task<List<GenderDto>> GetGenderAsync();
        Task<List<MaritalStatusDto>> GetMaritalStatusAsync();
        Task<List<DistrictDto>> GetDistrictAsync();
    }
}