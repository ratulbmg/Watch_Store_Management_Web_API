namespace Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Response
{
    public class UserResponseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int? Gender { get; set; }
        public string? Email { get; set; }
        public DateTime? Dob { get; set; }
        public string? PhoneNo { get; set; }
        public string RoleName { get; set; }
    }
}
