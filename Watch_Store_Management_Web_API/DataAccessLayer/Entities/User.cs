using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Watch_Store_Management_Web_API.DataAccessLayer.Entities.Enums;

namespace Watch_Store_Management_Web_API.DataAccessLayer.Entities
{
    public partial class User
    {
        public User()
        {
            Addresses = new HashSet<Address>();
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        [EnumDataType(typeof(GenderEnum))]
        public GenderEnum? Gender { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public DateTime? Dob { get; set; }
        public string? PhoneNo { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
