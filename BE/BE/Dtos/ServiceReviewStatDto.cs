namespace BE.Dtos
{
    public class ServiceReviewStatDto
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int TotalReviews { get; set; }
        public List<int> StarCount { get; set; }
        public decimal AvgStar { get; set; }
    }
}
