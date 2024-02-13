namespace Watch_Store_Management_Web_API.DataAccessLayer.Repository.Interface
{
    public interface IRepositoryWrapper
    {
        ICategoryRepository CategoryRepository { get; set; }
        IRoleRepository RoleRepository { get; set; }
        IBrandRepository BrandRepository { get; set; }
        IAddressRepository AddressRepository { get; set; }
        IProductRepository ProductRepository { get; set; }
        IUserRepository UserRepository { get; set; }
        ICartRepository CartRepository { get; set; }
        ICartDetailRepository CartDetailRepository { get; set; }
        IOrderRepository OrderRepository { get; set; }
        IOrderDetailRepository OrderDetailRepository { get; set; }


        Task<int> SaveAsync();
    }
}
