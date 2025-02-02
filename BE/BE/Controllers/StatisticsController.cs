using BE.Dtos;
using BE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [Route("api/stats")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly StatisticsService _statisticsService;
        public StatisticsController(StatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }
        [HttpGet]
        public async Task<ActionResult<StatisticsDto>> GetStatisticsAsync()
        {
            var result = await _statisticsService.GetStatisticsAsync();
            return Ok(result);
        }

        [HttpGet("service-type")]
        public async Task<ActionResult<RevenueStatisticsDto>> GetRevenueByServiceTypeAsync()
        {
            var result = await _statisticsService.GetRevenueByServiceTypeAsync();
            return Ok(result);
        }

        [HttpGet("sub-app")]
        public async Task<ActionResult<List<ServiceStatsDto>>> GetServiceStatsAsync()
        {
            var result = await _statisticsService.GetServiceStatsAsync();
            return Ok(result);
        }

        [HttpGet("patient-age")]
        public async Task<ActionResult<List<CustomerAgeStat>>> GetCustomerAgeStatsAsync()
        {
            var result = await _statisticsService.GetCustomerAgeStatsAsync();
            return Ok(result);
        }

        [HttpGet("annual/{year}")]
        public async Task<ActionResult<AnnualRevenueDto>> GetAnnualRevenueAsync(int year)
        {
            var result = await _statisticsService.GetAnnualRevenueAsync(year);
            return Ok(result);
        }

        [HttpGet("review")]
        public async Task<ActionResult<ReviewStatDto>> GetReviewStatAsync()
        {
            var result = await _statisticsService.GetReviewStatAsync();
            return Ok(result);
        }

        [HttpGet("review-service")]
        public async Task<ActionResult<List<ServiceReviewStatDto>>> GetServiceReviewStatAsync()
        {
            var result = await _statisticsService.GetServiceReviewStatAsync();
            return Ok(result);
        }
    }
}
