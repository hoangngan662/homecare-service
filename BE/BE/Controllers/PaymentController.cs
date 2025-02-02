using BE.Data;
using BE.Dtos;
using BE.Services;
using BE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using static Google.Apis.Requests.BatchRequest;

namespace BE.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IVnPayService _vnPayService;
        private readonly ISendMailService _sendMailService;
        private readonly PaymentService _paymentService;
        public PaymentController(IConfiguration configuration, IVnPayService vnPayService, ISendMailService sendMailService, PaymentService paymentService)
        {
            _configuration = configuration;
            _vnPayService = vnPayService;
            _sendMailService = sendMailService;
            _paymentService = paymentService;
        }

        [HttpPost("create")]
        public IActionResult CreatePayment(VnPaymentRequestModel model)
        {
            try
            {
                var url = _vnPayService.CreatePaymentUrl(HttpContext, model);
                return Ok(new
                {
                    paymentUrl = url
                });
            }
            catch (Exception ex) {
                return BadRequest(new { code = 1, message = "Đã xảy ra lỗi, hãy thử lại." });
            }
        }

        [HttpPost("return")]
        public async Task<IActionResult> PaymentReturn(VnPaymentResponseModel response)
        {
            if (response == null || response.VnPayResponseCode != "00")
            {
                return BadRequest(new { code = 1, message = "Không thấy phản hồi. Thanh toán thất bại." });
            }
            else
            {
                try
                {
                    await _paymentService.PaymentSuccess(response);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(new { code = 1, message = "Đã xảy ra lỗi, hãy thử lại." });
                }

            }
        }
    }
}
