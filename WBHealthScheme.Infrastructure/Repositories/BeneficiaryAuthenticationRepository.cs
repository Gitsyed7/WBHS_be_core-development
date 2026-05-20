using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using WBHealthScheme.Application.Dtos;
using WBHealthScheme.Application.Interfaces;
using WBHealthScheme.Infrastructure.Persistence;
using WBHealthScheme.Application.dtos;

namespace WBHealthScheme.Infrastructure.Repositories
{
    public class BeneficiaryAuthenticationRepository :
    IBeneficiaryAuthenticationRepository
    {
        private readonly WBHSDbContext _context;
        public BeneficiaryAuthenticationRepository(WBHSDbContext context)
        {
            _context = context;
        }
        
        // ------------------------------------------------------
        // For Authentication: Govt Emplyee, By HRMS ID
        // ------------------------------------------------------

        public async Task<List<BeneficiaryWardRespBroto>>
        GetWardByAppIdAsync(string app_ID)
        {            
            var param = new SqlParameter("@hrmsId", app_ID);
            var result = await _context.BenefWardDetails
                        .FromSqlRaw("EXEC GET_WBHS_BENEFICIARY_HRMSID @hrmsId", param)
                        .AsNoTracking()
                        .ToListAsync();
            return result;    
        }

        // ------------------------------------------------------
        // For Authentication: University, By Unique ID
        // ------------------------------------------------------

        public async Task<List<UnivBeneficiaryAuthenticationResponse>>
        GetBeneficiaryByUniqueIdAsync(string uniqueId)
        {
            return await _context.Set<UnivBeneficiaryAuthenticationResponse>()
        .FromSqlRaw("EXEC GetUnivBeneficiaryAuthenticationByUniqueId @uniqueId",
            new SqlParameter("@uniqueId", uniqueId))
        .ToListAsync();
        }       

        // ------------------------------------------------------
        // For Authentication: Collage, By HRMS ID
        // ------------------------------------------------------

        public async Task<List<ClgBeneficiaryAuthenticationResponse>>
        GetBeneficiaryByHrmsIdClgAsync(string hrmsId)
        {
            return await _context.Set<ClgBeneficiaryAuthenticationResponse>()
        .FromSqlRaw("EXEC GetClgBeneficiaryAuthenticationByHrmsId @hrmsId",
            new SqlParameter("@hrmsId", hrmsId))
        .ToListAsync();
        }

        // ------------------------------------------------------
        // For Authentication: Panchayat Emplyee, By IOSMS ID
        // ------------------------------------------------------

        public async Task<List<PnhytEmpBeneficiaryAuthenticationResponse>>
        GetBeneficiaryByIosmsIdAsync(string iosmsId)
        {
            return await _context.Set<PnhytEmpBeneficiaryAuthenticationResponse>()
        .FromSqlRaw("EXEC GetPnhytEmpBeneficiaryAuthenticationByIosmsId @iosmsId",
            new SqlParameter("@iosmsId", iosmsId))
        .ToListAsync();
        }

        // ------------------------------------------------------
        // For Authentication: Panchayat Pensioner, By Application ID
        // ------------------------------------------------------

        public async Task<List<PnhytPenBeneficiaryAuthenticationResponse>>
       GetBeneficiaryPnhytPenByAppIdAsync(string appId)
        {
            return await _context.Set<PnhytPenBeneficiaryAuthenticationResponse>()
        .FromSqlRaw("EXEC GetPnhytPenBeneficiaryAuthenticationByAppId @appId",
            new SqlParameter("@appId", appId))
        .ToListAsync();
        }

        // ------------------------------------------------------
        // For Authentication: Govt Emplyee Pensioner, By Application ID
        // ------------------------------------------------------
        
       public async Task<List<GovtEmpPenBeneficiaryAuthenticationResponse>> 
        GetBeneficiaryGovtEmpPenByAppIdAsync(string appId)
        {
             return await _context.Set<GovtEmpPenBeneficiaryAuthenticationResponse>()
        .FromSqlRaw("EXEC GetGovtEmpPenBeneficiaryAuthenticationByAppId @appId",
            new SqlParameter("@appId", appId))
        .ToListAsync();
        }

        // ------------------------------------------------------
        // For Authentication: For All Enrolled User, By Mobile No.
        // ------------------------------------------------------

        public async Task<List<AllBeneficiaryAuthenticationResponseByMobileNo>>
        GetAllBeneficiaryByMobileAsync(string mobNumber)
        {
            return await _context.Set<AllBeneficiaryAuthenticationResponseByMobileNo>()
        .FromSqlRaw("EXEC GetAllBeneficiaryAuthenticationByMobileNumber @mobileNo",
            new SqlParameter("@mobileNo", mobNumber))
        .ToListAsync();
        }

        
    }
}
