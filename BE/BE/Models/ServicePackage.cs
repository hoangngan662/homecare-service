namespace BE.Models
{
    public class ServicePackage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? NumberOfSessions { get; set; }
        public int? DurationInMonths { get; set; }
        public bool? IsActive { get; set; } = true;
        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }
        public ICollection<Subscription>? Subscriptions { get; set; }
    }


}
