using BE.Dtos;
using BE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [Route("api/appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentService _appointmentService;
        public AppointmentController(AppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }


        [HttpGet]
        public async Task<ActionResult<PaginatedResult<AppointmentDto>>> GetAllAppointmentAsync(int status, int pageNumber, int pageSize)
        {
            var apps = await _appointmentService.GetAllAppointmentAsync(status, pageNumber, pageSize);
            return Ok(apps);
        }

        [HttpGet("subscription/{subId}")]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAllAppointmentBySubAsync(int subId)
        {
            var apps = await _appointmentService.GetAppointmentBySubAsync(subId);
            return Ok(apps);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDto>> GetAppointmentByIdAsync(int id)
        {
            var app = await _appointmentService.GetAppointmentByIdAsync(id);
            return Ok(app);
        }

        [HttpPost]
        public async Task<ActionResult> AddAppointmentAsync(AppointmentCreateDto appointmentDto)
        {            
            try
            {
                await _appointmentService.AddAppointmentAsync(appointmentDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 1, message = "Đã xảy ra lỗi, hãy thử lại." });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAppointmentAsync(int id, AppointmentCreateDto appointmentDto)
        {            
            try
            {
                await _appointmentService.UpdateAppointmentAsync(id, appointmentDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 1, message = "Đã xảy ra lỗi, hãy thử lại." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAppointmentAsync(int id)
        {            
            try
            {
                await _appointmentService.DeleteAppointmentAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 1, message = "Đã xảy ra lỗi, hãy thử lại." });
            }
        }

        [HttpPost("complete")]
        public async Task<ActionResult> CompleteAppointmentAsync(AppointmentDetailCreateDto detail)
        {            
            try
            {
                await _appointmentService.CompleteAppointmentAsync(detail);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 1, message = "Đã xảy ra lỗi, hãy thử lại." });
            }
        }

        [HttpPost("review-send")]
        public async Task<ActionResult> ReviewAppointmentAsync(AppointmentReviewCreateDto review)
        {            
            try
            {
                await _appointmentService.ReviewAppointmentAsync(review);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 1, message = "Đã xảy ra lỗi, hãy thử lại." });
            }
        }

        [HttpGet("weekly")]
        public async Task<ActionResult<IEnumerable<DailyAppointmentsModel>>> GetWeeklyAppointments(DateTime startDate)
        {
            var apps = await _appointmentService.GetWeeklyAppointments(startDate);
            return Ok(apps);
        }

        [HttpGet("weekly-staff")]
        public async Task<ActionResult<IEnumerable<DailyAppointmentsModel>>> GetWeeklyAppointmentsById(DateTime startDate, string staffId)
        {
            var apps = await _appointmentService.GetWeeklyAppointmentsById(startDate, staffId);
            return Ok(apps);
        }

        [HttpPut("confirm")]
        public async Task<ActionResult> ConfirmAppointment(int id, string staffId)
        {            
            try
            {
                await _appointmentService.ConfirmAppointment(id, staffId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 1, message = "Đã xảy ra lỗi, hãy thử lại." });
            }
        }

        [HttpGet("record")]
        public async Task<ActionResult<IEnumerable<PatientRecord>>> GetPatientRecordAsync(string patientId)
        {
            var res = await _appointmentService.GetPatientRecordAsync(patientId);
            return Ok(res);
        }

        [HttpGet("reviews")]
        public async Task<ActionResult<PaginatedResult<AppointmentDto>>> GetAllReviews(int pageNumber, int pageSize)
        {
            var apps = await _appointmentService.GetAllReviews(pageNumber, pageSize);
            return Ok(apps);
        }

        [HttpGet("reviews/{staffId}")]
        public async Task<ActionResult<StaffReviewDto>> GetReviewsForStaff(string staffId)
        {
            var apps = await _appointmentService.GetReviewsForStaff(staffId);
            return Ok(apps);
        }

        [HttpPut("daily")]
        public async Task<ActionResult> UpdateApppointmentDaily()
        {
            try
            {
                await _appointmentService.UpdateApppointmentDaily();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 1, message = "Đã xảy ra lỗi, hãy thử lại." });
            }
        }
    }
}
