using System.ComponentModel.DataAnnotations;

namespace Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Request
{
    public class CategoryRequestDTO
    {
        [StringLength(50)]
        [MinLength(1)]
        public string Name { get; set; } = null!;
    }
}
