using BE.Models;

namespace BE.Dtos
{
    public class AppointmentReviewDto
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public int AppointmentRating { get; set; }
        public string AppointmentComment { get; set; }
        public int StaffRating { get; set; }
        public string StaffComment { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
