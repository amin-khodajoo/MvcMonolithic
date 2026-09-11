using MvcMonolithic.Models.DomainModels.ProductAggregate;

namespace MvcMonolithic.Models.Services.Contracts
{
    public interface IProductRepository
    {
        Task<List<Product>> SelectAll();
        Task<Product?> SelectById(int id);
        Task Insert(Product product);
        Task Edit(Product product);
    }
}
