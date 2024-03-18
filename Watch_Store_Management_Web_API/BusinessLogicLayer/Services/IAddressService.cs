using AutoMapper;
using Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Request;
using Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Response;
using Watch_Store_Management_Web_API.DataAccessLayer.Entities;
using Watch_Store_Management_Web_API.DataAccessLayer.Repository.Interface;

namespace Watch_Store_Management_Web_API.BusinessLogicLayer.Services
{
    public interface IAddressService : IBaseService<AddressRequestDTO, AddressResponseDTO>
    {
        Task<IEnumerable<AddressResponseDTO>> GetAddressByUserId(int id);
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

        public async Task<bool> Delete(int id)
        {
            var result = await this.repositoryWrapper.AddressRepository.DeleteAsync(id);
            await this.repositoryWrapper.SaveAsync();
            return result;
        }

        public async Task<IEnumerable<AddressResponseDTO>> GetAddressByUserId(int id)
        {
            var addresses = await this.repositoryWrapper.AddressRepository.GetByCondition(x => x.UserId == id);
            var result = mapper.Map<IEnumerable<AddressResponseDTO>>(addresses);
            return result;
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

        public async Task<AddressResponseDTO?> Update(int id, AddressRequestDTO requestDTO)
        {
            var address = mapper.Map<Address>(requestDTO);
            address.Id = id;
            var addressResponse = await this.repositoryWrapper.AddressRepository.UpdateAsync(id, address);
            if (addressResponse is not null)
            {
                await this.repositoryWrapper.SaveAsync();
                return mapper.Map<AddressResponseDTO>(addressResponse);
            }
            return null;
        }
    }
}
