using Watch_Store_Management_Web_API.DataAccessLayer.Entities;

namespace Watch_Store_Management_Web_API.DataAccessLayer.Repository.Interface
{

    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<IEnumerable<Order>> GetOrdersById(int userId);
    }
}
