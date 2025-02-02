using BE.ViewModels;

namespace BE.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        Task PaymentSuccess(VnPaymentResponseModel response);
    }
}
