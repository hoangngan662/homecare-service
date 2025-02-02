namespace BE.Dtos
{
    public class ServiceTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image {  get; set; }
        public decimal? SessionPrice { get; set; } = 0;
        public List<ServicePackageDto>? ServicePackages { get; set; }

    }
}
