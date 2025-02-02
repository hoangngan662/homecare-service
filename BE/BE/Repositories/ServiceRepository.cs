using AutoMapper;
using BE.Data;
using BE.Dtos;
using BE.Models;
using BE.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BE.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ServiceRepository(AppDbContext context, IMapper mapper) { 
            _context = context;
            _mapper = mapper;
        }
        public async Task<PaginatedResult<ServiceTypeDto>> GetAllServiceTypesAsync(int pageNumber, int pageSize)
        {
            var totalCount = await _context.ServiceTypes.Where(s => s.IsActive == true).CountAsync();

            var serviceTypes = await _context.ServiceTypes
                .Where(s => s.IsActive == true)
                .Include(st => st.ServicePackages)
                .OrderBy(s => s.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var serviceTypeDtos = _mapper.Map<IEnumerable<ServiceTypeDto>>(serviceTypes);

            return new PaginatedResult<ServiceTypeDto>
            {
                Items = serviceTypeDtos,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }

        public async Task<ServiceTypeDto> GetServiceTypeByIdAsync(int id)
        {
            var serviceType = await _context.ServiceTypes
            .Where(s => s.Id == id)
            .Include(st => st.ServicePackages)
            .SingleOrDefaultAsync();

            var serviceTypeDto = _mapper.Map<ServiceTypeDto>(serviceType);

            return serviceTypeDto;
        }

        public async Task AddServiceTypeAsync(ServiceTypeCreateDto serviceTypeDto)
        {
            // Chuyển đổi DTO sang thực thể ServiceType
            var serviceType = _mapper.Map<ServiceType>(serviceTypeDto);

            if (serviceTypeDto.Image != null && serviceTypeDto.Image.Length > 0)
            {
                // Tạo tên tệp duy nhất
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(serviceTypeDto.Image.FileName);

                // Đường dẫn thư mục lưu hình ảnh
                var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/servicetypes");

                // Kiểm tra nếu thư mục không tồn tại, tạo thư mục
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                // Đường dẫn tệp hình ảnh
                var filePath = Path.Combine(uploadFolder, fileName);

                // Lưu hình ảnh vào thư mục
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await serviceTypeDto.Image.CopyToAsync(stream);
                }

                // Lưu đường dẫn hình ảnh vào thuộc tính Image
                serviceType.Image = $"/images/servicetypes/{fileName}"; // Đường dẫn tương đối
            }

            // Thêm ServiceType vào DbContext và lưu thay đổi
            _context.ServiceTypes.Add(serviceType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateServiceTypeAsync(int id, ServiceTypeCreateDto serviceTypeDto)
        {
            var serviceType = await _context.ServiceTypes.FindAsync(id);
            if (serviceType != null)
            {
                // Cập nhật các trường Name và Description
                serviceType.Name = serviceTypeDto.Name;
                serviceType.Description = serviceTypeDto.Description;

                if (serviceTypeDto.Image != null && serviceTypeDto.Image.Length > 0)
                {
                    // Tạo tên tệp duy nhất
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(serviceTypeDto.Image.FileName);

                    // Đường dẫn thư mục lưu hình ảnh
                    var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/servicetypes");

                    // Kiểm tra nếu thư mục không tồn tại, tạo thư mục
                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }

                    // Đường dẫn tệp hình ảnh
                    var filePath = Path.Combine(uploadFolder, fileName);

                    // Lưu hình ảnh vào thư mục
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await serviceTypeDto.Image.CopyToAsync(stream);
                    }

                    // Lưu đường dẫn hình ảnh vào thuộc tính Image
                    serviceType.Image = $"/images/servicetypes/{fileName}"; // Đường dẫn tương đối
                }

                // Cập nhật đối tượng trong context và lưu thay đổi
                _context.ServiceTypes.Update(serviceType);
                await _context.SaveChangesAsync();
            }
        }

        //public async Task UpdateServiceTypeAsync(int id, ServiceTypeCreateDto serviceTypeDto)
        //{
        //    var serviceType = await _context.ServiceTypes.FindAsync(id);
        //    if(serviceType != null)
        //    {
        //        serviceType.Name = serviceTypeDto.Name;
        //        serviceType.Description = serviceTypeDto.Description;
        //        _context.ServiceTypes.Update(serviceType);
        //    }            
        //    await _context.SaveChangesAsync();
        //}

        public async Task DeleteServiceTypeAsync(int id)
        {
            var serviceType = await _context.ServiceTypes
                .Include(st => st.ServicePackages)
                .FirstOrDefaultAsync(st => st.Id == id);
            if (serviceType != null)
            {
                serviceType.IsActive = false;
                _context.ServiceTypes.Update(serviceType);
                if (serviceType.ServicePackages != null)
                {
                    foreach (var servicePackage in serviceType.ServicePackages)
                    {
                        servicePackage.IsActive = false;
                    }
                    _context.ServicePackages.UpdateRange(serviceType.ServicePackages);
                }                
            }
            await _context.SaveChangesAsync();
        }


        public async Task<PaginatedResult<ServicePackageDto>> GetAllServicePackagesAsync(int pageNumber, int pageSize)
        {
            var totalCount = await _context.ServicePackages.Where(sp => sp.IsActive == true).CountAsync();

            var servicePackages = await _context.ServicePackages
                                .Where(sp => sp.IsActive == true)
                                .Include(sp => sp.ServiceType)
                                .Select(sp => new ServicePackageDto
                                {
                                    Id = sp.Id,
                                    Name = sp.Name,
                                    Price = sp.Price,
                                    NumberOfSessions = sp.NumberOfSessions,
                                    DurationInMonths = sp.DurationInMonths,
                                    ServiceTypeId = sp.ServiceType.Id,
                                    ServiceTypeName = sp.ServiceType.Name,
                                    SubscriptionCount = _context.Subscriptions.Count(s => s.ServicePackageId == sp.Id) 
                                })
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

            //var servicePackageDtos = _mapper.Map<IEnumerable<ServicePackageDto>>(servicePackages);

            return new PaginatedResult<ServicePackageDto>
            {
                Items = servicePackages,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }

        public async Task<ServicePackageDto> GetServicePackageByIdAsync(int id)
        {
            var servicePackage = await _context.ServicePackages
            .Where(s => s.Id == id)
            .Include(st => st.ServiceType)
            .SingleOrDefaultAsync();

            var servicePackageDto = _mapper.Map<ServicePackageDto>(servicePackage);

            return servicePackageDto;
        }
                
        public async Task AddServicePackageAsync(ServicePackageCreateDto servicePackageDto)
        {
            var servicePackage = _mapper.Map<ServicePackage>(servicePackageDto);
            _context.ServicePackages.Add(servicePackage);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateServicePackageAsync(int id, ServicePackageCreateDto servicePackageDto)
        {
            var servicePackage = await _context.ServicePackages.FindAsync(id);
            if (servicePackage != null)
            {
                servicePackage.Name = servicePackageDto.Name;
                servicePackage.Price = servicePackageDto.Price;
                servicePackage.NumberOfSessions = servicePackageDto.NumberOfSessions;
                servicePackage.DurationInMonths = servicePackageDto.DurationInMonths;
                servicePackage.ServiceTypeId = servicePackageDto.ServiceTypeId;

                _context.ServicePackages.Update(servicePackage);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServicePackageAsync(int id)
        {
            var servicePackage = await _context.ServicePackages
                .FirstOrDefaultAsync(st => st.Id == id);
            if (servicePackage != null)
            {
                servicePackage.IsActive = false;
                _context.ServicePackages.Update(servicePackage);                
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<string>> GetImageUrlAsync()
        {
            var serviceTypesImage = await _context.ServiceTypes
                .Where(s => s.IsActive == true)
                .OrderByDescending(s => s.Id)
                .Take(5)
                .Select(s => s.Image)
                .ToListAsync();
            return serviceTypesImage;
        }

        public async Task<PaginatedResult<ServiceTypeDto>> SearchServiceTypeAsync(string searchValue, int pageNumber, int pageSize)
        {
            // Set a threshold for similarity; adjust this as needed (0 to 1, higher values for more exact matches)
            var threshold = 0.1;

            // Use raw SQL to filter based on trigram similarity, then paginate
            var serviceTypes = await _context.ServiceTypes
                .FromSqlRaw(@$"
                    SELECT * 
                    FROM public.""ServiceTypes""
                    WHERE ""IsActive"" = TRUE
                    AND similarity(""Name"", {{0}}) > {{1}}
                    ORDER BY ""Id""
                    LIMIT {{2}} OFFSET {{3}}",
                    searchValue, threshold, pageSize, (pageNumber - 1) * pageSize)
                .Include(st => st.ServicePackages)
                .ToListAsync();

            // Map to DTOs
            var serviceTypeDtos = _mapper.Map<IEnumerable<ServiceTypeDto>>(serviceTypes);

            // Get the total count for pagination (only count items matching the search criteria)
            var totalCount = await _context.ServiceTypes
                .Where(s => s.IsActive == true && EF.Functions.ILike(s.Name, $"%{searchValue}%"))
                .CountAsync();

            return new PaginatedResult<ServiceTypeDto>
            {
                Items = serviceTypeDtos,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }

    }
}
