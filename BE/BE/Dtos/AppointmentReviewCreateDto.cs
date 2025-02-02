namespace BE.Dtos
{
    public class AppointmentReviewCreateDto
    {
        public int AppointmentId { get; set; }
        public int AppointmentRating { get; set; }
        public string AppointmentComment { get; set; }
        public int StaffRating { get; set; }
        public string StaffComment { get; set; }
    }
}
