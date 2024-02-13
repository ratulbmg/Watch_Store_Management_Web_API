using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Response
{
    public class ProductResponseDTO
    {
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public string Description { get; set; } = null!;
        public int StockAvailable { get; set; }
        public string ImagePath { get; set; } = null!;
        public int CategoryId { get; set; }

        [JsonPropertyName("Category_Name")]
        public string CategoryName { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
