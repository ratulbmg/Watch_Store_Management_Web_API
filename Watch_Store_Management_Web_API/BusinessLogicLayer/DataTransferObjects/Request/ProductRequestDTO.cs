using System.ComponentModel.DataAnnotations;
using Watch_Store_Management_Web_API.DataAccessLayer.Entities;

namespace Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Request
{
    public class ProductRequestDTO
    {
        [StringLength(100)]
        [MinLength(2)]
        public string Name { get; set; } = null!;

        [Range(1, double.MaxValue)]
        public double Price { get; set; }

        [StringLength(2000)]
        [MinLength(10)]
        public string Description { get; set; } = null!;
        public int StockAvailable { get; set; }
        public string ImagePath { get; set; } = null!;
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
    }
}