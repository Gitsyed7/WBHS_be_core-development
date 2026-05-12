using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WBHealthScheme.Domain.Entities;

namespace WBHealthScheme.Application.Interfaces
{
    public interface IApiKeyRepository
    {        
        //Task<bool> IsValidApiKeyAsync(string apiKey, string endpoint);
        Task<ApiKey?> GetValidKeyAsync(string apiKey);
    }
}