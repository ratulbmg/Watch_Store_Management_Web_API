using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Login;
using Watch_Store_Management_Web_API.DataAccessLayer.Entities;
using Watch_Store_Management_Web_API.DataAccessLayer.Repository.Interface;
using Watch_Store_Management_Web_API.Infrastructure;

namespace Watch_Store_Management_Web_API.BusinessLogicLayer.Services
{
    public interface IAuthService
    {
        Task<LoginResponseDTO?> IsValidUser(LoginRequestDTO loginRequestDTO);
    }

    public class AuthService : IAuthService
    {

        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public AuthService(IRepositoryWrapper repositoryWrapper, IConfiguration configuration, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.configuration = configuration;
            this.mapper = mapper;
        }


        public async Task<LoginResponseDTO?> IsValidUser(LoginRequestDTO loginRequestDTO)
        {
            var user = await this.repositoryWrapper.UserRepository.ValidateUser(loginRequestDTO.Username, loginRequestDTO.Password);
            if (user is not null)
            {
                var issuer = configuration["JWT:ValidIssuer"];
                var audience = configuration["JWT:ValidAudience"];
                var secret = configuration["JWT:Secret"];
                var token = JWT.GenerateToken(issuer, audience, user.Id.ToString(), user.UserName, user.Role.RoleName, secret);
                return new LoginResponseDTO
                {
                    RoleName = user.Role.RoleName,
                    UserName = user.UserName,
                    UserId = user.Id,
                    LoginToken = token
            };
            }
            return null;
        }
    }
}