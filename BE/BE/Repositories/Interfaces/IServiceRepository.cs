using BE.Dtos;

namespace BE.Repositories.Interfaces
{
    public interface IServiceRepository
    {        
        Task<PaginatedResult<ServiceTypeDto>> GetAllServiceTypesAsync(int pageNumber, int pageSize);
        Task<ServiceTypeDto> GetServiceTypeByIdAsync(int id);
        Task AddServiceTypeAsync(ServiceTypeCreateDto serviceTypeDto);
        Task UpdateServiceTypeAsync(int id, ServiceTypeCreateDto serviceTypeDto);
        Task DeleteServiceTypeAsync(int id);

        Task<PaginatedResult<ServicePackageDto>> GetAllServicePackagesAsync(int pageNumber, int pageSize);
        Task<ServicePackageDto> GetServicePackageByIdAsync(int id);
        Task AddServicePackageAsync(ServicePackageCreateDto servicePackageDto);
        Task UpdateServicePackageAsync(int id, ServicePackageCreateDto servicePackageDto);
        Task DeleteServicePackageAsync(int id);
        Task<IEnumerable<string>> GetImageUrlAsync();
        Task<PaginatedResult<ServiceTypeDto>> SearchServiceTypeAsync( string searchValue, int pageNumber, int pageSize);
    }
}
