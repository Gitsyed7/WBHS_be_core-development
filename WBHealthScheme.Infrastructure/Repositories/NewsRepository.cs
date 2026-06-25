using Microsoft.EntityFrameworkCore;
using WBHealthScheme.Application.Dtos;
using WBHealthScheme.Application.Interfaces;
using WBHealthScheme.Infrastructure.Persistence;

namespace WBHealthScheme.Infrastructure.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly WBHSDbContext _context;

        public NewsRepository(WBHSDbContext context)
        {
            _context = context;
        }

        public async Task<List<WbhsNewsDto>> GetNewsAsync()
        {
            return await _context.WbhsNews
                .OrderByDescending(x => x.OrderDate)
                .Select(x => new WbhsNewsDto
                {
                    Title = x.Title,
                    Description = x.Description,
                    FilePath = x.FilePath
                })
                .ToListAsync();
        }
    }
}