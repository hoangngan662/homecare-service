namespace BE.Dtos
{
    public class StaffReviewDto
    {
        public string StaffId { get; set; }
        public int TotalReviews { get; set; }
        public List<int> StarCount { get; set; }
        public decimal AvgStar { get; set; }
        public List<AppointmentReviewDto> AppointmentReviews { get; set; }
    }
}
