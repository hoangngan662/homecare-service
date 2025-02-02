namespace BE.Dtos
{
    public class UserCreateDto
    {
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public DateTime DoB { get; set; }
        public string? Specialization { get; set; }
        public DateTime? StartDate { get; set; }
        public string[] Roles { get; set; }
        
    }
}
