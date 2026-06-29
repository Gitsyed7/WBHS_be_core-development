using WBHealthScheme.Application.Dtos;

namespace WBHealthScheme.Application.Interfaces
{
    public interface INewsService
    {
        Task<List<WbhsNewsDto>> GetNewsAsync();
    }
}