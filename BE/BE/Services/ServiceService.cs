using AutoMapper;
using BE.Dtos;
using BE.Models;
using BE.Repositories.Interfaces;

namespace BE.Services
{
    public class ServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public async Task<PaginatedResult<ServiceTypeDto>> GetAllServiceTypesAsync(int pageNumber, int pageSize)
        {
            return await _serviceRepository.GetAllServiceTypesAsync(pageNumber, pageSize);
        }

        public async Task<ServiceTypeDto> GetServiceTypeByIdAsync(int id)
        {
            return await _serviceRepository.GetServiceTypeByIdAsync(id);
        }

        public async Task AddServiceTypeAsync(ServiceTypeCreateDto serviceTypeDto)
        {
            await _serviceRepository.AddServiceTypeAsync(serviceTypeDto);
        }

        public async Task UpdateServiceTypeAsync(int id, ServiceTypeCreateDto serviceTypeDto)
        {
            await _serviceRepository.UpdateServiceTypeAsync(id, serviceTypeDto);
        }

        public async Task DeleteServiceTypeAsync(int id)
        {
            await _serviceRepository.DeleteServiceTypeAsync(id);
        }

        public async Task<PaginatedResult<ServicePackageDto>> GetAllServicePackagesAsync(int pageNumber, int pageSize)
        {
            return await _serviceRepository.GetAllServicePackagesAsync(pageNumber, pageSize);
        }

        public async Task<ServicePackageDto> GetServicePackageByIdAsync(int id)
        {
            return await _serviceRepository.GetServicePackageByIdAsync(id);
        }

        public async Task AddServicePackageAsync(ServicePackageCreateDto servicePackage)
        {
            await _serviceRepository.AddServicePackageAsync(servicePackage);
        }

        public async Task UpdateServicePackageAsync(int id, ServicePackageCreateDto servicePackage)
        {
            await _serviceRepository.UpdateServicePackageAsync(id, servicePackage);
        }

        public async Task DeleteServicePackageAsync(int id)
        {
            await _serviceRepository.DeleteServicePackageAsync(id);
        }

        public async Task<IEnumerable<string>> GetImageUrlAsync()
        {
            return await _serviceRepository.GetImageUrlAsync();
        }

        public async Task<PaginatedResult<ServiceTypeDto>> SearchServiceTypeAsync(string searchValue, int pageNumber, int pageSize)
        {
            return await _serviceRepository.SearchServiceTypeAsync(searchValue, pageNumber, pageSize);
        }
    }
}
