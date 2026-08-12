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

//Save Personal Details
    Task SavePersonalInformationAsync(
    SavePersonalInformationRequest request,
    DateTime retirementDate,
    string isExists);

//Get Personal Form

    Task<ClgPersonalFetchResponse?>
    GetPersonalInformationAsync(
        ClgPersonalFetchRequest request);
        
    }
}