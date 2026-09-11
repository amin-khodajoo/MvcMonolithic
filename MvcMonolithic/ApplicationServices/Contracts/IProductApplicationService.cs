
using MvcMonolithic.ApplicationServices.Dtos;

namespace MvcMonolithic.ApplicationServices.Contracts
{
    public interface IProductApplicationService
    {
        Task<List<GetProductDto>> GetAllProduct();
        Task<PutProductDto?> GetById(int id);
        Task Post(PostProductDto postProductDto);
        Task Put(PutProductDto putProductDto);
    }
}
