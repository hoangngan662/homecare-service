namespace BE.Models
{
    public class ServiceType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; } = true;
        public string? Image {  get; set; }
        public ICollection<ServicePackage>? ServicePackages { get; set; }
    }

}
