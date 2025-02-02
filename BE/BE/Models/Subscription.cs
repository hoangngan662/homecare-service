using System.ComponentModel.DataAnnotations.Schema;

namespace BE.Models
{
    public enum SubscriptionStatus
    {
        Pending,
        Active,
        Completed,
        Cancelled
    }
    public class Subscription
    {
        public int Id { get; set; }
        public string PatientId { get; set; }
        public User? Patient { get; set; }
        public int? ServicePackageId { get; set; }
        public ServicePackage? ServicePackage { get; set; }
        public int UsedSessions { get; set; } = 0;        
        public DateTime SubscriptionDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public decimal Total { get; set; } = 0;
        public bool IsPaid { get; set; } = false;
        public DateTime? PaymentDate { get; set; }

        public SubscriptionStatus Status { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
    }



}
