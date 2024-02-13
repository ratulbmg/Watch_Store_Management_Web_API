namespace Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Request
{
    public class AddressRequestDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string MobileNo { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Pincode { get; set; } = null!;
        public string StreetAddress { get; set; } = null!;
        public string Landmark { get; set; } = null!;
    }
}
