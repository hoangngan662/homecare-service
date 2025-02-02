using BE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [Route("api/report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportService _reportService;
        public ReportController(ReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("MonthlyRevenueReport")]
        public async Task<IActionResult> GetMonthlyRevenueReport(int month, int year)
        {
            var report = await _reportService.GetMonthlyRevenueReportAsync(month, year);

            if (report == null || !report.Any())
            {
                return NoContent();  // Trả về 204 nếu không có dữ liệu
            }

            return Ok(report);  // Trả về báo cáo nếu có dữ liệu
        }

        [HttpGet("revenue-monthly")]
        public async Task<IActionResult> ExportMonthlyRevenueReport(int month, int year)
        {
            var fileResult = await _reportService.ExportMonthlyRevenueReportToExcel(month, year);

            if (fileResult == null)
            {
                return NotFound("Không có dữ liệu để xuất báo cáo.");
            }

            return fileResult;
        }

        [HttpGet("revenue-yearly")]
        public async Task<IActionResult> ExportYearlyRevenueReport(int year)
        {
            var fileResult = await _reportService.ExportYearlyRevenueReportToExcel(year);

            if (fileResult == null)
            {
                return NotFound("Không có dữ liệu để xuất báo cáo.");
            }

            return fileResult;
        }
    }
}
