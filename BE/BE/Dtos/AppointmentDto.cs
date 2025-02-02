using BE.Models;

namespace BE.Dtos
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public int SubscriptionId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public string? StaffId { get; set; }
        public string? StaffFullName { get; set; }
        public int? ShiftId { get; set; }
        public string? ShiftTime { get; set; }
        public string PatientId { get; set; }
        public string PatientFullName { get; set; }
        public int? ServicePackageId { get; set; }
        public string? ServicePackageName { get; set; }
        public int ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }

        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Note { get; set; }
        public AppointmentDetailDto? AppointmentDetailDto { get; set; }
        public AppointmentReviewDto? AppointmentReviewDto { get; set; }
    }
}
