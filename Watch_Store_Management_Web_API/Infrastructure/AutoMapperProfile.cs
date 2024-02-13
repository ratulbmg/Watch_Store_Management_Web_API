using AutoMapper;
using Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Request;
using Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Response;
using Watch_Store_Management_Web_API.DataAccessLayer.Entities;

namespace Watch_Store_Management_Web_API.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductRequestDTO, Product>();
            CreateMap<Product, ProductResponseDTO>();

            CreateMap<CategoryRequestDTO, Category>();
            CreateMap<Category, CategoryResponseDTO>();

            CreateMap<BrandRequestDTO, Brand>();
            CreateMap<Brand, BrandResponseDTO>();

            CreateMap<AddressRequestDTO, Address>();
            CreateMap<Address, AddressResponseDTO>();

            CreateMap<RoleRequestDTO, Role>();
            CreateMap<Role, RoleResponseDTO>();

            CreateMap<UserRequestDTO, User>();
            CreateMap<User, UserResponseDTO>();
        }
    }
}
