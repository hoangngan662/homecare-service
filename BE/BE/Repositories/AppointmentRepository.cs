using AutoMapper;
using BE.Data;
using BE.Dtos;
using BE.Models;
using BE.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;

namespace BE.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public AppointmentRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PaginatedResult<AppointmentDto>> GetAllAppointmentAsync(int status, int pageNumber, int pageSize)
        {
            var totalCount = await _context.Appointments.Where(a => (int)a.Status == status).CountAsync();
            var app = await _context.Appointments
                .Where(a => (int)a.Status == status)
                .OrderByDescending(a => a.AppointmentDate)
                .ThenBy(a => a.ShiftId)
                .Include(s => s.Subscription)
                .ThenInclude(sub => sub.Patient)
                .Include(s => s.Subscription)
                .ThenInclude(sub => sub.ServicePackage)
                .ThenInclude(ser => ser.ServiceType)
                .Include(s => s.Staff)
                .Include(s => s.AppointmentDetail)
                .Include(s => s.AppointmentReview)
                .Include(a => a.Shift)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var appDtos = _mapper.Map<IEnumerable<AppointmentDto>>(app);

            return new PaginatedResult<AppointmentDto>
            {
                Items = appDtos,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }

        public async Task<AppointmentDto> GetAppointmentByIdAsync(int id)
        {
            var app = await _context.Appointments
                .Where(s => s.Id == id)
                .Include(s => s.Subscription)
                .ThenInclude(sub => sub.Patient)
                .Include(s => s.Subscription)
                .ThenInclude(sub => sub.ServicePackage)
                .ThenInclude(ser => ser.ServiceType)
                .Include(s => s.Staff)
                .Include(s => s.AppointmentDetail)
                .Include(s => s.AppointmentReview)
                .Include(a => a.Shift)
                .FirstOrDefaultAsync();
            var appDto = _mapper.Map<AppointmentDto>(app);

            return appDto;
        }

        public async Task AddAppointmentAsync(AppointmentCreateDto appointmentDto)
        {
            var app = _mapper.Map<Appointment>(appointmentDto);
            app.Status = AppointmentStatus.Pending;
            _context.Appointments.Add(app);
            var sub = await _context.Subscriptions.FindAsync(app.SubscriptionId);
            if (sub != null)
            {
                sub.UsedSessions++;
                var pack = await _context.ServicePackages.FindAsync(sub.ServicePackageId);
                if (pack != null)
                {
                    if (sub.UsedSessions >= pack.NumberOfSessions)
                    {
                        sub.Status = SubscriptionStatus.Completed;
                    }
                }
                _context.Subscriptions.Update(sub);
            }
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAppointmentAsync(int id, AppointmentCreateDto appointmentDto)
        {
            var app = await _context.Appointments.FindAsync(id);
            if (app != null) { 
                app.AppointmentDate = appointmentDto.AppointmentDate;
                app.ShiftId = appointmentDto.ShiftId;
                app.Address = appointmentDto.Address;
                app.Phone = appointmentDto.Phone;
                app.Note = appointmentDto.Note;
                _context.Appointments.Update(app);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAppointmentAsync(int id)
        {
            var app = await _context.Appointments.FindAsync(id);
            if (app != null)
            {
                app.Status = AppointmentStatus.Cancelled;
                _context.Appointments.Update(app);
            }
            await _context.SaveChangesAsync();

            var sub = await _context.Subscriptions.FindAsync(app.SubscriptionId);
            if (sub != null)
            {
                sub.UsedSessions--;
                sub.Status = SubscriptionStatus.Active;
                _context.Subscriptions.Update(sub);
            }
            await _context.SaveChangesAsync();
        }

        public async Task CompleteAppointmentAsync(AppointmentDetailCreateDto detail)
        {
            var appDetail = _mapper.Map<AppointmentDetail>(detail);
            _context.AppointmentDetails.Add(appDetail);
            var app = await _context.Appointments.FindAsync(detail.AppointmentId);
            if (app != null)
            {
                app.Status = AppointmentStatus.Completed;
                _context.Appointments.Update(app);
            }
            await _context.SaveChangesAsync();
        }

        public async Task ReviewAppointmentAsync(AppointmentReviewCreateDto review)
        {
            var appReview = _mapper.Map<AppointmentReview>(review);
            appReview.ReviewDate = DateTime.Now;
            _context.AppointmentReviews.Add(appReview);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AppointmentDto>> GetAppointmentBySubAsync(int subId)
        {
            var app = await _context.Appointments
                .Where(a => a.SubscriptionId == subId)
                .OrderByDescending(a => a.AppointmentDate)
                .ThenBy(a => a.ShiftId)
                .Include(s => s.Subscription)
                .ThenInclude(sub => sub.Patient)
                .Include(s => s.Subscription)
                .ThenInclude(sub => sub.ServicePackage)
                .Include(s => s.Staff)
                .Include(s => s.AppointmentDetail)
                .Include(s => s.AppointmentReview)
                .Include(a => a.Shift)
                .ToListAsync();
            var appDtos = _mapper.Map<IEnumerable<AppointmentDto>>(app);

            return appDtos;
        }

        public async Task<IEnumerable<DailyAppointmentsModel>> GetWeeklyAppointments(DateTime startDate)
        {
            DateTime weekStartDate = startDate.Date;
            DateTime weekEndDate = weekStartDate.AddDays(4);

            // Fetch appointments within the week range
            var appointments = await _context.Appointments
                .Where(a => a.AppointmentDate >= weekStartDate && a.AppointmentDate <= weekEndDate)
                .OrderByDescending(a => a.AppointmentDate)
                .ThenBy(a => a.ShiftId)
                .Include(s => s.Subscription)
                    .ThenInclude(sub => sub.Patient)
                .Include(s => s.Subscription)
                    .ThenInclude(sub => sub.ServicePackage)
                    .ThenInclude(ser => ser.ServiceType)
                .Include(s => s.Staff)
                .Include(s => s.AppointmentDetail)
                .Include(s => s.AppointmentReview)
                .Include(a => a.Shift)
                .ToListAsync();

            var appDtos = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);

            // Define all possible shifts
            var allShiftIds = new List<int> { 1, 2, 3, 4, 5 }; // Adjust based on your actual shift IDs

            // Prepare the full week structure with all days and shifts
            var weeklyAppointments = Enumerable.Range(0, 5)
                .Select(offset =>
                {
                    DateTime currentDay = weekStartDate.AddDays(offset);
                    return new DailyAppointmentsModel
                    {
                        Date = currentDay.ToString("yyyy-MM-dd"),
                        Shifts = allShiftIds.Select(shiftId => new ShiftAppointmentsModel
                        {
                            ShiftId = shiftId,
                            Appointments = appDtos
                                .Where(a => a.AppointmentDate.Date == currentDay && a.ShiftId == shiftId)
                                .ToList()
                        })
                        .ToList()
                    };
                })
                .ToList();

            return weeklyAppointments;
        }

        public async Task<IEnumerable<DailyAppointmentsModel>> GetWeeklyAppointmentsById(DateTime startDate, string staffId)
        {
            DateTime weekStartDate = startDate.Date;
            DateTime weekEndDate = weekStartDate.AddDays(4);

            // Fetch appointments within the week range
            var appointments = await _context.Appointments
                .Where(a => a.AppointmentDate >= weekStartDate && a.AppointmentDate <= weekEndDate && a.StaffId == staffId)
                .OrderByDescending(a => a.AppointmentDate)
                .ThenBy(a => a.ShiftId)
                .Include(s => s.Subscription)
                    .ThenInclude(sub => sub.Patient)
                .Include(s => s.Subscription)
                    .ThenInclude(sub => sub.ServicePackage)
                    .ThenInclude(ser => ser.ServiceType)
                .Include(s => s.Staff)
                .Include(s => s.AppointmentDetail)
                .Include(s => s.AppointmentReview)
                .Include(a => a.Shift)
                .ToListAsync();

            var appDtos = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);

            // Define all possible shifts
            var allShiftIds = new List<int> { 1, 2, 3, 4, 5 }; // Adjust based on your actual shift IDs

            // Prepare the full week structure with all days and shifts
            var weeklyAppointments = Enumerable.Range(0, 5)
                .Select(offset =>
                {
                    DateTime currentDay = weekStartDate.AddDays(offset);
                    return new DailyAppointmentsModel
                    {
                        Date = currentDay.ToString("yyyy-MM-dd"),
                        Shifts = allShiftIds.Select(shiftId => new ShiftAppointmentsModel
                        {
                            ShiftId = shiftId,
                            Appointments = appDtos
                                .Where(a => a.AppointmentDate.Date == currentDay && a.ShiftId == shiftId)
                                .ToList()
                        })
                        .ToList()
                    };
                })
                .ToList();

            return weeklyAppointments;
        }

        public async Task ConfirmAppointment(int id, string staffId)
        {
            var app = await _context.Appointments.FindAsync(id);
            if (app != null)
            {
                app.StaffId = staffId;
                app.Status = AppointmentStatus.Scheduled;
                _context.Appointments.Update(app);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PatientRecord>> GetPatientRecordAsync(string patientId)
        {
            // Lấy danh sách lịch hẹn đã hoàn thành của bệnh nhân theo patientId
            var appointments = await _context.Appointments
                .Where(a => a.Status == AppointmentStatus.Completed && a.Subscription.PatientId == patientId)
                .Include(s => s.Subscription)
                    .ThenInclude(sub => sub.Patient)
                .Include(s => s.Subscription)
                    .ThenInclude(sub => sub.ServicePackage)
                    .ThenInclude(ser => ser.ServiceType)
                .Include(s => s.Staff)
                .Include(s => s.AppointmentDetail)
                .Include(s => s.AppointmentReview)
                .Include(a => a.Shift)
                .ToListAsync();
            var appDtos = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);

            var patientRecords = appDtos
                .GroupBy(a => a.ServiceTypeName)
                .Select(g => new PatientRecord
                {
                    ServiceType = g.Key,
                    Appointments = g.OrderBy(a => a.AppointmentDate).ToList()
                })
                .OrderBy(record => record.Appointments.First().AppointmentDate)
                .ToList();

            return patientRecords;
        }
        public async Task<PaginatedResult<AppointmentDto>> GetAllReviews(int pageNumber, int pageSize)
        {
            var totalCount = await _context.Appointments
                .Where(a => a.Status == AppointmentStatus.Completed && a.AppointmentReview != null)
                .CountAsync();
            var app = await _context.Appointments
                .Where(a => a.Status == AppointmentStatus.Completed && a.AppointmentReview != null)
                .OrderByDescending(a => a.AppointmentReview.ReviewDate)
                .ThenBy(a => a.AppointmentDate)
                .Include(s => s.Subscription)
                .ThenInclude(sub => sub.Patient)
                .Include(s => s.Subscription)
                .ThenInclude(sub => sub.ServicePackage)
                .ThenInclude(ser => ser.ServiceType)
                .Include(s => s.Staff)
                .Include(s => s.AppointmentDetail)
                .Include(s => s.AppointmentReview)
                .Include(a => a.Shift)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var appDtos = _mapper.Map<IEnumerable<AppointmentDto>>(app);

            return new PaginatedResult<AppointmentDto>
            {
                Items = appDtos,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }

        public async Task<StaffReviewDto> GetReviewsForStaff(string staffId)
        {
            var reviews = await _context.AppointmentReviews
                .Include(r => r.Appointment)
                .Where(r => r.Appointment.StaffId == staffId)
                .OrderByDescending(r => r.StaffRating)
                .ToListAsync();

            var avgStar = reviews.Any() ? reviews.Average(r => r.StaffRating) : 0;

            var starCount = Enumerable.Range(1, 5)
                .Select(star => reviews.Count(r => r.StaffRating == star))
                .ToList();

            var appointmentReviews = _mapper.Map<List<AppointmentReviewDto>>(reviews);

            var staffReviewDto = new StaffReviewDto
            {
                StaffId = staffId,
                TotalReviews = appointmentReviews.Count,
                StarCount = starCount,
                AvgStar = (decimal)avgStar,
                AppointmentReviews = appointmentReviews.Take(5).ToList()
            };

            return staffReviewDto;
        }

        public async Task UpdateApppointmentDaily()
        {
            var apps = await _context.Appointments
                .Where(a => a.AppointmentDate < DateTime.Today &&
                            (a.Status == AppointmentStatus.Pending || a.Status == AppointmentStatus.Scheduled))
                .ToListAsync();

            if (apps != null && apps.Any())
            {
                foreach (var app in apps)
                {
                    app.Status = AppointmentStatus.Cancelled;
                }

                // Save changes to the database
                _context.Appointments.UpdateRange(apps);
                await _context.SaveChangesAsync();
            }
        }

    }
}
