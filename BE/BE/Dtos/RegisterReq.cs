namespace BE.Dtos
{
    public class RegisterReq
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public DateTime DoB { get; set; } = DateTime.MinValue;
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string[] Roles { get; set; }
    }
}
