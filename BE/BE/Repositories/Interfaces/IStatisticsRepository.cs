using BE.Dtos;

namespace BE.Repositories.Interfaces
{
    public interface IStatisticsRepository
    {
        Task<StatisticsDto> GetStatisticsAsync();
        Task<RevenueStatisticsDto> GetRevenueByServiceTypeAsync();
        Task<List<ServiceStatsDto>> GetServiceStatsAsync();
        Task<List<CustomerAgeStat>> GetCustomerAgeStatsAsync();
        Task<AnnualRevenueDto> GetAnnualRevenueAsync(int year);
        Task<ReviewStatDto> GetReviewStatAsync();
        Task<List<ServiceReviewStatDto>> GetServiceReviewStatAsync();
    }
}
