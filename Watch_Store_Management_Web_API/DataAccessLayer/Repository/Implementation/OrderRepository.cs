using Microsoft.EntityFrameworkCore;
using Watch_Store_Management_Web_API.DataAccessLayer.Context;
using Watch_Store_Management_Web_API.DataAccessLayer.Entities;
using Watch_Store_Management_Web_API.DataAccessLayer.Repository.Interface;

namespace Watch_Store_Management_Web_API.DataAccessLayer.Repository.Implementation
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly WatchStoreDBContext watchStoreDBContext;
        public OrderRepository(WatchStoreDBContext watchStoreDBContext) : base(watchStoreDBContext)
        {
            this.watchStoreDBContext = watchStoreDBContext;
        }

        public Task<IEnumerable<Order>> GetOrders()
        {
            var result = this.watchStoreDBContext.Orders
                .Include(x => x.Address)
                .Include(x => x.OrderDetails)
                .ThenInclude(x => x.Product)
                .AsEnumerable();
            return Task.FromResult(result);
        }

        public Task<IEnumerable<Order>> GetOrdersById(int userId)
        {
            var result = this.watchStoreDBContext.Orders
                .Include(x => x.OrderDetails)
                .ThenInclude(x => x.Product)
                .Where(x => x.UserId == userId)
                .AsEnumerable();
            return Task.FromResult(result);
        }
    }
}
