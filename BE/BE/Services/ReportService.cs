using BE.Dtos;
using BE.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Services
{
    public class ReportService
    {
        private readonly IReportRepository _reportRepository;
        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<List<MonthlyRevenueReportDto>> GetMonthlyRevenueReportAsync(int month, int year)
        {
            return await _reportRepository.GetMonthlyRevenueReportAsync(month, year);
        }
        public async Task<FileResult> ExportMonthlyRevenueReportToExcel(int month, int year)
        {
            return await _reportRepository.ExportMonthlyRevenueReportToExcel(month, year);
        }
        public async Task<FileResult> ExportYearlyRevenueReportToExcel(int year)
        {
            return await _reportRepository.ExportYearlyRevenueReportToExcel(year);
        }
    }
}
