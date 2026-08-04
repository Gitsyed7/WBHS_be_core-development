using WBHealthScheme.Application.Dtos;

namespace WBHealthScheme.Application.Interfaces
{
    public interface IIfscService
    {
        Task<IfscDbResponse?>
        GetIfscDetailsAsync
        (
        IfscRequest request
        );
    }
}