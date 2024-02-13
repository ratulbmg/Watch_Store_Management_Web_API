using Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Response;
using Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Request;
using AutoMapper;
using Watch_Store_Management_Web_API.DataAccessLayer.Repository.Interface;

namespace Watch_Store_Management_Web_API.BusinessLogicLayer.Services
{
    public interface IRoleService : IBaseService<RoleRequestDTO,RoleResponseDTO>
    {
    }
    public class RoleService : IRoleService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public RoleService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }

        public Task<RoleResponseDTO> Add(RoleRequestDTO requestDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RoleResponseDTO>> GetAll()
        {
            var roles = await this.repositoryWrapper.RoleRepository.GetAllAsync();
            var result = mapper.Map<IEnumerable<RoleResponseDTO>>(roles);
            return result;
        }

        public async Task<RoleResponseDTO?> GetById(int id)
        {
            var role = await this.repositoryWrapper.RoleRepository.GetById(id);
            var result = mapper.Map<RoleResponseDTO>(role);
            return result;
        }

        public Task<RoleResponseDTO?> Update(int id, RoleRequestDTO requestDTO)
        {
            throw new NotImplementedException();
        }
    }
}
