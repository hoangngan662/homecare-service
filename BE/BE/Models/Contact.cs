namespace BE.Models
{
    public enum ContactStatus
    {
        Pending,
        Completed
    }
    public class Contact
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string PhoneNumber { get; set; }
        public string Service { get; set; }
        public string Message { get; set; }
        public DateTime InquiryDate { get; set; }
        public ContactStatus Status { get; set; }
        public string? Note { get; set; }

    }
}
