using WBHealthScheme.Application.Dtos;
using WBHealthScheme.Application.Interfaces;

namespace WBHealthScheme.Application.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _repository;

        public NewsService(INewsRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<WbhsNewsDto>> GetNewsAsync()
        {
            var result = await _repository.GetNewsAsync();

            if (result == null || !result.Any())
                throw new Exception("No news found");

            return result;
        }
    }
}