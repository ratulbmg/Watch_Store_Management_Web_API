namespace Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Login
{
    public class LoginResponseDTO
    {
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string RoleName { get; set; }

        public string LoginToken { get; set; }
    }
}
