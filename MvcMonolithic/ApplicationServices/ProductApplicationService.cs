
using MvcMonolithic.ApplicationServices.Contracts;
using MvcMonolithic.ApplicationServices.Dtos;
using MvcMonolithic.Models.Services.Contracts;
using MvcMonolithic.Models.Services.Repositories;

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


        #region [- Put() -]
        public async Task Put(PutProductDto putProductDto)
        {
            var product = new Models.DomainModels.ProductAggregate.Product()
            {
                Id = putProductDto.Id,
                Name = putProductDto.Name,
                Price = putProductDto.Price,
                Stock = putProductDto.Stock,
            };
            await _productRepository.Edit(product);
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

        #region [- GetById() -]
        public async Task<PutProductDto?> GetById(int id)
        {
            var product = await _productRepository.SelectById(id);
            if (product == null)
            {
                return null;
            }

            var putProductDto = new PutProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
            }; 
            return putProductDto;

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
