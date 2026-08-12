using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using WBHealthScheme.Application.Dtos;
using WBHealthScheme.Application.Interfaces;
using WBHealthScheme.Infrastructure.Persistence;
using System.Globalization;

namespace WBHealthScheme.Infrastructure.Repositories
{
    public class CollegeRegistrationRepository
        : ICollegeRegistrationRepository
    {
        private readonly WBHSDbContext _context;

        public CollegeRegistrationRepository(
            WBHSDbContext context)
        {
            _context = context;
        }

        #region Get HRMS State

        public async Task<CheckHRMSDbResponse?>
        CheckHRMSAsync(
            CheckHRMSRequest request)
        {
            var hrmsParam =
                new SqlParameter(
                    "@hrms_id",
                    request.HRMSId);

            var result =
                await _context
                    .CheckHRMSDbResponses
                    .FromSqlRaw(
                        "EXEC GET_AVAILABILITY_MBUCT_HRMS_ID_ONLINE_CLG_BY_hrmsID @hrms_id",
                        hrmsParam)
                    .ToListAsync();

            return result.FirstOrDefault();
        }
        #endregion

        #region Save Registration

        public async Task<bool>
        SaveCollegeRegistrationAsync(
            SaveCollegeRegistrationRequest request,
            string slrNo,
            string appId,
            string createIp)
        {
            var parameters = new[]
            {
                new SqlParameter("@slr_no", slrNo),

                new SqlParameter(
                    "@hrms_id",
                    request.HRMSId),

                new SqlParameter(
                    "@app_id",
                    appId),

                new SqlParameter(
                    "@dob",
                    request.DOB.ToString("dd/MM/yyyy")),

                new SqlParameter(
                    "@IS_EXISTS",
                    "0"),

                new SqlParameter(
                    "@INVALID_TIME",
                    DBNull.Value),

                new SqlParameter(
                    "@CREATE_IP",
                    createIp)
            };

            var rowsAffected =
                await _context.Database
                    .ExecuteSqlRawAsync(
                        "EXEC INSERT_mbuct_appid_clg_online " +
                        "@slr_no," +
                        "@hrms_id," +
                        "@app_id," +
                        "@dob," +
                        "@IS_EXISTS," +
                        "@INVALID_TIME," +
                        "@CREATE_IP",
                        parameters);

            return rowsAffected > 0;
        }

        #endregion

        #region Get Dropdown of Personal

        public async Task<List<GenderDto>> GetGenderAsync()
        {
            return await _context.Genders
                .FromSqlRaw("EXEC GET_GENDER_WBHS")
                .ToListAsync();
        }
        public async Task<List<MaritalStatusDto>> GetMaritalStatusAsync()
        {
            return await _context.MaritalStatuses
                .FromSqlRaw("EXEC GET_MARITAL_STATUS_WBHS")
                .ToListAsync();
        }
        public async Task<List<DistrictDto>> GetDistrictAsync()
        {
            return await _context.Districts
                .FromSqlRaw("EXEC GET_MBUCT_District_list")
                .ToListAsync();
        }

        #endregion

        #region  Save Personal Data
        public async Task SavePersonalInformationAsync(
    SavePersonalInformationRequest request,
    DateTime retirementDate,
    string isExists)
        {
            var parameters = new[]
            {
        new SqlParameter("@slr_no", request.SlrNo),

        new SqlParameter("@app_id", request.AppId),

        new SqlParameter("@hrms_id", request.HrmsId),

        new SqlParameter("@clg_fnm", request.FirstName?.Trim().ToUpperInvariant()),

        new SqlParameter("@clg_lnm", request.LastName?.Trim().ToUpperInvariant()),

        new SqlParameter(
            "@clg_dob",
            DateTime.ParseExact(
            request.Dob!,
            "yyyy-MM-dd",
            CultureInfo.InvariantCulture
            ).ToString("dd/MM/yyyy")),

        new SqlParameter(
            "@redate",
            retirementDate.ToString("dd/MM/yyyy")),

        new SqlParameter(
            "@mt_stat",
            request.MaritalStatus),

        new SqlParameter(
            "@gen",
            request.Gender),

        new SqlParameter(
            "@dist_cd",
            request.DistrictCode),

        new SqlParameter(
            "@addr",request.Address?.Trim().ToUpperInvariant()),

        new SqlParameter(
            "@id_prf",
            request.IdentityProofNo),

        new SqlParameter(
            "@aadhaar_no",
            request.AadhaarNo),

        new SqlParameter(
            "@mob_no",
            request.MobileNo),

        new SqlParameter(
            "@email_id",
            request.EmailId),

        new SqlParameter(
            "@ph_no",
            string.IsNullOrWhiteSpace(
                request.ResidencePhoneNo)
                ? DBNull.Value
                : request.ResidencePhoneNo),

        new SqlParameter(
            "@retire_age_yr",
            request.RetirementAge),

        new SqlParameter(
            "@redate",
            retirementDate.ToString("dd/MM/yyyy")),

        new SqlParameter(
            "@bnk_ifsc",
            request.BankIfsc),

        new SqlParameter(
            "@bnk_nm",
            request.BankName),

        new SqlParameter(
            "@bnk_br_nm",
            request.BankBranchName),

        new SqlParameter(
            "@bnk_micr",
            request.BankMicr),

        new SqlParameter(
            "@bnk_acno",
            request.BankAccountNo),

        new SqlParameter(
            "@id_type",
            request.IdentityProofType),

        new SqlParameter(
            "@is_exists",
            isExists)
    };

            await _context.Database
                .ExecuteSqlRawAsync(
                    "EXEC INSERT_mbuct_clgBasicInfo_online " +
                    "@slr_no," +
                    "@app_id," +
                    "@hrms_id," +
                    "@clg_fnm," +
                    "@clg_lnm," +
                    "@clg_dob," +
                    "@mt_stat," +
                    "@gen," +
                    "@dist_cd," +
                    "@addr," +
                    "@id_prf," +
                    "@aadhaar_no," +
                    "@mob_no," +
                    "@email_id," +
                    "@ph_no," +
                    "@retire_age_yr," +
                    "@redate," +
                    "@bnk_ifsc," +
                    "@bnk_nm," +
                    "@bnk_br_nm," +
                    "@bnk_micr," +
                    "@bnk_acno," +
                    "@id_type," +
                    "@is_exists",
                    parameters);
        }
        #endregion

        #region Get Personal Data

        public async Task<ClgPersonalFetchResponse?>
    GetPersonalInformationAsync(
        ClgPersonalFetchRequest request)
{
    var parameters = new[]
    {
        new SqlParameter(
            "@app_id",
            request.AppId),

        new SqlParameter(
            "@hrms_id",
            request.HrmsId)
    };

    var result =
        await _context
            .ClgPersonalFetchResponses
            .FromSqlRaw(
                "EXEC GET_MBUCT_College_BasicInfo_Online_Existing " +
                "@app_id, " +
                "@hrms_id",
                parameters)
            .ToListAsync();

    return result.FirstOrDefault();
}

        #endregion

    }
}