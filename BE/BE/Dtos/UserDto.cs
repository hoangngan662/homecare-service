namespace BE.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DoB {  get; set; }
        public string? Specialization { get; set; }
        public DateTime? StartDate { get; set; }
        public IList<string> Roles { get; set; }
    }
}
