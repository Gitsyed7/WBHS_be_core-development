using WBHealthScheme.Application.Interfaces;
using WBHealthScheme.Domain.Entities;

public class ApiKeyService : IApiKeyService
{
    private readonly IApiKeyRepository _repository;

    public ApiKeyService(IApiKeyRepository repository)
    {
        _repository = repository;
    }

    public async Task<ApiKey?> GetValidKeyAsync(string apiKey, string endpoint)
{
    return await _repository.GetValidKeyAsync(apiKey, endpoint);
}
}