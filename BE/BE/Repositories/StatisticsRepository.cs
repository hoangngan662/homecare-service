using BE.Data;
using BE.Dtos;
using BE.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BE.Repositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly AppDbContext _context;
        public StatisticsRepository(AppDbContext context) { 
            _context = context;
        }        

        public async Task<StatisticsDto> GetStatisticsAsync()
        {
            var patientCount = await _context.UserRoles.Where(ur => ur.RoleId == "3").CountAsync();
            var staffCount = await _context.UserRoles.Where(ur => ur.RoleId != "3").CountAsync();
            var serviceCount = await _context.ServiceTypes.Where(s => s.IsActive == true).CountAsync();
            var packageCount = await _context.ServicePackages.Where(p => p.IsActive == true).CountAsync();
            var subsCount = await _context.Subscriptions.Where(s => s.IsPaid).CountAsync();
            var appCount = await _context.Appointments.Where(s => s.Status != Models.AppointmentStatus.Cancelled).CountAsync();
            var totalRevenue = await _context.Subscriptions
                .Where(s => s.Status == Models.SubscriptionStatus.Active || s.Status == Models.SubscriptionStatus.Completed)
                .SumAsync(s => s.Total);
            return new StatisticsDto
            {
                TotalPatients = patientCount,
                TotalStaffs = staffCount,
                TotalServices = serviceCount,
                TotalServicePackages = packageCount,
                TotalSubscription = subsCount,
                TotalAppointments = appCount,
                TotalRevenue = totalRevenue
            };
        }

        public async Task<RevenueStatisticsDto> GetRevenueByServiceTypeAsync()
        {
            var revenueByServiceType = await _context.ServiceTypes
                .GroupJoin(
                    _context.Subscriptions.Where(s => s.IsPaid == true),
                    serviceType => serviceType.Id,
                    subscription => subscription.ServicePackage.ServiceTypeId,
                    (serviceType, subscriptions) => new RevenueByServiceTypeDto
                    {
                        ServiceTypeId = serviceType.Id,
                        ServiceTypeName = serviceType.Name,
                        TotalRevenue = subscriptions.Sum(s => s.Total)
                    }
                )
                .ToListAsync();

            var totalRevenue = revenueByServiceType.Sum(r => r.TotalRevenue);

            return new RevenueStatisticsDto
            {
                RevenueByServiceType = revenueByServiceType,
                TotalRevenue = totalRevenue
            };
        }
        public async Task<List<ServiceStatsDto>> GetServiceStatsAsync()
        {
            var subByServiceType = await _context.ServiceTypes
                .GroupJoin(
                    _context.Subscriptions.Where(s => s.IsPaid == true),
                    serviceType => serviceType.Id,
                    subscription => subscription.ServicePackage.ServiceTypeId,
                    (serviceType, subscriptions) => new ServiceStatsDto
                    {
                        ServiceTypeName = serviceType.Name,
                        TotalSubscriptions = subscriptions.Count(),
                        TotalAppointments = subscriptions
                            .SelectMany(subscription => subscription.Appointments)
                            .Count(appointment => appointment.Status != Models.AppointmentStatus.Cancelled)
                    }
                )
                .ToListAsync();
            return subByServiceType;
        }

        public async Task<List<CustomerAgeStat>> GetCustomerAgeStatsAsync()
        {
            var now = DateTime.UtcNow;
            var ageGroups = new Dictionary<string, int>
            {
                { "0-18", 0 },
                { "19-30", 0 },
                { "31-40", 0 },
                { "41-50", 0 },
                { "51-60", 0 },
                { "61+", 0 }
            };

            var usersInRole = new List<string>();
            usersInRole = await _context.UserRoles
                .Where(ur => ur.RoleId == "3")
                .Select(ur => ur.UserId)
                .ToListAsync();
            var patients = await _context.Users
                .Where(u => usersInRole.Contains(u.Id) && !u.IsDeleted)
                .ToListAsync();

            foreach (var patient in patients)
            {
                var age = now.Year - patient.DoB.Year;
                if (patient.DoB.Date > now.AddYears(-age)) age--;

                if (age <= 18) ageGroups["0-18"]++;
                else if (age <= 30) ageGroups["19-30"]++;
                else if (age <= 40) ageGroups["31-40"]++;
                else if (age <= 50) ageGroups["41-50"]++;
                else if (age <= 60) ageGroups["51-60"]++;
                else ageGroups["61+"]++;
            }

            var result = ageGroups.Select(g => new CustomerAgeStat
            {
                AgeGroup = g.Key,
                Count = g.Value
            }).ToList();

            return result;
        }

        public async Task<AnnualRevenueDto> GetAnnualRevenueAsync(int year)
        {
            // Lấy dữ liệu doanh thu theo tháng từ cơ sở dữ liệu
            var monthlyRevenue = await _context.Subscriptions
                .Where(s => s.IsPaid && s.StartDate.Year == year)
                .GroupBy(s => s.StartDate.Month)
                .Select(g => new MonthlyRevenueDto
                {
                    Month = $"Tháng {g.Key}",
                    TotalRevenue = g.Sum(s => s.Total)
                })
                .ToListAsync();

            // Tạo danh sách tháng từ 1 đến 12
            var allMonths = Enumerable.Range(1, 12).Select(month =>
                new MonthlyRevenueDto
                {
                    Month = $"Tháng {month}",
                    TotalRevenue = monthlyRevenue.FirstOrDefault(m => m.Month == $"Tháng {month}")?.TotalRevenue ?? 0
                }).ToList();

            // Tính tổng doanh thu cả năm
            var totalAnnualRevenue = allMonths.Sum(m => m.TotalRevenue);

            return new AnnualRevenueDto
            {
                Year = year,
                TotalAnnualRevenue = totalAnnualRevenue,
                MonthlyRevenues = allMonths
            };
        }

        public async Task<ReviewStatDto> GetReviewStatAsync()
        {
            var reviews = await _context.AppointmentReviews.ToListAsync(); 

            int totalReviews = reviews.Count;

            var starCount = new List<int>();
            var staffStarCount = new List<int>();
            for (int i = 1; i <= 5; i++)
            {
                int count = reviews.Count(r => r.AppointmentRating == i);
                starCount.Add(count);
                int cnt = reviews.Count(r => r.StaffRating == i);
                staffStarCount.Add(cnt);
            }

            decimal avgStar = totalReviews > 0 ? (decimal)reviews.Average(r => r.AppointmentRating) : 0;
            decimal staffAvgStar = totalReviews > 0 ? (decimal)reviews.Average(r => r.StaffRating) : 0;

            var reviewStat = new ReviewStatDto
            {
                TotalReviews = totalReviews,
                StarCount = starCount,
                AvgStar = avgStar,
                StaffStarCount = staffStarCount,
                StaffAvgStar = staffAvgStar,
            };

            return reviewStat;
        }

        public async Task<List<ServiceReviewStatDto>> GetServiceReviewStatAsync()
        {
            // Fetch all services in the system
            var services = await _context.ServiceTypes.ToListAsync(); // Assuming you have a Services DbSet

            // Fetch reviews and group them by service
            var reviews = await _context.AppointmentReviews
                .Include(r => r.Appointment)
                    .ThenInclude(a => a.Subscription)
                        .ThenInclude(s => s.ServicePackage)
                            .ThenInclude(sp => sp.ServiceType) // Assuming ServiceType is included if needed
                .ToListAsync();

            // Group reviews by ServiceId
            var reviewStats = reviews
                .GroupBy(r => new
                {
                    ServiceId = r.Appointment.Subscription.ServicePackage.ServiceTypeId,
                    ServiceName = r.Appointment.Subscription.ServicePackage.ServiceType.Name
                })
                .Select(g => new
                {
                    ServiceId = g.Key.ServiceId,
                    ServiceName = g.Key.ServiceName,
                    TotalReviews = g.Count(),
                    StarCount = new List<int>
                    {
                g.Count(r => r.AppointmentRating == 1),
                g.Count(r => r.AppointmentRating == 2),
                g.Count(r => r.AppointmentRating == 3),
                g.Count(r => r.AppointmentRating == 4),
                g.Count(r => r.AppointmentRating == 5),
                    },
                    AvgStar = g.Count() > 0 ? (decimal)g.Average(r => r.AppointmentRating) : 0m
                })
                .ToList();

            // Prepare the final result with all services
            var serviceReviewStats = services.Select(service => new ServiceReviewStatDto
            {
                ServiceId = service.Id, // Adjust as necessary
                ServiceName = service.Name, // Replace with actual property
                TotalReviews = reviewStats.FirstOrDefault(rs => rs.ServiceId == service.Id)?.TotalReviews ?? 0,
                StarCount = reviewStats.FirstOrDefault(rs => rs.ServiceId == service.Id)?.StarCount ?? new List<int> { 0, 0, 0, 0, 0 },
                AvgStar = reviewStats.FirstOrDefault(rs => rs.ServiceId == service.Id)?.AvgStar ?? 0m
            })
            .ToList();

            return serviceReviewStats;
        }
    }
}
