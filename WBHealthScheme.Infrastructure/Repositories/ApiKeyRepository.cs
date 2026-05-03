using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WBHealthScheme.Application.Interfaces;
using WBHealthScheme.Infrastructure.Persistence;
using WBHealthScheme.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WBHealthScheme.Infrastructure.Repositories
{
    public class ApiKeyRepository : IApiKeyRepository
    {
         private readonly WBHSDbContext _context;
        public ApiKeyRepository(WBHSDbContext context)
        {
            _context = context;
        }
       public async Task<ApiKey?> GetValidKeyAsync(string apiKey, string endpoint)
{
    return await _context.ApiKeys
        .FirstOrDefaultAsync(x =>
            x.ApiKeyValue == apiKey &&
            endpoint.StartsWith(x.EndpointUrl) &&
            x.IsActive);
}
    }
}