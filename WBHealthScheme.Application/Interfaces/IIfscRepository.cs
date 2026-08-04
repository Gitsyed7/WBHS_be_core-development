using WBHealthScheme.Application.Dtos;

namespace WBHealthScheme.Application.Interfaces
{
    public interface IIfscRepository
    {
        Task<IfscDbResponse?>
        GetIfscDetailsAsync
        (
        IfscRequest request
        );
    }
}