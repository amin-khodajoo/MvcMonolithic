
using MvcMonolithic.ApplicationServices.Contracts;
using MvcMonolithic.ApplicationServices.Dtos;
using MvcMonolithic.Models.Services.Contracts;

namespace MvcMonolithic.ApplicationServices
{
    public class ProductApplicationService : IProductApplicationService
    {
        private readonly IProductRepository _productRepository;

        #region [- Ctor -]
        public ProductApplicationService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region [- Post() -]
        public async Task Post(PostProductDto postProductDto)
        {
            var product = new Models.DomainModels.ProductAggregate.Product()
            {
                Id = postProductDto.Id,
                Name = postProductDto.Name,
                Price = postProductDto.Price,
                Stock = postProductDto.Stock,
            };
           await _productRepository.Insert(product);
        }
        #endregion

        #region [- GetAllProduct() -]
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
        #endregion
    }
}
