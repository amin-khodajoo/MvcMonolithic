using Microsoft.EntityFrameworkCore;
using MvcMonolithic.Models.DomainModels.ProductAggregate;
using MvcMonolithic.Models.Services.Contracts;

namespace MvcMonolithic.Models.Services.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProjectDbContext _projectDbContext;

        #region [- Ctor -]
        public ProductRepository(ProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }
        #endregion

        #region [- Insert() -]
        public async Task Insert(Product product)
        {
            try
            {
                _projectDbContext.Add(product);
                await _projectDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region [- Edit() -]
        public async Task Edit(Product product)
        {
            try
            {
                _projectDbContext.Update(product);
                await _projectDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region [- SelectAll() -]
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

        #endregion

        #region [- SelectById() -]
        public async Task<Product?> SelectById(int id)
        {
            try
            {
                return await _projectDbContext.Product.FindAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
