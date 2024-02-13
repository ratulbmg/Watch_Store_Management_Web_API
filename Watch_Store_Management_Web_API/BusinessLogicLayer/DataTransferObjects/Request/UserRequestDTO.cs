namespace Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Request
{
    public class UserRequestDTO
    {
        public string FirstName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int? Gender { get; set; }
        public string? Email { get; set; }
        public string PasswordHash { get; set; } = null!;
        public DateTime? Dob { get; set; }
        public string? PhoneNo { get; set; }
        public int RoleId { get; set; }
    }
}
