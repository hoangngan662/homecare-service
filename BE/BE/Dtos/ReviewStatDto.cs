namespace BE.Dtos
{
    public class ReviewStatDto
    {
        public int TotalReviews { get; set; }
        public List<int> StarCount { get; set; }
        public decimal AvgStar { get; set; }

        public List<int> StaffStarCount { get; set; }
        public decimal StaffAvgStar { get; set; }

    }
}
