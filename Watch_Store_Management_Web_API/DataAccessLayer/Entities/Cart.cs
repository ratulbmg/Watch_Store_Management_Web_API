using System;
using System.Collections.Generic;

namespace Watch_Store_Management_Web_API.DataAccessLayer.Entities
{
    public partial class Cart
    {
        public Cart()
        {
            CartDetails = new HashSet<CartDetail>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<CartDetail> CartDetails { get; set; }
    }
}
