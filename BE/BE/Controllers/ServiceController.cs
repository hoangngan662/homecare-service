using BE.Dtos;
using BE.Models;
using BE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [Route("api/service")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly ServiceService _serviceService;
        public ServiceController(ServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet("service-types")]
        public async Task<ActionResult<PaginatedResult<ServiceTypeDto>>> GetAllServiceTypesAsync(int pageNumber, int pageSize)
        {
            var serviceTypes = await _serviceService.GetAllServiceTypesAsync(pageNumber, pageSize);
            return Ok(serviceTypes);
        }
        [HttpGet("service-types/{id}")]
        public async Task<ActionResult<ServiceTypeDto>> GetServiceTypeByIdAsync(int id)
        {
            var serviceType = await _serviceService.GetServiceTypeByIdAsync(id);
            return Ok(serviceType);
        }

        [HttpPost("service-type")]
        public async Task<ActionResult> AddServiceTypeAsync([FromForm] ServiceTypeCreateDto serviceTypeDto)
        {
            try
            {
                await _serviceService.AddServiceTypeAsync(serviceTypeDto);
                return Ok(new
                {
                    message = "Create success."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 1, message = "Đã xảy ra lỗi, hãy thử lại." });
            }  
        }

        [HttpPut("service-type/{id}")]
        public async Task<ActionResult> UpdateServiceTypeAsync(int id, [FromForm] ServiceTypeCreateDto serviceTypeDto)
        {            
            try
            {
                await _serviceService.UpdateServiceTypeAsync(id, serviceTypeDto);
                return Ok(new
                {
                    message = "Update success."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 1, message = "Đã xảy ra lỗi, hãy thử lại." });
            }
        }

        [HttpDelete("service-type/{id}")]
        public async Task<ActionResult> DeleteServiceTypeAsync(int id)
        {            
            try
            {
                await _serviceService.DeleteServiceTypeAsync(id);
                return Ok(new
                {
                    message = "Delete success."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 1, message = "Đã xảy ra lỗi, hãy thử lại." });
            }
        }

        [HttpGet("service-packages")]
        public async Task<ActionResult<PaginatedResult<ServicePackageDto>>> GetAllServicePackagesAsync(int pageNumber, int pageSize)
        {
            var servicePackages = await _serviceService.GetAllServicePackagesAsync(pageNumber, pageSize);
            return Ok(servicePackages);
        }

        [HttpGet("service-packages/{id}")]
        public async Task<ActionResult<IEnumerable<ServicePackageDto>>> GetServicePackageByIdAsync(int id)
        {
            var servicePackage = await _serviceService.GetServicePackageByIdAsync(id);
            return Ok(servicePackage);
        }

        [HttpPost("service-package")]
        public async Task<ActionResult> AddServicePackageAsync([FromBody] ServicePackageCreateDto servicePackageDto)
        {            
            try
            {
                await _serviceService.AddServicePackageAsync(servicePackageDto);
                return Ok(new
                {
                    message = "Create success."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 1, message = "Đã xảy ra lỗi, hãy thử lại." });
            }
        }

        [HttpPut("service-package/{id}")]
        public async Task<ActionResult> UpdateServicePackageAsync(int id, [FromBody] ServicePackageCreateDto servicePackageDto)
        {            
            try
            {
                await _serviceService.UpdateServicePackageAsync(id, servicePackageDto);
                return Ok(new
                {
                    message = "Update success."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 1, message = "Đã xảy ra lỗi, hãy thử lại." });
            }
        }

        [HttpDelete("service-package/{id}")]
        public async Task<ActionResult> DeleteServicePackageAsync(int id)
        {            
            try
            {
                await _serviceService.DeleteServicePackageAsync(id);
                return Ok(new
                {
                    message = "Delete success."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 1, message = "Đã xảy ra lỗi, hãy thử lại." });
            }
        }

        [HttpGet("img")]
        public async Task<ActionResult<IEnumerable<string>>> GetImageUrlAsync()
        {
            var img = await _serviceService.GetImageUrlAsync();
            return Ok(img);
        }

        [HttpGet("service-types/search")]
        public async Task<ActionResult<PaginatedResult<ServiceTypeDto>>> SearchServiceTypeAsync(string? searchValue, int pageNumber, int pageSize)
        {
            if (searchValue == null || searchValue == "")
            {
                var result = await _serviceService.GetAllServiceTypesAsync(pageNumber, pageSize);
                return Ok(result);
            }
            var serviceTypes = await _serviceService.SearchServiceTypeAsync(searchValue, pageNumber, pageSize);
            return Ok(serviceTypes);
        }
    }
}
