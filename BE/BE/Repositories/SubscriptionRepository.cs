using AutoMapper;
using BE.Data;
using BE.Dtos;
using BE.Models;
using BE.Repositories.Interfaces;
using BE.Services;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Ocsp;
using System.Net.Mail;
using System.Security.Claims;

namespace BE.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ISendMailService _sendMailService;
        public SubscriptionRepository(AppDbContext context, IMapper mapper, ISendMailService sendMailService)
        {
            _context = context;
            _mapper = mapper;
            _sendMailService = sendMailService;
        }        

        public async Task<PaginatedResult<SubscriptionDto>> GetAllSubscriptionAsync(int status, int pageNumber, int pageSize)
        {
            var totalCount = await _context.Subscriptions.Where(s => (int)s.Status == status).CountAsync();
            var subscriptions = await _context.Subscriptions
                .Where(s => (int)s.Status == status)
                .OrderByDescending(s => s.SubscriptionDate)
                .Include(s => s.Patient)
                .Include(s => s.ServicePackage)
                .ThenInclude(ser => ser.ServiceType)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var subscriptionDtos = _mapper.Map<IEnumerable<SubscriptionDto>>(subscriptions);

            return new PaginatedResult<SubscriptionDto>
            {
                Items = subscriptionDtos,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }

        public async Task<SubscriptionDto> GetSubscriptionByIdAsync(int id)
        {
            var subscription = await _context.Subscriptions
                .Where(s=>s.Id == id)
                .Include(s => s.Patient)
                .Include(s => s.ServicePackage)
                .ThenInclude(ser => ser.ServiceType)
                .FirstOrDefaultAsync();

            var subscriptionDto = _mapper.Map<SubscriptionDto>(subscription);

            return subscriptionDto;
        }

        public async Task<PaginatedResult<SubscriptionDto>> GetAllSubscriptionByPatientIdAsync(string patientId, int pageNumber, int pageSize)
        {
            var totalCount = await _context.Subscriptions.Where(s => s.PatientId == patientId).CountAsync();
            var subscriptions = await _context.Subscriptions
                .Where(s => s.PatientId == patientId)
                .OrderByDescending(s => s.SubscriptionDate)
                .Include(s => s.Patient)
                .Include(s => s.ServicePackage)
                .ThenInclude(ser => ser.ServiceType)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var subscriptionDtos = _mapper.Map<IEnumerable<SubscriptionDto>>(subscriptions);

            return new PaginatedResult<SubscriptionDto>
            {
                Items = subscriptionDtos,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }

        public async Task<PaginatedResult<SubscriptionDto>> GetSubscriptionByPatientIdPaidAsync(string patientId, int pageNumber, int pageSize)
        {
            var totalCount = await _context.Subscriptions.Where(s => s.PatientId == patientId && s.IsPaid).CountAsync();
            var subscriptions = await _context.Subscriptions
                .Where(s => s.PatientId == patientId && s.IsPaid)
                .OrderByDescending(s => s.PaymentDate)
                .Include(s => s.Patient)
                .Include(s => s.ServicePackage)
                .ThenInclude(ser => ser.ServiceType)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var subscriptionDtos = _mapper.Map<IEnumerable<SubscriptionDto>>(subscriptions);

            return new PaginatedResult<SubscriptionDto>
            {
                Items = subscriptionDtos,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }

        public async Task<PaginatedResult<SubscriptionDto>> GetPaymentAsync(int pageNumber, int pageSize)
        {
            var totalCount = await _context.Subscriptions.Where(s => s.IsPaid).CountAsync();
            var subscriptions = await _context.Subscriptions
                .Where(s => s.IsPaid)
                .OrderByDescending(s => s.PaymentDate)
                .Include(s => s.Patient)
                .Include(s => s.ServicePackage)
                .ThenInclude(ser => ser.ServiceType)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var subscriptionDtos = _mapper.Map<IEnumerable<SubscriptionDto>>(subscriptions);

            return new PaginatedResult<SubscriptionDto>
            {
                Items = subscriptionDtos,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }

        public async Task<PaginatedResult<SubscriptionDto>> GetSubscriptionByPatientIdStatusAsync(string patientId, int status, int pageNumber, int pageSize)
        {
            var totalCount = await _context.Subscriptions.Where(s => s.PatientId == patientId && (int)s.Status == status).CountAsync();
            var subscriptions = await _context.Subscriptions
                .Where(s => s.PatientId == patientId && (int)s.Status == status)
                .OrderByDescending(s => s.SubscriptionDate)
                .Include(s => s.Patient)
                .Include(s => s.ServicePackage)
                .ThenInclude(ser => ser.ServiceType)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var subscriptionDtos = _mapper.Map<IEnumerable<SubscriptionDto>>(subscriptions);

            return new PaginatedResult<SubscriptionDto>
            {
                Items = subscriptionDtos,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }

        public async Task<SubscriptionDto> AddSubscriptionAsync(SubscriptionCreateDto subscriptionDto)
        {
            var pendingSubscriptionsCount = await _context.Subscriptions
                .Where(s => s.PatientId == subscriptionDto.PatientId && s.Status == SubscriptionStatus.Pending)
                .CountAsync();

            if (pendingSubscriptionsCount >= 2)
            {
                throw new InvalidOperationException("Bạn đã có 2 gói dịch vụ chưa thanh toán, không thể thêm gói mới.");
            }
            //
            var sub = _mapper.Map<Subscription>(subscriptionDto);
            sub.Status = SubscriptionStatus.Pending;

            var pack = await _context.ServicePackages.Where(s => s.Id == subscriptionDto.ServicePackageId).FirstOrDefaultAsync();
            
            if (subscriptionDto.StartDate != null && pack.DurationInMonths != null)
            {
                sub.EndDate = subscriptionDto.StartDate.AddMonths(pack.DurationInMonths.Value);
            }
            sub.Total = pack.Price;
            _context.Subscriptions.Add(sub);
            await _context.SaveChangesAsync();
            var returnModel = _mapper.Map<SubscriptionDto>(sub);

            var user = await _context.Users.FindAsync(sub.PatientId);

            var tmpPack = await _context.ServicePackages.Where(p => p.Id == sub.ServicePackageId)
                .Include(st => st.ServiceType)
                .FirstOrDefaultAsync();
            var packDto = _mapper.Map<ServicePackageDto>(tmpPack);

            if (user != null)
            {
                // Gửi email xác nhận đặt hàng
                var email = user.Email;
                var subject = "Homecare Service - Xác nhận đăng ký dịch vụ";

                var detailHtml =
                    "<dl>" +
                     "<dt>Khách hàng: " + user.Fullname + " </dt>" +
                     "<dt>Dịch vụ: " + packDto.ServiceTypeName + " </dt>" +
                     "<dt>Gói dịch vụ: " + packDto.Name + " </dt>" +
                     "<dt>Thời gian: " + packDto.NumberOfSessions + " buổi / " + packDto.DurationInMonths + " tháng " + " </dt>" +
                     "<dt>Ngày đăng ký: " + returnModel.SubscriptionDate.ToString("dd/MM/yyyy") + " </dt>" +
                     "<dt>Giá: " + packDto.Price.ToString("N0") + " VNĐ" + " </dt>" +
                     "</dl>";

                var htmlMessage =
                     "<p>Xin chào!,</p>\r\n   " +
                     "<p>Cảm ơn bạn đã đăng ký dịch vụ tại trung tâm của chúng tôi.</p>" +
                     detailHtml +
                     "<p>Vui lòng thanh toán để sử dụng dịch vụ đã đăng ký.</p>" +
                     "<p>Chúng tôi hy vọng bạn sẽ hài lòng về dịch vụ.</p>" +
                     "<p>Chúc bạn một ngày tốt lành❤️</p>" +
                    "<br>" +
                    "<p>Thân mến,</p>" +
                    "<p>Homecare Service</p>";

                await _sendMailService.SendEmailAsync(email, subject, htmlMessage);
            }

            return returnModel;
        }

        public async Task UpdateSubscriptionAsync(int id, SubscriptionCreateDto subscriptionDto)
        {
            var sub = await _context.Subscriptions.FindAsync(id);
            if (sub != null)
            {
                sub.StartDate = subscriptionDto.StartDate;
                sub.EndDate = subscriptionDto.EndDate;
                _context.Subscriptions.Update(sub);
            }
            await _context.SaveChangesAsync();
        }

        public async Task ActiveSubscriptionAsync(int id)
        {
            var sub = await _context.Subscriptions.FindAsync(id);
            if (sub != null)
            {
                sub.Status = SubscriptionStatus.Active;
                _context.Subscriptions.Update(sub);
            }
            await _context.SaveChangesAsync();
        }

        public async Task CompleteSubscriptionAsync(int id)
        {
            var sub = await _context.Subscriptions.FindAsync(id);
            if (sub != null)
            {
                sub.Status = SubscriptionStatus.Completed;
                _context.Subscriptions.Update(sub);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSubscriptionAsync(int id)
        {
            var sub = await _context.Subscriptions.FindAsync(id);
            if (sub != null)
            {
                sub.Status = SubscriptionStatus.Cancelled;
                _context.Subscriptions.Update(sub);
            }
            await _context.SaveChangesAsync();
        }
    }
}
