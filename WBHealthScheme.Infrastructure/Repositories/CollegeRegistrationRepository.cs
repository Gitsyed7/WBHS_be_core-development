using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using WBHealthScheme.Application.Dtos;
using WBHealthScheme.Application.Interfaces;
using WBHealthScheme.Infrastructure.Persistence;

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
    }
}