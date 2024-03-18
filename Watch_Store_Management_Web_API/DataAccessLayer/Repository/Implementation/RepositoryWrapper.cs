using Watch_Store_Management_Web_API.DataAccessLayer.Context;
using Watch_Store_Management_Web_API.DataAccessLayer.Repository.Interface;

namespace Watch_Store_Management_Web_API.DataAccessLayer.Repository.Implementation
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly WatchStoreDBContext watchStoreDBContext;
        public ICategoryRepository CategoryRepository { get; set; }
        public IRoleRepository RoleRepository { get; set; }
        public IBrandRepository BrandRepository { get; set; }
        public IAddressRepository AddressRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public ICartRepository CartRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        public ICartDetailRepository CartDetailRepository { get; set; }
        public IOrderDetailRepository OrderDetailRepository { get; set; }

        public RepositoryWrapper(WatchStoreDBContext watchStoreDBContext)
        {
            this.watchStoreDBContext = watchStoreDBContext;

            CategoryRepository = new CategoryRepository(watchStoreDBContext);
            RoleRepository = new RoleRepository(watchStoreDBContext);
            BrandRepository = new BrandRepository(watchStoreDBContext);
            AddressRepository = new AddressRepository(watchStoreDBContext);
            ProductRepository = new ProductRepository(watchStoreDBContext);
            UserRepository = new UserRepository(watchStoreDBContext);
            CartRepository = new CartRepository(watchStoreDBContext);
            CartDetailRepository = new CartDetailRepository(watchStoreDBContext);
            OrderRepository = new OrderRepository(watchStoreDBContext);
            OrderDetailRepository = new OrderDetailRepository(watchStoreDBContext);
        }

        public async Task<int> SaveAsync()
        {
            return await watchStoreDBContext.SaveChangesAsync();
        }
    }
}
