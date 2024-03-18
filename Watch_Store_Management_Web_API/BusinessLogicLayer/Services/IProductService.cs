using AutoMapper;
using Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Request;
using Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Response;
using Watch_Store_Management_Web_API.DataAccessLayer.Entities;
using Watch_Store_Management_Web_API.DataAccessLayer.Repository.Interface;

namespace Watch_Store_Management_Web_API.BusinessLogicLayer.Services
{
    public interface IProductService : IBaseService<ProductRequestDTO, ProductResponseDTO>
    {
    }
    public class ProductService : IProductService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public ProductService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }

        public async Task<ProductResponseDTO> Add(ProductRequestDTO requestDTO)
        {
            var product = mapper.Map<Product>(requestDTO);
            var productResponse = await this.repositoryWrapper.ProductRepository.CreateAsync(product);
            await this.repositoryWrapper.SaveAsync();
            var result = mapper.Map<ProductResponseDTO>(productResponse);
            return result;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductResponseDTO>> GetAll()
        {
            var products = await this.repositoryWrapper.ProductRepository.GetAllAsync("Category", "Brand");
            var result = mapper.Map<IEnumerable<ProductResponseDTO>>(products);
            return result;
        }

        public async Task<ProductResponseDTO?> GetById(int id)
        {
            var product = await this.repositoryWrapper.ProductRepository.GetById(id);
            if (product is null) return null;
            var result = mapper.Map<ProductResponseDTO>(product);
            return result;
        }

        public async Task<ProductResponseDTO?> Update(int id, ProductRequestDTO requestDTO)
        {
            var product = mapper.Map<Product>(requestDTO);
            product.Id = id;
            var productResponse = await this.repositoryWrapper.ProductRepository.UpdateAsync(id, product);
            if (productResponse is not null)
            {
                await this.repositoryWrapper.SaveAsync();
                return mapper.Map<ProductResponseDTO>(productResponse);
            }
            return null;
        }
    }
}
