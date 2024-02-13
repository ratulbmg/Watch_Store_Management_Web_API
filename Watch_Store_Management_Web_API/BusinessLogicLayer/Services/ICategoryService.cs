using AutoMapper;
using Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Request;
using Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Response;
using Watch_Store_Management_Web_API.DataAccessLayer.Entities;
using Watch_Store_Management_Web_API.DataAccessLayer.Repository.Interface;

namespace Watch_Store_Management_Web_API.BusinessLogicLayer.Services
{
    public interface ICategoryService : IBaseService<CategoryRequestDTO, CategoryResponseDTO>
    {
    }
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public CategoryService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }

        public async Task<CategoryResponseDTO> Add(CategoryRequestDTO requestDTO)
        {
            var category = mapper.Map<Category>(requestDTO);
            var categoryResponse = await this.repositoryWrapper.CategoryRepository.CreateAsync(category);
            await this.repositoryWrapper.SaveAsync();
            var result = mapper.Map<CategoryResponseDTO>(categoryResponse);
            return result;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoryResponseDTO>> GetAll()
        {
            var categoryes = await this.repositoryWrapper.CategoryRepository.GetAllAsync();
            var result = mapper.Map<IEnumerable<CategoryResponseDTO>>(categoryes);
            return result;
        }

        public Task<CategoryResponseDTO?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryResponseDTO?> Update(int id, CategoryRequestDTO requestDTO)
        {
            throw new NotImplementedException();
        }
    }
}
