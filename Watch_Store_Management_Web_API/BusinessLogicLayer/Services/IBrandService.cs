using AutoMapper;
using Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Request;
using Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Response;
using Watch_Store_Management_Web_API.DataAccessLayer.Entities;
using Watch_Store_Management_Web_API.DataAccessLayer.Repository.Interface;

namespace Watch_Store_Management_Web_API.BusinessLogicLayer.Services
{
    public interface IBrandService : IBaseService<BrandRequestDTO, BrandResponseDTO>
    {
    }
    public class BrandService : IBrandService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public BrandService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }

        public async Task<BrandResponseDTO> Add(BrandRequestDTO requestDTO)
        {
            var brand = mapper.Map<Brand>(requestDTO);
            var brandResponse = await this.repositoryWrapper.BrandRepository.CreateAsync(brand);
            await this.repositoryWrapper.SaveAsync();
            var result = mapper.Map<BrandResponseDTO>(brandResponse);
            return result;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BrandResponseDTO>> GetAll()
        {
            var brands = await this.repositoryWrapper.BrandRepository.GetAllAsync();
            var result = mapper.Map<IEnumerable<BrandResponseDTO>>(brands);
            return result;
        }

        public Task<BrandResponseDTO?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BrandResponseDTO?> Update(int id, BrandRequestDTO requestDTO)
        {
            throw new NotImplementedException();
        }
    }
}
