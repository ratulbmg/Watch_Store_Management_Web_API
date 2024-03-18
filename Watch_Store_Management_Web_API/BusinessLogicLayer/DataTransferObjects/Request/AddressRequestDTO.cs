using System.ComponentModel.DataAnnotations;

namespace Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Request
{
    public class AddressRequestDTO
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        [MinLength(1)]
        public string Name { get; set; } = null!;
        [Required]
        [StringLength(10)]
        [MinLength(10)]
        public string MobileNo { get; set; } = null!;
        [Required]
        [StringLength(50)]
        [MinLength(1)]
        public string City { get; set; } = null!;
        [Required]
        [StringLength(200)]
        [MinLength(1)]
        public string State { get; set; } = null!;
        [Required]
        [StringLength(6)]
        [MinLength(1)]
        public string Pincode { get; set; } = null!;
        [Required]
        [StringLength(100)]
        [MinLength(1)]
        public string StreetAddress { get; set; } = null!;
        [Required]
        [StringLength(100)]
        [MinLength(1)]
        public string Landmark { get; set; } = null!;
    }
}
