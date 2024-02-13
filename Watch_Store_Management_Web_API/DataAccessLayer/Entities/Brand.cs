using System;
using System.Collections.Generic;

namespace Watch_Store_Management_Web_API.DataAccessLayer.Entities
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public int? Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
