using MvcMonolithic.Models.DomainModels.ProductAggregate;

namespace MvcMonolithic.Models.Services.Contracts
{
    public interface IProductRepository
    {
        Task<List<Product>> SelectAll();
    }
}
