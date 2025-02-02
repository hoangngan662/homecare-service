namespace BE.Dtos
{
    public class RevenueByServiceTypeDto
    {
        public int ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
        public decimal TotalRevenue { get; set; } = 0;
    }
}
