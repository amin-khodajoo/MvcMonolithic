
using MvcMonolithic.ApplicationServices.Dtos;

namespace MvcMonolithic.ApplicationServices.Contracts
{
    public interface IProductApplicationService
    {
        Task<List<GetProductDto>> GetAllProduct();
        Task Post(PostProductDto postProductDto);
    }
}
