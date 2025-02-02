namespace BE.Dtos
{
    public class ServicePackageCreateDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? NumberOfSessions { get; set; }
        public int? DurationInMonths { get; set; }
        public int ServiceTypeId { get; set; }
    }
}
