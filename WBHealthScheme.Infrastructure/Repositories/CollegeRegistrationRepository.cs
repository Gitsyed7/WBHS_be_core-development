using Microsoft.EntityFrameworkCore;
using WBHealthScheme.Application.Dtos;
using WBHealthScheme.Application.Interfaces;
using WBHealthScheme.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;

namespace WBHealthScheme.Infrastructure.Repositories
{
    public class CollegeRegistrationRepository : ICollegeRegistrationRepository
    {
        private readonly WBHSDbContext _context;

        public CollegeRegistrationRepository(WBHSDbContext context)
        {
            _context = context;
        }
        public async Task<CheckHRMSDbResponse?>
CheckHRMSAsync(CheckHRMSRequest request)
{
    var hrmsParam =
      new SqlParameter
      (
            "@hrms_id",
            request.HRMSId
      );
      
      var result =
    await _context
        .CheckHRMSDbResponses
        .FromSqlRaw(
            "EXEC GET_AVAILABILITY_MBUCT_HRMS_ID_ONLINE_CLG_BY_hrmsID @hrms_id",
            hrmsParam)
        .ToListAsync();

var dbResult = result.FirstOrDefault();
return dbResult;
      //throw new NotImplementedException();
      //return new CheckHRMSResponse();
}
    }
}