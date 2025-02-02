using BE.Repositories.Interfaces;
using BE.ViewModels;

namespace BE.Services
{
    public class PaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task PaymentSuccess(VnPaymentResponseModel response)
        {
            await _paymentRepository.PaymentSuccess(response);
        }
    }
}
