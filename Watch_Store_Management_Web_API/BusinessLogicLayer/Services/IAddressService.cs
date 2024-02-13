using AutoMapper;
using Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Request;
using Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Response;
using Watch_Store_Management_Web_API.DataAccessLayer.Entities;
using Watch_Store_Management_Web_API.DataAccessLayer.Repository.Interface;

namespace Watch_Store_Management_Web_API.BusinessLogicLayer.Services
{
    public interface IAddressService : IBaseService<AddressRequestDTO, AddressResponseDTO>
    {
    }

    public class AddressService : IAddressService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public AddressService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }

        public async Task<AddressResponseDTO> Add(AddressRequestDTO requestDTO)
        {
            var address = mapper.Map<Address>(requestDTO);
            var responseAddress = await this.repositoryWrapper.AddressRepository.CreateAsync(address);
            await this.repositoryWrapper.SaveAsync();
            var result = mapper.Map<AddressResponseDTO>(responseAddress);
            return result;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AddressResponseDTO>> GetAll()
        {
            var addresses = await this.repositoryWrapper.AddressRepository.GetAllAsync();
            var result = mapper.Map<IEnumerable<AddressResponseDTO>>(addresses);
            return result;
        }

        public Task<AddressResponseDTO?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AddressResponseDTO?> Update(int id, AddressRequestDTO requestDTO)
        {
            throw new NotImplementedException();
        }
    }
}
