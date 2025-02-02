using BE.Dtos;
using BE.Repositories.Interfaces;

namespace BE.Services
{
    public class StatisticsService
    {
        private readonly IStatisticsRepository _statisticsRepository;
        public StatisticsService(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }
        public async Task<StatisticsDto> GetStatisticsAsync()
        {
            return await _statisticsRepository.GetStatisticsAsync();
        }

        public async Task<RevenueStatisticsDto> GetRevenueByServiceTypeAsync()
        {
            return await _statisticsRepository.GetRevenueByServiceTypeAsync();
        }

        public async Task<List<ServiceStatsDto>> GetServiceStatsAsync()
        {
            return await _statisticsRepository.GetServiceStatsAsync();
        }

        public async Task<List<CustomerAgeStat>> GetCustomerAgeStatsAsync()
        {
            return await _statisticsRepository.GetCustomerAgeStatsAsync();
        }

        public async Task<AnnualRevenueDto> GetAnnualRevenueAsync(int year)
        {
            return await _statisticsRepository.GetAnnualRevenueAsync(year);
        }

        public async Task<ReviewStatDto> GetReviewStatAsync()
        {
            return await _statisticsRepository.GetReviewStatAsync();
        }

        public async Task<List<ServiceReviewStatDto>> GetServiceReviewStatAsync()
        {
            return await _statisticsRepository.GetServiceReviewStatAsync();
        }

    }
}
