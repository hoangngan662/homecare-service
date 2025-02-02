namespace BE.Dtos
{
    public class ServicePackageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? NumberOfSessions { get; set; }
        public int? DurationInMonths { get; set; }
        public int ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
        public int? SubscriptionCount { get; set; } = 0;
    }
}
