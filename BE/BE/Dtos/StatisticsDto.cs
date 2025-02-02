namespace BE.Dtos
{
    public class StatisticsDto
    {
        public int TotalPatients { get; set; } = 0;
        public int TotalStaffs { get; set; } = 0;
        public int TotalServices { get; set; } = 0;
        public int TotalServicePackages { get; set; } = 0;
        public int TotalSubscription { get; set; } = 0;
        public int TotalAppointments { get; set; } = 0;
        public decimal TotalRevenue { get; set; } = 0;
    }
}
