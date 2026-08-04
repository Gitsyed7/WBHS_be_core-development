using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using WBHealthScheme.Application.Dtos;
using WBHealthScheme.Application.Interfaces;
using WBHealthScheme.Infrastructure.Persistence;

namespace WBHealthScheme.Infrastructure.Repositories
{
    public class IfscRepository
        : IIfscRepository
    {
        private readonly WBHSDbContext _context;

        public IfscRepository(
            WBHSDbContext context)
        {
            _context = context;
        }

        public async Task<IfscDbResponse?>

        GetIfscDetailsAsync(
            IfscRequest request)
        {
            var ifscParam =
                new SqlParameter(
                    "@IFSC",
                    request.IFSC);

            var result =
                await _context
                    .IfscDetails
                    .FromSqlRaw(
                        "EXEC GET_BANK_DETAILS_BY_IFSC @IFSC",
                        ifscParam)
                    .ToListAsync();

            return result.FirstOrDefault();
        }
    }
}