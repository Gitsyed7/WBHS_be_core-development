using WBHealthScheme.Application.Dtos;

namespace WBHealthScheme.Application.Interfaces
{
    public interface INewsRepository
    {
        Task<List<WbhsNewsDto>> GetNewsAsync();
    }
}