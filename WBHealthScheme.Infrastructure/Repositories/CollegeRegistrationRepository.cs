using Microsoft.EntityFrameworkCore;
using WBHealthScheme.Application.Dtos;
using WBHealthScheme.Application.Interfaces;
using WBHealthScheme.Infrastructure.Persistence;

namespace WBHealthScheme.Infrastructure.Repositories
{
    public class CollegeRegistrationRepository : ICollegeRegistrationRepository
    {
        private readonly WBHSDbContext _context;

        public CollegeRegistrationRepository(WBHSDbContext context)
        {
            _context = context;
        }
        public async Task<CheckHRMSResponse>
CheckHRMSAsync
(
      CheckHRMSRequest request
)
{
      throw new NotImplementedException();
}

    }
}