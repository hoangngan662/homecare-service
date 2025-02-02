using BE.Dtos;
using BE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [Route("api/shift")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly ShiftService _shiftService;
        public ShiftController(ShiftService shiftService)
        {
            _shiftService = shiftService;            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShiftDto>>> GetAllShiftAsync()
        {
            var shifts = await _shiftService.GetAllShiftAsync();
            return Ok(shifts);
        }
    }
}
