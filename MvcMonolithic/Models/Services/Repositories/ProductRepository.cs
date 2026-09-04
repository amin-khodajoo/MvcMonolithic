using Microsoft.EntityFrameworkCore;
using MvcMonolithic.Models.DomainModels.ProductAggregate;
using MvcMonolithic.Models.Services.Contracts;

namespace MvcMonolithic.Models.Services.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProjectDbContext _projectDbContext;

        public ProductRepository(ProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }

        public async Task<List<Product>> SelectAll()
        {
            try
            {
                return await _projectDbContext.Product.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
