using BE.Data;
using BE.Dtos;
using BE.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace BE.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly AppDbContext _context;
        public ReportRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<MonthlyRevenueReportDto>> GetMonthlyRevenueReportAsync(int month, int year)
        {
            // Lấy tất cả các loại dịch vụ
            var allServices = await _context.ServiceTypes.ToListAsync();

            // Lấy doanh thu cho từng dịch vụ trong tháng/năm cụ thể
            var monthlyRevenueReport = await _context.Subscriptions
                .Where(s => s.IsPaid && s.StartDate.Month == month && s.StartDate.Year == year)
                .GroupBy(s => s.ServicePackage.ServiceTypeId)
                .Select(g => new MonthlyRevenueReportDto
                {
                    ServiceName = g.FirstOrDefault().ServicePackage.ServiceType.Name,
                    Revenue = g.Sum(s => s.Total),
                    RegistrationCount = g.Count(),
                    AppointmentCount = g.Sum(s => s.Appointments.Count)
                })
                .ToListAsync();

            // Tạo danh sách báo cáo cho tất cả dịch vụ
            var report = allServices.Select(service =>
            {
                // Lấy báo cáo cho dịch vụ này nếu có, nếu không thì gán giá trị mặc định là 0
                var serviceReport = monthlyRevenueReport.FirstOrDefault(r => r.ServiceName == service.Name);
                return new MonthlyRevenueReportDto
                {
                    ServiceName = service.Name,
                    Revenue = serviceReport?.Revenue ?? 0,
                    RegistrationCount = serviceReport?.RegistrationCount ?? 0,
                    AppointmentCount = serviceReport?.AppointmentCount ?? 0
                };
            }).ToList();

            return report;
        }


        public async Task<FileResult> ExportMonthlyRevenueReportToExcel(int month, int year)
        {
            var report = await GetMonthlyRevenueReportAsync(month, year);

            if (report == null || !report.Any())
            {
                return null; // Nếu không có dữ liệu báo cáo, trả về null
            }

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add($"Revenue_{month:D2}/{year}");

                // Thêm tiêu đề báo cáo
                worksheet.Cells[1, 1].Value = $"BÁO CÁO DOANH THU THÁNG {month:D2}/{year}";
                worksheet.Cells[1, 1, 1, 5].Merge = true;
                worksheet.Cells[1, 1, 1, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, 1, 1, 5].Style.Font.Bold = true;
                worksheet.Cells[1, 1, 1, 5].Style.Font.Size = 14;

                // Thêm thông tin tháng, năm và ngày xuất báo cáo
                worksheet.Cells[2, 1].Value = $"Tháng: {month} - Năm: {year}";
                worksheet.Cells[2, 1, 2, 5].Merge = true;
                worksheet.Cells[2, 1, 2, 5].Style.Font.Bold = true;       
                worksheet.Cells[3, 1].Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy}";
                worksheet.Cells[3, 1, 3, 5].Merge = true;
                worksheet.Cells[3, 1, 3, 5].Style.Font.Bold = true;

                // Tiêu đề các cột
                worksheet.Cells[9, 1].Value = "STT";
                worksheet.Cells[9, 2].Value = "Tên Dịch Vụ";
                worksheet.Cells[9, 3].Value = "Doanh Thu (VNĐ)";
                worksheet.Cells[9, 4].Value = "Số Lượt Đăng Ký";
                worksheet.Cells[9, 5].Value = "Số Buổi Hẹn";

                worksheet.Cells[9, 1, 9, 5].Style.Font.Bold = true;

                // Dữ liệu báo cáo
                decimal totalRevenue = 0; // Tổng doanh thu
                decimal totalSubscription = 0;
                decimal totalAppointment = 0;
                var row = 10;
                foreach (var item in report)
                {
                    worksheet.Cells[row, 1].Value = row - 9; // Số thứ tự
                    worksheet.Cells[row, 2].Value = item.ServiceName;
                    worksheet.Cells[row, 3].Value = item.Revenue;
                    worksheet.Cells[row, 4].Value = item.RegistrationCount;
                    worksheet.Cells[row, 5].Value = item.AppointmentCount;

                    worksheet.Cells[row, 3].Style.Numberformat.Format = "#,##0";

                    totalRevenue += item.Revenue;
                    totalSubscription += item.RegistrationCount;
                    totalAppointment += item.AppointmentCount;
                    row++;
                }

                // Thêm tổng doanh thu vào cuối bảng
                worksheet.Cells[5, 1].Value = "TỔNG DOANH THU";
                worksheet.Cells[5, 2].Value = totalRevenue;
                worksheet.Cells[5, 2].Style.Numberformat.Format = "#,##0";
                worksheet.Cells[5, 1, 5, 2].Style.Font.Bold = true;

                worksheet.Cells[6, 1].Value = "TỔNG SỐ LƯỢT ĐĂNG KÝ";
                worksheet.Cells[6, 2].Value = totalSubscription;
                worksheet.Cells[6, 1, 6, 2].Style.Font.Bold = true;


                worksheet.Cells[7, 1].Value = "TỔNG SỐ BUỔI HẸN";
                worksheet.Cells[7, 2].Value = totalAppointment;
                worksheet.Cells[7, 1, 7, 2].Style.Font.Bold = true;

                worksheet.Cells[1, 1, 7, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[9, 1, 100, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // Tự động điều chỉnh độ rộng các cột
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Tạo tên file báo cáo
                var fileName = $"Revenue_{month:D2}-{year}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "report", "revenue", fileName);
                var fileInfo = new FileInfo(filePath);

                // Lưu file Excel vào đĩa
                await package.SaveAsAsync(fileInfo);

                // Đọc nội dung file và trả về cho client
                return new FileContentResult(await System.IO.File.ReadAllBytesAsync(filePath), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    FileDownloadName = fileName
                };
            }
        }

        public async Task<FileResult> ExportYearlyRevenueReportToExcel(int year)
        {
            using (var package = new ExcelPackage())
            {
                var summarySheet = package.Workbook.Worksheets.Add("Summary");

                // Get monthly reports for the entire year (12 months)
                decimal yearlyRevenue = 0;
                decimal yearlySubscriptions = 0;
                decimal yearlyAppointments = 0;
                decimal[] monthlyRevenues = new decimal[12];
                int[] monthlySubs = new int[12];
                int[] monthlyApp = new int[12];
                var monthlyReports = new List<List<MonthlyRevenueReportDto>>();

                // Loop through all 12 months to get the reports
                for (int month = 1; month <= 12; month++)
                {
                    var monthlyReport = await GetMonthlyRevenueReportAsync(month, year);
                    monthlyReports.Add(monthlyReport);

                    // Calculate totals for the entire year and monthly revenues
                    foreach (var item in monthlyReport)
                    {
                        yearlyRevenue += item.Revenue;
                        yearlySubscriptions += item.RegistrationCount;
                        yearlyAppointments += item.AppointmentCount;
                    }

                    // Save the total revenue for each month
                    monthlyRevenues[month - 1] = monthlyReport.Sum(x => x.Revenue);
                    monthlySubs[month - 1] = monthlyReport.Sum(x => x.RegistrationCount);
                    monthlyApp[month - 1] = monthlyReport.Sum(x => x.AppointmentCount);
                }

                // Add overall summary to the first sheet
                summarySheet.Cells[1, 1].Value = $"BÁO CÁO DOANH THU NĂM {year}";
                summarySheet.Cells[1, 1, 1, 4].Merge = true; // Merge cells for the title
                summarySheet.Cells[1, 1, 1, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                summarySheet.Cells[1, 1, 1, 4].Style.Font.Bold = true;
                summarySheet.Cells[1, 1, 1, 4].Style.Font.Size = 14;

                // Display year and report date below the title
                summarySheet.Cells[2, 1].Value = $"Năm: {year}";
                summarySheet.Cells[2, 1, 2, 4].Merge = true; // Merge cells for the year info
                summarySheet.Cells[2, 1, 2, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                summarySheet.Cells[2, 1, 2, 4].Style.Font.Bold = true;
                summarySheet.Cells[3, 1].Value = $"Ngày xuất báo cáo: {DateTime.Now:dd/MM/yyyy}";
                summarySheet.Cells[3, 1, 3, 4].Merge = true; // Merge cells for the date
                summarySheet.Cells[3, 1, 3, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                summarySheet.Cells[3, 1, 3, 4].Style.Font.Bold = true;

                // Styling
                summarySheet.Cells[1, 1, 3, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                // Display overall summary in the summary sheet
                summarySheet.Cells[4, 1].Value = "Tổng Doanh Thu Cả Năm";
                summarySheet.Cells[4, 2].Value = yearlyRevenue;
                summarySheet.Cells[4, 2].Style.Numberformat.Format = "#,##0"; // Currency format

                summarySheet.Cells[5, 1].Value = "Tổng Số Lượt Đăng Ký";
                summarySheet.Cells[5, 2].Value = yearlySubscriptions;

                summarySheet.Cells[6, 1].Value = "Tổng Số Buổi Hẹn";
                summarySheet.Cells[6, 2].Value = yearlyAppointments;

                summarySheet.Cells[4, 1, 6, 2].Style.Font.Bold = true;
                summarySheet.Cells[4, 1, 6, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                summarySheet.Cells[8, 1].Value = "BẢNG THỐNG KÊ DOANH THU CÁC THÁNG";
                summarySheet.Cells[8, 1, 8, 4].Merge = true;
                summarySheet.Cells[8, 1, 8, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                summarySheet.Cells[8, 1, 8, 4].Style.Font.Bold = true;

                // Column headers for monthly revenue
                summarySheet.Cells[9, 1].Value = "Tháng";
                summarySheet.Cells[9, 2].Value = "Doanh Thu (VNĐ)";
                summarySheet.Cells[9, 3].Value = "Số lượt đăng ký";
                summarySheet.Cells[9, 4].Value = "Số buổi hẹn";
                summarySheet.Cells[9, 1, 9, 4].Style.Font.Bold = true;

                // Add the monthly revenue data
                for (int month = 0; month < 12; month++)
                {
                    summarySheet.Cells[10 + month, 1].Value = $"Tháng {month + 1}";
                    summarySheet.Cells[10 + month, 2].Value = monthlyRevenues[month];
                    summarySheet.Cells[10 + month, 2].Style.Numberformat.Format = "#,##0";
                    summarySheet.Cells[10 + month, 3].Value = monthlySubs[month];
                    summarySheet.Cells[10 + month, 4].Value = monthlyApp[month];
                }

                summarySheet.Cells[9, 1, 100, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // AutoFit columns
                summarySheet.Cells[summarySheet.Dimension.Address].AutoFitColumns();

                // Loop through each month's report and create a sheet for it
                for (int month = 0; month < 12; month++)
                {
                    var monthReport = monthlyReports[month];
                    var monthSheet = package.Workbook.Worksheets.Add($"Tháng {month + 1}");

                    // Title for the month sheet
                    monthSheet.Cells[1, 1].Value = $"BÁO CÁO DOANH THU THÁNG {month + 1}/{year}";
                    monthSheet.Cells[1, 1, 1, 5].Merge = true;
                    monthSheet.Cells[1, 1, 1, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    monthSheet.Cells[1, 1, 1, 5].Style.Font.Bold = true;
                    monthSheet.Cells[1, 1, 1, 5].Style.Font.Size = 14;

                    // Add month, year and report date
                    monthSheet.Cells[2, 1].Value = $"Tháng: {month + 1} - Năm: {year}";
                    monthSheet.Cells[2, 1, 2, 5].Merge = true;
                    monthSheet.Cells[2, 1, 2, 5].Style.Font.Bold = true;
                    monthSheet.Cells[3, 1].Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy}";
                    monthSheet.Cells[3, 1, 3, 5].Merge = true;
                    monthSheet.Cells[3, 1, 3, 5].Style.Font.Bold = true;

                    // Column headers
                    monthSheet.Cells[9, 1].Value = "STT";
                    monthSheet.Cells[9, 2].Value = "Tên Dịch Vụ";
                    monthSheet.Cells[9, 3].Value = "Doanh Thu (VNĐ)";
                    monthSheet.Cells[9, 4].Value = "Số Lượt Đăng Ký";
                    monthSheet.Cells[9, 5].Value = "Số Buổi Hẹn";

                    monthSheet.Cells[9, 1, 9, 5].Style.Font.Bold = true;

                    // Data for each month
                    decimal totalMonthRevenue = 0;
                    decimal totalMonthSubscription = 0;
                    decimal totalMonthAppointments = 0;

                    var row = 10;
                    foreach (var item in monthReport)
                    {
                        monthSheet.Cells[row, 1].Value = row - 9; // Số thứ tự
                        monthSheet.Cells[row, 2].Value = item.ServiceName;
                        monthSheet.Cells[row, 3].Value = item.Revenue;
                        monthSheet.Cells[row, 4].Value = item.RegistrationCount;
                        monthSheet.Cells[row, 5].Value = item.AppointmentCount;

                        monthSheet.Cells[row, 3].Style.Numberformat.Format = "#,##0"; // Currency format

                        totalMonthRevenue += item.Revenue;
                        totalMonthSubscription += item.RegistrationCount;
                        totalMonthAppointments += item.AppointmentCount;
                        row++;
                    }

                    monthSheet.Cells[5, 1].Value = "TỔNG DOANH THU";
                    monthSheet.Cells[5, 2].Value = totalMonthRevenue;
                    monthSheet.Cells[5, 2].Style.Numberformat.Format = "#,##0";
                    monthSheet.Cells[5, 1, 5, 2].Style.Font.Bold = true;

                    monthSheet.Cells[6, 1].Value = "TỔNG SỐ LƯỢT ĐĂNG KÝ";
                    monthSheet.Cells[6, 2].Value = totalMonthSubscription;
                    monthSheet.Cells[6, 1, 6, 2].Style.Font.Bold = true;


                    monthSheet.Cells[7, 1].Value = "TỔNG SỐ BUỔI HẸN";
                    monthSheet.Cells[7, 2].Value = totalMonthAppointments;
                    monthSheet.Cells[7, 1, 7, 2].Style.Font.Bold = true;

                    monthSheet.Cells[1, 1, 7, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    monthSheet.Cells[9, 1, 100, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                    // AutoFit columns
                    monthSheet.Cells[monthSheet.Dimension.Address].AutoFitColumns();
                }

                // Save the Excel file
                var fileName = $"Revenue_{year}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "report", "revenue", fileName);
                var fileInfo = new FileInfo(filePath);

                // Save the Excel file to disk
                await package.SaveAsAsync(fileInfo);

                // Return the file to the client
                return new FileContentResult(await System.IO.File.ReadAllBytesAsync(filePath), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    FileDownloadName = fileName
                };
            }
        }


    }
}
