using WBHealthScheme.Application.dtos;
using WBHealthScheme.Application.Dtos;
namespace WBHealthScheme.Application.Interfaces
{
    public interface IBeneficiaryAuthenticationService
    {
        //Task<List<BeneficiaryAuthenticationResponse>>
        //GetBeneficiaryByMobileAsync(string mobileNumber);

        /// <summary>
        /// Retrieves ward details associated with the provided application ID.
        /// </summary>
        /// <param name="app_ID">Application identifier</param>
        /// <returns>
        /// A list of BeneficiaryWardRespBroto containing ward details
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when app_ID is null or empty</exception>
        Task<List<GovtEmpPenBeneficiaryAuthenticationResponse>>
        GetBeneficiaryByHrmsIdGovtAsync(string app_ID);

        /// <summary>
        /// Retrieves beneficiary authentication details using the provided unique ID.
        /// </summary>
        /// <param name="uniqueId">Unique identifier of the beneficiary</param>
        /// <returns>
        /// A list of UnivBeneficiaryAuthenticationResponse containing beneficiary details
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when uniqueId is null or empty</exception>
        Task<List<UnivBeneficiaryAuthenticationResponse>>
        GetBeneficiaryByUniqueIdAsync(string uniqueId);

        /// <summary>
        /// Retrieves college beneficiary authentication details using the provided HRMS ID.
        /// </summary>
        /// <param name="hrmsId">HRMS identifier of the beneficiary</param>
        /// <returns>
        /// A list of ClgBeneficiaryAuthenticationResponse containing beneficiary details
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when hrmsId is null or empty</exception>
        Task<List<ClgBeneficiaryAuthenticationResponse>>
        GetBeneficiaryByHrmsIdClgAsync(string hrmsId);

        /// <summary>
        /// Retrieves panchayat employee beneficiary authentication details using the provided IOSMS ID.
        /// </summary>
        /// <param name="iosmsId">IOSMS identifier of the beneficiary</param>
        /// <returns>
        /// A list of PnhytEmpBeneficiaryAuthenticationResponse containing beneficiary details
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when iosmsId is null or empty</exception>
        Task<List<PnhytEmpBeneficiaryAuthenticationResponse>>
        GetBeneficiaryByIosmsIdAsync(string iosmsId);

        /// <summary>
        /// Retrieves panchayat pension beneficiary authentication details using the provided application ID.
        /// </summary>
        /// <param name="appId">Application identifier of the beneficiary</param>
        /// <returns>
        /// A list of PnhytPenBeneficiaryAuthenticationResponse containing beneficiary details
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when appId is null or empty</exception>
        Task<List<PnhytPenBeneficiaryAuthenticationResponse>>
        GetBeneficiaryPnhytPenByAppIdAsync(string appId);

        /// <summary>
        /// Retrieves employee pension beneficiary authentication details using the provided application ID.
        /// </summary>
        /// <param name="appId">Application identifier of the beneficiary</param>
        /// <returns>
        /// A list of GovtEmpPenBeneficiaryAuthenticationResponse containing beneficiary details
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when appId is null or empty</exception>
        Task<List<GovtEmpPenBeneficiaryAuthenticationResponse>>
        GetBeneficiaryGovtEmpPenByAppIdAsync(string appId);
      
        /// <summary>
        /// Retrieves all beneficiary authentication details associated with the provided mobile number.
        /// </summary>
        /// <param name="mobNumber">Mobile number of the beneficiary</param>
        /// <returns>
        /// A list of AllBeneficiaryAuthenticationResponseByMobileNo containing beneficiary details
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when mobNumber is null, empty, or invalid</exception>
        Task<List<AllBeneficiaryAuthenticationResponseByMobileNo>>
        GetAllBeneficiaryByMobileAsync(string mobNumber);
    }
}