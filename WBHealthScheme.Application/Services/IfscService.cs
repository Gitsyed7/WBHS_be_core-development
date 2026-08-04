using WBHealthScheme.Application.Dtos;
using WBHealthScheme.Application.Interfaces;

namespace WBHealthScheme.Application.Services
{

public class IfscService : IIfscService
    {
        private readonly IIfscRepository _repository;
        public IfscService
        (
            IIfscRepository repository
        )
        {
            _repository=repository;
        }
        public async Task<IfscDbResponse?> GetIfscDetailsAsync(
            IfscRequest request)
        {
            return await _repository.GetIfscDetailsAsync(request);
        }
    }
}