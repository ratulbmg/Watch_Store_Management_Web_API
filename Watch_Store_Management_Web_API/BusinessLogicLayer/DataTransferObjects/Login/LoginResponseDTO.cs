namespace Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Login
{
    public class LoginResponseDTO
    {
        public string UserName { get; set; } = null!;
        public int UserId { get; set; }
        public string RoleName { get; set; } = null!;

        public string LoginToken { get; set; } = null!;
    }
}
