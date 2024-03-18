using System.ComponentModel.DataAnnotations;

namespace Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Request
{
    public class UserRequestDTO
    {
        public string FirstName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        [Range(1,3)]
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public DateTime? Dob { get; set; }
        public string? PhoneNo { get; set; }
        public int RoleId { get; set; }
    }
}
