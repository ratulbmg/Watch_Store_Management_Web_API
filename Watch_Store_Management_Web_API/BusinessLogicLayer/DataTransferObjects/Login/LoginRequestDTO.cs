using System.ComponentModel.DataAnnotations;

namespace Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Login
{
    public class LoginRequestDTO
    {
        [StringLength(50)]
        [Required]
        public string Username { get; set; } = null!;

        [StringLength(100)]
        [Required]
        public string Password { get; set; } = null!;
    }
}
