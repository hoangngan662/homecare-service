using BE.Dtos;
using BE.Models;
using BE.Repositories.Interfaces;

namespace BE.Services
{
    public class SubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<PaginatedResult<SubscriptionDto>> GetAllSubscriptionAsync(int status, int pageNumber, int pageSize)
        {
            var subs = await _subscriptionRepository.GetAllSubscriptionAsync(status, pageNumber, pageSize);
            return subs;
        }

        public async Task<SubscriptionDto> GetSubscriptionByIdAsync(int id)
        {
            var sub = await _subscriptionRepository.GetSubscriptionByIdAsync(id);
            return sub;
        }

        public async Task<PaginatedResult<SubscriptionDto>> GetAllSubscriptionByPatientIdAsync(string patientId ,int pageNumber, int pageSize)
        {
            var subs = await _subscriptionRepository.GetAllSubscriptionByPatientIdAsync(patientId, pageNumber, pageSize);
            return subs;
        }

        public async Task<PaginatedResult<SubscriptionDto>> GetSubscriptionByPatientIdPaidAsync(string patientId, int pageNumber, int pageSize)
        {
            var subs = await _subscriptionRepository.GetSubscriptionByPatientIdPaidAsync(patientId, pageNumber, pageSize);
            return subs;
        }

        public async Task<PaginatedResult<SubscriptionDto>> GetPaymentAsync(int pageNumber, int pageSize)
        {
            var subs = await _subscriptionRepository.GetPaymentAsync(pageNumber, pageSize);
            return subs;
        }

        public async Task<PaginatedResult<SubscriptionDto>> GetSubscriptionByPatientIdStatusAsync(string patientId, int status, int pageNumber, int pageSize)
        {
            var subs = await _subscriptionRepository.GetSubscriptionByPatientIdStatusAsync(patientId, status, pageNumber, pageSize);
            return subs;
        }

        public async Task<SubscriptionDto> AddSubscriptionAsync(SubscriptionCreateDto subscriptionDto)
        {
            return await _subscriptionRepository.AddSubscriptionAsync(subscriptionDto);
        }
        public async Task UpdateSubscriptionAsync(int id, SubscriptionCreateDto subscriptionDto)
        {
            await _subscriptionRepository.UpdateSubscriptionAsync(id, subscriptionDto);
        }
        public async Task ActiveSubscriptionAsync(int id)
        {
            await _subscriptionRepository.ActiveSubscriptionAsync(id);
        }
        public async Task CompleteSubscriptionAsync(int id)
        {
            await _subscriptionRepository.CompleteSubscriptionAsync(id);
        }
        public async Task DeleteSubscriptionAsync(int id)
        {
            await _subscriptionRepository.DeleteSubscriptionAsync(id);
        }
    }
}
