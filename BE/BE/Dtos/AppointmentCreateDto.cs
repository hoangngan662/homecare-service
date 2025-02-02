using BE.Models;

namespace BE.Dtos
{
    public class AppointmentCreateDto
    {
        public int SubscriptionId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string? StaffId { get; set; }
        public int? ShiftId { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Note { get; set; }
        public AppointmentStatus? Status { get; set; } = AppointmentStatus.Pending;
    }
}
