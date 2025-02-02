using BE.Dtos;
using BE.Models;

namespace BE.Repositories.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task<PaginatedResult<SubscriptionDto>> GetAllSubscriptionAsync(int status, int pageNumber, int pageSize);
        Task<PaginatedResult<SubscriptionDto>> GetAllSubscriptionByPatientIdAsync(string patientId ,int pageNumber, int pageSize);
        Task<PaginatedResult<SubscriptionDto>> GetSubscriptionByPatientIdPaidAsync(string patientId, int pageNumber, int pageSize);
        Task<PaginatedResult<SubscriptionDto>> GetPaymentAsync(int pageNumber, int pageSize);
        Task<PaginatedResult<SubscriptionDto>> GetSubscriptionByPatientIdStatusAsync(string patientId, int status, int pageNumber, int pageSize);
        Task<SubscriptionDto> GetSubscriptionByIdAsync(int id);
        Task<SubscriptionDto> AddSubscriptionAsync(SubscriptionCreateDto subscriptionDto);
        Task UpdateSubscriptionAsync(int id, SubscriptionCreateDto subscriptionDto);
        Task ActiveSubscriptionAsync(int id);
        Task CompleteSubscriptionAsync(int id);
        Task DeleteSubscriptionAsync(int id);

    }
}
