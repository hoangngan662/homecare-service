using BE.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BE.Repositories.Interfaces
{
    public interface IReportRepository
    {
        Task<List<MonthlyRevenueReportDto>> GetMonthlyRevenueReportAsync(int month, int year);
        Task<FileResult> ExportMonthlyRevenueReportToExcel(int month, int year);
        Task<FileResult> ExportYearlyRevenueReportToExcel(int year);
    }
}
