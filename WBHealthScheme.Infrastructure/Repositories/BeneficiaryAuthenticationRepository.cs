using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using WBHealthScheme.Application.Dtos;
using WBHealthScheme.Application.Interfaces;
using WBHealthScheme.Infrastructure.Persistence;
//using Microsoft.Data.SqlClient;

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
        public async Task<List<BeneficiaryAuthenticationResponse>>
        GetBeneficiaryByMobileAsync(string mobileNumber)
        {
            var selfData = await _context.EmployeeBasicInfos
            .Where(x => x.MobileNo == mobileNumber)
            .Select(x => new BeneficiaryAuthenticationResponse
            {
                ApplicationId = x.AppId,
                EmployeeId = x.EmpId,
                BeneficiaryId = x.EmpId,
                BeneficiaryName = (x.EmpFirstName ?? "") + " " +
(x.EmpLastName ?? ""),
                MobileNumber = x.MobileNo,
                DateOfBirth = x.EmpDob,
                MemberType = "SELF",
                Relation = "Self",
                RegistrationStatus = x.IsExists,
                ValidUpto = null,
                BloodGroup = null,
                PhotoPath = null
            })
.ToListAsync();
            var familyData = await (from family in _context.EmployeeFamilyMembers
                                    join photo in _context.WbhsFamilyPhotoSignatures
                                    on new { family.AppId, family.IdNo } equals new { photo.AppId, photo.IdNo }
                                    into photoJoin
                                    from photo in photoJoin.DefaultIfEmpty()
                                    where family.MobileNo == mobileNumber
                                    select new BeneficiaryAuthenticationResponse
                                    {
                                        ApplicationId = family.AppId,
                                        EmployeeId = null,
                                        BeneficiaryId = family.IdNo,
                                        BeneficiaryName = family.Name,
                                        MobileNumber = family.MobileNo,
                                        DateOfBirth = family.Dob,
                                        MemberType = "FAMILY",
                                        Relation = family.MemberCode,
                                        RegistrationStatus = family.IsExists,
                                        ValidUpto = family.ValidUpTo,
                                        BloodGroup = family.BloodGroup,
                                        PhotoPath = photo != null ? photo.PhotoFtp : null
                                    }).ToListAsync();

            return selfData.Concat(familyData).ToList();
        }

        public async Task<List<Beneiciary_ward_resp_broto>>
        GetwardByappAsync(string app_ID)
        {
            //var ward = await _context.EmployeeBasicInfos.Where(Y => Y.HrmsId == app_ID).
            //Select(Y => new Beneiciary_ward_resp_broto
            //{
            //wardtmc="TATA-"+x.WardTmc + ",GOVT-" + x.WardGovt + "PRIVATE-" + x.WardName
            //wardtmc = "Tata Medical Center-" + Y.WardTmc,
            //wardgovt = "Government Hospital-" + Y.WardGovt,
            //wardname = "Other Private Empanelled Hospital-" + Y.WardName,
            //}
            //).ToListAsync();
            //return ward.ToList();
            var param = new SqlParameter("@BEN_HRMS_D", app_ID);
            var result = await _context.BenefWardDetails
                        .FromSqlRaw("EXEC GET_WBHS_BENEFICIARY_HRMSID @BEN_HRMS_D", param)
                        .AsNoTracking()
                        .ToListAsync();
            return result;
    
        }

        public async Task<List<UnivBeneficiaryAuthenticationResponse>>
        GetBeneficiaryByUniqueIdAsync(string uniqueId)
        {
            return await _context.Set<UnivBeneficiaryAuthenticationResponse>()
        .FromSqlRaw("EXEC GetUnivBeneficiaryAuthenticationByUniqueId @uniqueId",
            new SqlParameter("@uniqueId", uniqueId))
        .ToListAsync();
        }        

        public async Task<List<ClgBeneficiaryAuthenticationResponse>>
        GetBeneficiaryByHrmsIdClgAsync(string hrmsId)
        {
            return await _context.Set<ClgBeneficiaryAuthenticationResponse>()
        .FromSqlRaw("EXEC GetClgBeneficiaryAuthenticationByHrmsId @hrmsId",
            new SqlParameter("@hrmsId", hrmsId))
        .ToListAsync();
        }

        public async Task<List<PnhytEmpBeneficiaryAuthenticationResponse>>
        GetBeneficiaryByIosmsIdAsync(string iosmsId)
        {
            return await _context.Set<PnhytEmpBeneficiaryAuthenticationResponse>()
        .FromSqlRaw("EXEC GetPnhytEmpBeneficiaryAuthenticationByIosmsId @iosmsId",
            new SqlParameter("@iosmsId", iosmsId))
        .ToListAsync();
        }

         public async Task<List<PnhytPenBeneficiaryAuthenticationResponse>>
        GetBeneficiaryPnhytPenByAppIdAsync(string appId)
        {
            return await _context.Set<PnhytPenBeneficiaryAuthenticationResponse>()
        .FromSqlRaw("EXEC GetPnhytPenBeneficiaryAuthenticationByAppId @appId",
            new SqlParameter("@appId", appId))
        .ToListAsync();
        }
    }
}
