using BE.Dtos;
using BE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [Route("api/subscription")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly SubscriptionService _subscriptionService;

        public SubscriptionController(SubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedResult<SubscriptionDto>>> GetAllSubscriptionAsync(int status, int pageNumber, int pageSize)
        {
            var subs = await _subscriptionService.GetAllSubscriptionAsync(status, pageNumber, pageSize);
            return Ok(subs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubscriptionDto>> GetSubscriptionByIdAsync(int id)
        {
            var sub = await _subscriptionService.GetSubscriptionByIdAsync(id);
            return Ok(sub);
        }

        [HttpGet("patient")]
        public async Task<ActionResult<PaginatedResult<SubscriptionDto>>> GetAllSubscriptionByPatientIdAsync(string patientId, int pageNumber, int pageSize)
        {
            var subs = await _subscriptionService.GetAllSubscriptionByPatientIdAsync(patientId ,pageNumber, pageSize);
            return Ok(subs);
        }

        [HttpGet("patient-paid")]
        public async Task<ActionResult<PaginatedResult<SubscriptionDto>>> GetSubscriptionByPatientIdPaidAsync(string patientId, int pageNumber, int pageSize)
        {
            var subs = await _subscriptionService.GetSubscriptionByPatientIdPaidAsync(patientId, pageNumber, pageSize);
            return Ok(subs);
        }

        [HttpGet("paid")]
        public async Task<ActionResult<PaginatedResult<SubscriptionDto>>> GetPaymentAsync(int pageNumber, int pageSize)
        {
            var subs = await _subscriptionService.GetPaymentAsync(pageNumber, pageSize);
            return Ok(subs);
        }

        [HttpGet("patient-status")]
        public async Task<ActionResult<PaginatedResult<SubscriptionDto>>> GetSubscriptionByPatientIdStatusAsync(string patientId, int status, int pageNumber, int pageSize)
        {
            var subs = await _subscriptionService.GetSubscriptionByPatientIdStatusAsync(patientId, status, pageNumber, pageSize);
            return Ok(subs);
        }

        [HttpPost]
        public async Task<ActionResult<SubscriptionDto>> AddSubscriptionAsync(SubscriptionCreateDto subscriptionDto)
        {            
            try
            {
                var sub = await _subscriptionService.AddSubscriptionAsync(subscriptionDto);
                return Ok(sub);
            }
            catch (Exception ex)
            {
                //return BadRequest(new { code = 1, message = "Đã xảy ra lỗi, hãy thử lại." });
                return BadRequest(new { code = 1, message = ex.Message});

            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSubscriptionAsync(int id, SubscriptionCreateDto subscriptionDto)
        {            
            try
            {
                await _subscriptionService.UpdateSubscriptionAsync(id, subscriptionDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 1, message = "Đã xảy ra lỗi, hãy thử lại." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSubscriptionAsync(int id)
        {            
            try
            {
                await _subscriptionService.DeleteSubscriptionAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 1, message = "Đã xảy ra lỗi, hãy thử lại." });
            }
        }
        [HttpPut("active/{id}")]
        public async Task<ActionResult> ActiveSubscriptionAsync(int id)
        {            
            try
            {
                await _subscriptionService.ActiveSubscriptionAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 1, message = "Đã xảy ra lỗi, hãy thử lại." });
            }
        }
        [HttpPut("complete/{id}")]
        public async Task<ActionResult> CompleteSubscriptionAsync(int id)
        {            
            try
            {
                await _subscriptionService.CompleteSubscriptionAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 1, message = "Đã xảy ra lỗi, hãy thử lại." });
            }
        }
    }
}
