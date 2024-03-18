using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Login;
using Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Request;
using Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Response;
using Watch_Store_Management_Web_API.DataAccessLayer.Entities;
using Watch_Store_Management_Web_API.DataAccessLayer.Repository.Interface;

namespace Watch_Store_Management_Web_API.BusinessLogicLayer.Services
{
    public interface IUserService : IBaseService<UserRequestDTO, UserResponseDTO>
    {
        //UserResponseDTO ValidateUser(LoginRequestDTO loginRequestDTO);
    }

    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public UserService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }

        public async Task<UserResponseDTO> Add(UserRequestDTO requestDTO)
        {
            var user = mapper.Map<User>(requestDTO);
            //user.PasswordHash = new PasswordHasher<object?>().HashPassword(null, user.PasswordHash);
            var userResponse = await this.repositoryWrapper.UserRepository.CreateAsync(user);
            await this.repositoryWrapper.SaveAsync();
            var result = mapper.Map<UserResponseDTO>(userResponse);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await this.repositoryWrapper.UserRepository.DeleteAsync(id);
            await this.repositoryWrapper.SaveAsync();
            return result;
            // del will not work when any address is created so firstly we need to delete address data and all FR KEY data
            // Code need to be improved
        }

        public async Task<IEnumerable<UserResponseDTO>> GetAll()
        {
            var users = await this.repositoryWrapper.UserRepository.GetAllAsync("Role");
            var result = mapper.Map<IEnumerable<UserResponseDTO>>(users);
            return result;
        }

        public async Task<UserResponseDTO?> GetById(int id)
        {
            var user = await this.repositoryWrapper.UserRepository.GetById(id);
            if (user is null) return null;
            var result = mapper.Map<UserResponseDTO>(user);
            return result;
        }

        public async Task<UserResponseDTO?> Update(int id, UserRequestDTO requestDTO)
        {
            var user = mapper.Map<User>(requestDTO);
            user.Id = id;
            var userResponse = await this.repositoryWrapper.UserRepository.UpdateAsync(id, user);
            if (userResponse is not null)
            {
                await this.repositoryWrapper.SaveAsync();
                return mapper.Map<UserResponseDTO>(userResponse);
            }
            return null;
        }
    }
}
