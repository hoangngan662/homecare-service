namespace BE.Dtos
{
    public class RevenueStatisticsDto
    {
        public List<RevenueByServiceTypeDto> RevenueByServiceType { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
