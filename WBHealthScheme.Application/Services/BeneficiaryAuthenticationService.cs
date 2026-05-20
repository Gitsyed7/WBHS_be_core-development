using WBHealthScheme.Application.dtos;
using WBHealthScheme.Application.Dtos;
using WBHealthScheme.Application.Exceptions;
using WBHealthScheme.Application.Interfaces;
namespace WBHealthScheme.Application.Services
{
    /// <summary>
    /// Provides business logic for beneficiary authentication operations.
    /// </summary>
    public class BeneficiaryAuthenticationService :
    IBeneficiaryAuthenticationService
    {
        private readonly IBeneficiaryAuthenticationRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryAuthenticationService"/> class.
        /// </summary>
        /// <param name="repository">
        /// Repository used to access beneficiary authentication data.
        /// </param>
        public BeneficiaryAuthenticationService(IBeneficiaryAuthenticationRepository repository)
        {
            _repository = repository;
        }

        /*public async Task<List<BeneficiaryAuthenticationResponse>>
        GetBeneficiaryByMobileAsync(string mobileNumber)
        {
            if (string.IsNullOrWhiteSpace(mobileNumber))
                throw new BusinessRuleException("Mobile number is required");
            if (mobileNumber.Length != 10 || !mobileNumber.All(char.IsDigit))
                throw new BusinessRuleException("Invalid mobile number");
            var result = await
                _repository.GetBeneficiaryByMobileAsync(mobileNumber);
            if (result == null || !result.Any())
                throw new NotFoundException("Beneficiary not found");
            return result;
        }*/

    /// <summary>
    /// Retrieves govt emplyee authentication details using the provided Hrms ID
    /// </summary>
    /// <param name="hrmsId">Unique identifier of the beneficiary</param>
    /// <returns>
    /// A list of UnivBeneficiaryAuthenticationResponse containing beneficiary details
    /// </returns>
        public async Task<List<BeneficiaryWardRespBroto>>
        GetWardByAppIdAsync(string hrmsId)
        {
            if (string.IsNullOrWhiteSpace(hrmsId))
                throw new BusinessRuleException("HRMS ID is required");
            if (hrmsId.Length != 10 || !hrmsId.All(char.IsDigit))
                throw new BusinessRuleException("Invalid Hrms ID");
            var result = await
            _repository.GetWardByAppIdAsync(hrmsId);
            if (result == null || !result.Any())
                throw new NotFoundException("HRMS ID not found");
            return result;
        }
        

    /// <summary>
    /// Retrieves university beneficiary authentication details using the provided unique ID
    /// after validating its format.
    /// </summary>
    /// <param name="uniqueId">Unique identifier of the beneficiary</param>
    /// <returns>
    /// A list of UnivBeneficiaryAuthenticationResponse containing beneficiary details
    /// </returns>         
        public async Task<List<UnivBeneficiaryAuthenticationResponse>>
        GetBeneficiaryByUniqueIdAsync(string uniqueId)
        {
            if (string.IsNullOrWhiteSpace(uniqueId))
                throw new BusinessRuleException("Unique ID is required");
            if (uniqueId.Length != 11 
                || !uniqueId.Substring(0, 6).All(char.IsLetter) 
                || !uniqueId.Substring(6, 4).All(char.IsDigit) 
                ||!char.IsLetter(uniqueId[10]))
                throw new BusinessRuleException("Invalid Unique ID");
            var result = await
                _repository.GetBeneficiaryByUniqueIdAsync(uniqueId);
            if (result == null || !result.Any())
                throw new NotFoundException("Beneficiary not found");
            return result;
        }        
      
    /// <summary>
    /// Retrieves collage beneficiary authentication details using the provided Hrms ID
    /// after validating its format.
    /// </summary>
    /// <param name="hrmsId">Unique identifier of the beneficiary</param>
    /// <returns>
    /// A list of UnivBeneficiaryAuthenticationResponse containing beneficiary details
    /// </returns>        
        public async Task<List<ClgBeneficiaryAuthenticationResponse>>
        GetBeneficiaryByHrmsIdClgAsync(string hrmsId)
        {
            if (string.IsNullOrWhiteSpace(hrmsId))
                throw new BusinessRuleException("HRMS ID is required");
            if (hrmsId.Length != 11 
                || !hrmsId.Substring(0, 1).All(char.IsLetter) 
                || !hrmsId.Substring(1, 10).All(char.IsDigit))
                throw new BusinessRuleException("Invalid HRMS ID");
            var result = await
                _repository.GetBeneficiaryByHrmsIdClgAsync(hrmsId);
            if (result == null || !result.Any())
                throw new NotFoundException("Beneficiary not found");
            return result;
        }

    /// <summary>
    /// Retrieves panchayat employee beneficiary authentication details using the provided IOSMS ID
    /// after validating its format.
    /// </summary>
    /// <param name="iosmsId">Unique identifier of the beneficiary</param>
    /// <returns>
    /// A list of PnhytEmpBeneficiaryAuthenticationResponse containing beneficiary details
    /// </returns>
        public async Task<List<PnhytEmpBeneficiaryAuthenticationResponse>>
        GetBeneficiaryByIosmsIdAsync(string iosmsId)
        {
            if (string.IsNullOrWhiteSpace(iosmsId))
                throw new BusinessRuleException("IOSMS ID is required");
            if (iosmsId.Length != 12 
                || !iosmsId.Substring(0, 2).All(char.IsLetter) 
                || !iosmsId.Substring(2).All(char.IsDigit))
                throw new BusinessRuleException("Invalid IOSMS ID");
            var result = await
                _repository.GetBeneficiaryByIosmsIdAsync(iosmsId);
            if (result == null || !result.Any())
                throw new NotFoundException("Beneficiary not found");
            return result;
        }

    /// <summary>
    /// Retrieves panchayat pensioner beneficiary authentication details using the provided Application ID
    /// after validating its format.
    /// </summary>
    /// <param name="appId">Unique identifier of the beneficiary</param>
    /// <returns>
    /// A list of UnivBeneficiaryAuthenticationResponse containing beneficiary details
    /// </returns>  
        public async Task<List<PnhytPenBeneficiaryAuthenticationResponse>>
        GetBeneficiaryPnhytPenByAppIdAsync(string appId)
        {
            if (string.IsNullOrWhiteSpace(appId))
                throw new BusinessRuleException("App ID is required");
            appId = Uri.UnescapeDataString(appId);
            if (appId.Length != 17
                || appId[3] != '/'
                || appId[7] != '/'
                || !appId.Substring(0, 3).All(char.IsLetter)
                || !appId.Substring(4, 3).All(char.IsLetter)
                || !appId.Substring(8, 9).All(char.IsDigit))
                throw new BusinessRuleException("Invalid App ID");
            var result = await
                _repository.GetBeneficiaryPnhytPenByAppIdAsync(appId);
            if (result == null || !result.Any())
                throw new NotFoundException("Beneficiary not found");
            return result;
        }

    /// <summary>
    /// Retrieves govt. employee pensioner beneficiary authentication details using the provided Application ID
    /// after validating its format.
    /// </summary>
    /// <param name="appId">Unique identifier of the beneficiary</param>
    /// <returns>
    /// A list of GovtPenBeneficiaryAuthenticationResponse containing beneficiary details
    /// </returns>  
        public async Task<List<GovtEmpPenBeneficiaryAuthenticationResponse>>
        GetBeneficiaryGovtEmpPenByAppIdAsync(string appId)
        {
            if (string.IsNullOrWhiteSpace(appId))
                throw new BusinessRuleException("App ID is required");
            appId = Uri.UnescapeDataString(appId);
            if (appId.Length != 19
                || appId[2] != '/'
                || appId[6] != '/'
                || appId[9] != '/'
                || !appId.Substring(0, 2).All(char.IsLetter)
                || !appId.Substring(3, 3).All(char.IsLetter)
                || !appId.Substring(7, 2).All(char.IsDigit)
                || !appId.Substring(10, 9).All(char.IsDigit))
                throw new BusinessRuleException("Invalid Application ID"); 
            var result = await
                _repository.GetBeneficiaryGovtEmpPenByAppIdAsync(appId);
            if (result == null || !result.Any())
                throw new NotFoundException("Beneficiary not found");
            return result;
        }

    /// <summary>
    /// Retrieves all beneficiary authentication details using the provided Mobile no
    /// after validating its format.
    /// </summary>
    /// <param name="mobNumber">Mobile no. of Primary beneficiary</param>
    /// <returns>
    /// A list of UnivBeneficiaryAuthenticationResponse containing beneficiary details
    /// </returns>
        public async Task<List<AllBeneficiaryAuthenticationResponseByMobileNo>>
        GetAllBeneficiaryByMobileAsync(string mobNumber)
        {
            if (string.IsNullOrWhiteSpace(mobNumber))
                throw new BusinessRuleException("Mobile number is required");
            if (mobNumber.Length != 10 || !mobNumber.All(char.IsDigit))
                throw new BusinessRuleException("Invalid mobile number");
            var result = await
                _repository.GetAllBeneficiaryByMobileAsync(mobNumber);
            if (result == null || !result.Any())
                throw new NotFoundException("Beneficiary not found");
            return result;
        }
        
    }
}