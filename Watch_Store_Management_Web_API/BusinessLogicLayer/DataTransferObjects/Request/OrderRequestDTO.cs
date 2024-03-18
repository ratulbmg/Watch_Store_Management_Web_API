using System.ComponentModel.DataAnnotations;

namespace Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Request
{
    public class OrderRequestDTO
    {
        public List<OrderDetailsDTO> OrderDetails { get; set; } = null!;
        public int AddressId { get; set; }
    }
    public class OrderDetailsDTO
    {

        public int ProductId { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        public double Price { get; set; }

    }
}
