using System.ComponentModel.DataAnnotations;
using Watch_Store_Management_Web_API.DataAccessLayer.Entities.Enums;

namespace Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Response
{
    public class UserResponseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        [EnumDataType(typeof(OrderStatusEnum))]
        public string Gender { get; set; } = null!;
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public DateTime? Dob { get; set; }
        public string? PhoneNo { get; set; }

        public int RoleId { get; set; }
        public string RoleRoleName { get; set; } = null!;
    }
}
