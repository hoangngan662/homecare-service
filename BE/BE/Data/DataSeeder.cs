using BE.Models;
using Microsoft.AspNetCore.Identity;
using static System.Net.Mime.MediaTypeNames;

namespace BE.Data
{
    public static class DataSeeder
    {
        public static List<IdentityRole> ListRole => new List<IdentityRole>
        {
            new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = "2", Name = "Staff", NormalizedName = "STAFF" },
            new IdentityRole { Id = "3", Name = "Patient", NormalizedName = "PATIENT" }
        };

        //public static List<ServiceType> ListServiceType => new List<ServiceType>
        //{
        //    new ServiceType
        //    {
        //        Id = 1,
        //        Name = "Dịch vụ Chăm sóc Y tế Tại nhà",
        //        Description = "Dịch vụ chăm sóc y tế tại nhà cung cấp hỗ trợ y tế chuyên nghiệp cho người bệnh, người già hoặc những ai cần chăm sóc sức khỏe lâu dài. Các chuyên gia y tế bao gồm bác sĩ, y tá và kỹ thuật viên y tế sẽ đến tận nhà để thực hiện kiểm tra sức khỏe, điều trị, và theo dõi tình trạng bệnh lý của khách hàng. Dịch vụ giúp giảm thiểu chi phí bệnh viện và mang lại sự thoải mái, tiện lợi cho bệnh nhân.",
        //        Image = "/images/servicetypes/1.png"
        //    },
        //    new ServiceType
        //    {
        //        Id = 2,
        //        Name = "Dịch vụ Vật lý trị liệu Tại nhà",
        //        Description = "Dịch vụ vật lý trị liệu tại nhà giúp cải thiện chức năng vận động và giảm đau thông qua các bài tập và phương pháp trị liệu đặc biệt. Các chuyên gia sẽ xây dựng kế hoạch điều trị phù hợp với từng khách hàng, từ các bệnh về cơ xương khớp đến phục hồi sau chấn thương. Dịch vụ này giúp tiết kiệm thời gian di chuyển và mang lại sự thoải mái trong quá trình hồi phục.",
        //        Image = "/images/servicetypes/4.png"
        //    },
        //    new ServiceType
        //    {
        //        Id = 3,
        //        Name = "Dịch vụ Chăm sóc sau phẫu thuật Tại nhà",
        //        Description = "Dịch vụ này cung cấp sự chăm sóc đặc biệt cho bệnh nhân vừa trải qua phẫu thuật. Nhân viên y tế sẽ hỗ trợ quá trình phục hồi bao gồm thay băng, kiểm tra vết mổ, quản lý đau, và hỗ trợ sinh hoạt hàng ngày. Với dịch vụ này, bệnh nhân sẽ được theo dõi và chăm sóc một cách an toàn và hiệu quả ngay tại nhà mà không cần phải đến bệnh viện thường xuyên.",
        //        Image = "/images/servicetypes/6.png"
        //    },
        //    new ServiceType
        //    {
        //        Id = 4,
        //        Name = "Dịch vụ Theo dõi sức khỏe định kỳ",
        //        Description = "Theo dõi sức khỏe định kỳ, bao gồm kiểm tra các chỉ số sức khỏe, theo dõi các bệnh mãn tính và tư vấn sức khỏe.",
        //        Image = "/images/servicetypes/3.png"
        //    },
        //};

        //public static List<ServicePackage> ListServicePackage => new List<ServicePackage>
        //{
        //    new ServicePackage { Id = 1, Name = "Gói 1 buổi", Price = 600000, NumberOfSessions = 1, DurationInMonths = 1, ServiceTypeId = 1 },
        //    new ServicePackage { Id = 2, Name = "Gói 5 buổi", Price = 2500000, NumberOfSessions = 5, DurationInMonths = 1, ServiceTypeId = 1 },
        //    new ServicePackage { Id = 3, Name = "Gói 10 buổi", Price = 4800000, NumberOfSessions = 10, DurationInMonths = 2, ServiceTypeId = 1 },
        //    new ServicePackage { Id = 4, Name = "Gói 20 buổi", Price = 9000000, NumberOfSessions = 20, DurationInMonths = 3, ServiceTypeId = 1 },

        //    new ServicePackage { Id = 5, Name = "Gói 5 buổi", Price = 2500000, NumberOfSessions = 5, DurationInMonths = 1, ServiceTypeId = 2 },
        //    new ServicePackage { Id = 6, Name = "Gói 10 buổi", Price = 4500000, NumberOfSessions = 10, DurationInMonths = 2, ServiceTypeId = 2 },
        //    new ServicePackage { Id = 7, Name = "Gói 20 buổi", Price = 8500000, NumberOfSessions = 20, DurationInMonths = 2, ServiceTypeId = 2 },

        //    new ServicePackage { Id = 8, Name = "Gói 3 buổi", Price = 1500000, NumberOfSessions = 3, DurationInMonths = 1, ServiceTypeId = 3 },
        //    new ServicePackage { Id = 9, Name = "Gói 5 buổi", Price = 2200000, NumberOfSessions = 5, DurationInMonths = 2, ServiceTypeId = 3 },

        //    new ServicePackage { Id = 10, Name = "Gói 1 buổi", Price = 300000, NumberOfSessions = 1, DurationInMonths = 1, ServiceTypeId = 4 },
        //    new ServicePackage { Id = 11, Name = "Gói 5 buổi", Price = 1400000, NumberOfSessions = 5, DurationInMonths = 1, ServiceTypeId = 4 },
        //    new ServicePackage { Id = 12, Name = "Gói 10 buổi", Price = 2500000, NumberOfSessions = 10, DurationInMonths = 2, ServiceTypeId = 4 },
        //    new ServicePackage { Id = 13, Name = "Gói 20 buổi", Price = 4500000, NumberOfSessions = 20, DurationInMonths = 3, ServiceTypeId = 4 },
        //};

        public static List<Shift> ListShift => new List<Shift>
        {
            new Shift { Id = 1, Name = "Ca 1", StartTime = new TimeOnly(7, 30), EndTime = new TimeOnly(9, 30) },
            new Shift { Id = 2, Name = "Ca 2", StartTime = new TimeOnly(10, 00), EndTime = new TimeOnly(12, 00) },
            new Shift { Id = 3, Name = "Ca 3", StartTime = new TimeOnly(13, 0), EndTime = new TimeOnly(15, 0) },
            new Shift { Id = 4, Name = "Ca 4", StartTime = new TimeOnly(15, 30), EndTime = new TimeOnly(17, 30) },
            new Shift { Id = 5, Name = "Ca 5", StartTime = new TimeOnly(18, 0), EndTime = new TimeOnly(20, 0) }
        };

    }

}
