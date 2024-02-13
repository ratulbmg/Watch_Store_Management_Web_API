using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Watch_Store_Management_Web_API.DataAccessLayer.Entities.Enums;

namespace Watch_Store_Management_Web_API.DataAccessLayer.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public double TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }

        [EnumDataType(typeof(OrderStatusEnum))]
        public OrderStatusEnum Status { get; set; }
        public int AddressId { get; set; }

        public virtual Address Address { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
