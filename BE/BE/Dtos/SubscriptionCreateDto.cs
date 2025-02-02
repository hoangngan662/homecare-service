namespace BE.Dtos
{
    public class SubscriptionCreateDto
    {
        public string PatientId { get; set; }
        public int? ServicePackageId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
