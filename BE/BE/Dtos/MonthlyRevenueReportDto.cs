namespace BE.Dtos
{
    public class MonthlyRevenueReportDto
    {
        public string ServiceName { get; set; }  // Tên loại dịch vụ
        public decimal Revenue { get; set; }  // Doanh thu
        public int RegistrationCount { get; set; }  // Số lượt đăng ký
        public int AppointmentCount { get; set; }  // Số buổi hẹn
    }
}
