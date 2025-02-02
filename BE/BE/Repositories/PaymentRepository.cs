using AutoMapper;
using BE.Data;
using BE.Dtos;
using BE.Repositories.Interfaces;
using BE.Services;
using BE.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BE.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ISendMailService _sendMailService;

        public PaymentRepository(AppDbContext context, IMapper mapper, ISendMailService sendMailService)
        {
            _context = context;
            _mapper = mapper;
            _sendMailService = sendMailService;
        }

        public async Task PaymentSuccess(VnPaymentResponseModel response)
        {
            var index = response.OrderDescription.LastIndexOf(":") + 1;
            var orderId = int.Parse(response.OrderDescription.Substring(index));
            var sub = await _context.Subscriptions.FindAsync(orderId);

            var tmpPack = await _context.ServicePackages.Where(p => p.Id == sub.ServicePackageId)
                .Include(st => st.ServiceType)
                .FirstOrDefaultAsync();
            var packDto = _mapper.Map<ServicePackageDto>(tmpPack);

            if (sub != null)
            {
                sub.IsPaid = true;
                sub.StartDate = DateTime.Now;
                sub.EndDate = sub.StartDate.AddMonths(tmpPack.DurationInMonths.Value);
                sub.PaymentDate = DateTime.Now;
                sub.Status = Models.SubscriptionStatus.Active;
                _context.Subscriptions.Update(sub);
            }
            await _context.SaveChangesAsync();

            var user = await _context.Users.FindAsync(sub.PatientId);
            

            if (user != null)
            {
                // Gửi email xác nhận đặt hàng
                var email = user.Email;
                var subject = "Homecare Service - Xác nhận thanh toán thành công dịch vụ";

                var detailHtml =
                    "<dl>" +
                     "<dt>Khách hàng: " + user.Fullname + " </dt>" +
                     "<dt>Dịch vụ: " + packDto.ServiceTypeName + " </dt>" +
                     "<dt>Gói dịch vụ: " + packDto.Name + " </dt>" +
                     "<dt>Thời gian: " + packDto.NumberOfSessions + " buổi / " + packDto.DurationInMonths + " tháng " + " </dt>" +
                     "<dt>Ngày đăng ký: " + sub.SubscriptionDate.ToString("dd/MM/yyyy") + " </dt>" +
                     "<dt>Giá: " + packDto.Price.ToString("N0") + " VNĐ" + " </dt>" +
                     "<dt>Ngày bắt đầu: " + sub.StartDate.ToString("dd/MM/yyyy") + " </dt>" +
                     "<dt>Ngày kết thúc: " + sub.EndDate.ToString("dd/MM/yyyy") + " </dt>" +
                     "</dl>";
                string payDate = sub.PaymentDate.HasValue
                    ? sub.PaymentDate.Value.ToString("dd/MM/yyyy HH:mm:ss")
                    : "";

                var htmlMessage =
                     "<p>Xin chào!,</p>\r\n   " +
                     "<p>Cảm ơn bạn đã đăng ký dịch vụ tại trung tâm của chúng tôi.</p>" +
                     "<p>Dịch vụ của bạn đã được thanh toán thành công vào lúc " +
                     payDate + ".</p>" +
                     "<p>Chi tiết đăng ký dịch vụ của bạn: </p>" +
                     detailHtml +
                     "<p>Chúng tôi hy vọng bạn sẽ hài lòng về dịch vụ.</p>" +
                     "<p>Chúc bạn một ngày tốt lành❤️</p>" +
                    "<br>" +
                    "<p>Thân mến,</p>" +
                    "<p>Homecare Service</p>";

                await _sendMailService.SendEmailAsync(email, subject, htmlMessage);
            }
        }
    }
}
