using System.ComponentModel.DataAnnotations.Schema;

namespace BE.Models
{
    public enum AppointmentStatus
    {
        Pending,
        Scheduled,
        Completed,
        Cancelled
    }

    public class Appointment
    {
        public int Id { get; set; }
        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int? ShiftId { get; set; }
        public Shift? Shift { get; set; }
        public AppointmentStatus Status { get; set; }
        public string? StaffId { get; set; }
        public User? Staff { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Note { get; set; }
        public AppointmentDetail? AppointmentDetail { get; set; }
        public AppointmentReview? AppointmentReview { get; set; }
    }


}
