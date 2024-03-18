using System.ComponentModel.DataAnnotations;
using Watch_Store_Management_Web_API.DataAccessLayer.Entities.Enums;

namespace Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Response
{
    public class OrderResponseDTO
    {
        public int Id { get; set; }
        public string AddressName { get; set; } = null!;
        public double TotalAmount { get; set; }
        public string AddressCity { get; set; } = null!;
        public string AddressState { get; set; } = null!;
        public string AddressPincode { get; set; } = null!;

        public string AddressStreetAddress { get; set; } = null!;
        public string AddressLandmark { get; set; } = null!;

        [EnumDataType(typeof(OrderStatusEnum))]
        public string Status { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public List<OrderDetailResponseDTO> OrderDetails { get; set; } = null!;
    }

    public class OrderDetailResponseDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public string ProductImagePath { get; set; } = null!;
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
