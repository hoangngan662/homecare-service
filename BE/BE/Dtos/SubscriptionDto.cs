namespace BE.Dtos
{
    public class SubscriptionDto
    {
        public int Id { get; set; }
        public string PatientId { get; set; }
        public string PatientFullName { get; set; }
        public int? ServicePackageId { get; set; }
        public string? ServicePackageName { get; set; }
        public int ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
        public int UsedSessions { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }

        public decimal Total { get; set; } = 0;
        public bool IsPaid { get; set; } = false;
        public DateTime? PaymentDate { get; set; }
    }

}
