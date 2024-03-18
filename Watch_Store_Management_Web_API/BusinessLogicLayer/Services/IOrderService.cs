using AutoMapper;
using Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Request;
using Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Response;
using Watch_Store_Management_Web_API.DataAccessLayer.Entities;
using Watch_Store_Management_Web_API.DataAccessLayer.Entities.Enums;
using Watch_Store_Management_Web_API.DataAccessLayer.Repository.Implementation;
using Watch_Store_Management_Web_API.DataAccessLayer.Repository.Interface;

namespace Watch_Store_Management_Web_API.BusinessLogicLayer.Services
{
    public interface IOrderService : IBaseService<OrderRequestDTO, OrderResponseDTO>
    {
        Task<OrderResponseDTO> Add(int id, OrderRequestDTO requestDTO);
        Task<IEnumerable<OrderResponseDTO?>> GetOrderById(int usetId);
        Task<OrderResponseDTO?> Update(int id, int status);
    }

    public class OrderService : IOrderService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;
        public OrderService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }
        public Task<OrderResponseDTO> Add(OrderRequestDTO requestDTO)
        {
            throw new NotImplementedException();
        }
        public async Task<OrderResponseDTO> Add(int id, OrderRequestDTO requestDTO)
        {
            foreach (var orderDetail in requestDTO.OrderDetails)
            {
                var product = await this.repositoryWrapper.ProductRepository.GetById(orderDetail.ProductId);
                if (product is not null)
                {
                    product.StockAvailable -= orderDetail.Quantity;  // manage product stock for order
                    var price = product.Price * orderDetail.Quantity;
                    orderDetail.Price = price;
                }
            }
            var order = new Order
            {
                AddressId = requestDTO.AddressId,
                UserId = id,
                CreatedAt = DateTime.Now,
                OrderDetails = requestDTO.OrderDetails
                    .Select(x => new OrderDetail { ProductId = x.ProductId, Quantity = x.Quantity, Price = x.Price })
                    .ToList(),
                Status = (int)OrderStatusEnum.PENDING,
                TotalAmount = requestDTO.OrderDetails.Sum(x => x.Price)
            };
            var result = await this.repositoryWrapper.OrderRepository.CreateAsync(order);
            await this.repositoryWrapper.SaveAsync();
            var orderFromDB = (await this.repositoryWrapper.OrderRepository.GetAllAsync("Address", "OrderDetails"))
                    .SingleOrDefault(x => x.Id == result.Id);
            var orderResponse = mapper.Map<OrderResponseDTO>(orderFromDB);
            return orderResponse;
        }
        public async Task<bool> Delete(int id)
        {
            var orderDetails = await this.repositoryWrapper.OrderDetailRepository.GetAllAsync();
            foreach (var orderDetail in orderDetails.Where(x => x.OrderId == id))
            {
                await this.repositoryWrapper.OrderDetailRepository.DeleteAsync(orderDetail.Id);
            }
            var result = await this.repositoryWrapper.OrderRepository.DeleteAsync(id);
            await this.repositoryWrapper.SaveAsync();
            return result;

        }

        public async Task<IEnumerable<OrderResponseDTO>> GetAll()
        {
            var orders = await this.repositoryWrapper.OrderRepository.GetOrders();
            var result = mapper.Map<IEnumerable<OrderResponseDTO>>(orders);
            return result;
        }

        public Task<OrderResponseDTO?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderResponseDTO?>> GetOrderById(int userId)
        {
            var order = await this.repositoryWrapper.OrderRepository.GetOrdersById(userId);
            var result = mapper.Map<IEnumerable<OrderResponseDTO>>(order);
            return result;
        }

        public Task<OrderResponseDTO?> Update(int id, OrderRequestDTO requestDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderResponseDTO?> Update(int id, int status)
        {
            var orderFromDb = (await this.repositoryWrapper.OrderRepository.GetAllAsync("Address", "OrderDetails"))
                    .SingleOrDefault(x => x.Id == id);
            if (orderFromDb is not null)
            {
                orderFromDb.Status = (OrderStatusEnum)status;
                var orderResponse = await this.repositoryWrapper.OrderRepository.UpdateAsync(id, orderFromDb);
                await this.repositoryWrapper.SaveAsync();
                var result = mapper.Map<OrderResponseDTO>(orderFromDb);
                return result;
            }
            return null;
        }
    }
}
