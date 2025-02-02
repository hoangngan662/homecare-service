namespace BE.Models
{
    public class AppointmentReview
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        public int AppointmentRating { get; set; }
        public string AppointmentComment { get; set; }
        public int StaffRating { get; set; }
        public string StaffComment { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
