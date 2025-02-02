namespace BE.Dtos
{
    public class AnnualRevenueDto
    {
        public int Year { get; set; }
        public decimal TotalAnnualRevenue { get; set; }
        public List<MonthlyRevenueDto> MonthlyRevenues { get; set; }
    }
}
