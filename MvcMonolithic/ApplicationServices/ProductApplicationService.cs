
using MvcMonolithic.ApplicationServices.Contracts;
using MvcMonolithic.ApplicationServices.Dtos;
using MvcMonolithic.Models.Services.Contracts;

namespace MvcMonolithic.ApplicationServices
{
    public class ProductApplicationService : IProductApplicationService
    {
        private readonly IProductRepository _productRepository;

        public ProductApplicationService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<GetProductDto>> GetAllProduct()
        {
            var products = await _productRepository.SelectAll();
            var getProductDtos = new List<GetProductDto>();
            foreach (var item in products)
            {
                var getProductDto = new GetProductDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Stock = item.Stock,
                };
                getProductDtos.Add(getProductDto);

            }
            return getProductDtos;
        }
    }
}
