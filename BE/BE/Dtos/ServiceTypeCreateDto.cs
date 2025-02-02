namespace BE.Dtos
{
    public class ServiceTypeCreateDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public IFormFile? Image { get; set; } //image
    }
}
