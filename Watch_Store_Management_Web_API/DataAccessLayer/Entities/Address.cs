using System;
using System.Collections.Generic;

namespace Watch_Store_Management_Web_API.DataAccessLayer.Entities
{
    public partial class Address
    {
        public Address()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string MobileNo { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Pincode { get; set; } = null!;
        public string StreetAddress { get; set; } = null!;
        public string Landmark { get; set; } = null!;
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
