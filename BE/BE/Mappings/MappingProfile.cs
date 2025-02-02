using AutoMapper;
using BE.Dtos;
using BE.Models;
using Microsoft.AspNetCore.Identity;

namespace BE.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ServiceType, ServiceTypeDto>()
            .ForMember(dest => dest.SessionPrice, opt => opt.MapFrom(src =>
                src.ServicePackages != null && src.ServicePackages.Any()
                    ? src.ServicePackages.OrderBy(p => p.Id).First().Price
                    : 0))
            .ForMember(dest => dest.ServicePackages, opt => opt.MapFrom(src =>
                src.ServicePackages != null
                    ? src.ServicePackages.Where(p => p.IsActive == true)
                    : new List<ServicePackage>()));
            CreateMap<ServiceTypeDto, ServiceType>();
            CreateMap<ServiceTypeCreateDto, ServiceType>();

            CreateMap<ServicePackage, ServicePackageDto>();
            CreateMap<ServicePackageDto, ServicePackage>();
            CreateMap<ServicePackageCreateDto, ServicePackage>();

            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>().ForMember(dest => dest.Roles, opt => opt.Ignore());
            CreateMap<UserCreateDto, User>();


            CreateMap<IdentityRole, RoleDto>();
            CreateMap<RoleDto, IdentityRole>();

            CreateMap<Subscription, SubscriptionDto>()
                .ForMember(dest => dest.ServiceTypeName, opt => opt.MapFrom(src => src.ServicePackage.ServiceType.Name))
                .ForMember(dest => dest.ServiceTypeId, opt => opt.MapFrom(src => src.ServicePackage.ServiceType.Id));
            CreateMap<SubscriptionDto, Subscription>();
            CreateMap<SubscriptionCreateDto, Subscription>();

            CreateMap<Appointment, AppointmentDto>()
                .ForMember(dest => dest.PatientFullName, opt => opt.MapFrom(src => src.Subscription.Patient.Fullname)) 
                .ForMember(dest => dest.ServicePackageName, opt => opt.MapFrom(src => src.Subscription.ServicePackage.Name))
                .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.Subscription.Patient.Id))
                .ForMember(dest => dest.ServicePackageId, opt => opt.MapFrom(src => src.Subscription.ServicePackage.Id))
                .ForMember(dest => dest.ServiceTypeId, opt => opt.MapFrom(src => src.Subscription.ServicePackage.ServiceType.Id))
                .ForMember(dest => dest.ServiceTypeName, opt => opt.MapFrom(src => src.Subscription.ServicePackage.ServiceType.Name))
                .ForMember(dest => dest.AppointmentDetailDto, opt => opt.MapFrom(src => src.AppointmentDetail))
                .ForMember(dest => dest.AppointmentReviewDto, opt => opt.MapFrom(src => src.AppointmentReview))
                .ForMember(dest => dest.ShiftTime, opt => opt.MapFrom(src =>
                                    src.Shift.StartTime.ToString("HH:mm") + " - " + src.Shift.EndTime.ToString("HH:mm")));
            CreateMap<AppointmentDto, Appointment>();
            CreateMap<AppointmentCreateDto, Appointment>();

            CreateMap<AppointmentDetail, AppointmentDetailDto>();                
            CreateMap<AppointmentDetailDto, AppointmentDetail>();
            CreateMap<AppointmentDetailCreateDto, AppointmentDetail>();

            CreateMap<AppointmentReview, AppointmentReviewDto>();
            CreateMap<AppointmentReviewDto, AppointmentReview>();
            CreateMap<AppointmentReviewCreateDto, AppointmentReview>();

            CreateMap<Shift, ShiftDto>()
                .ForMember(dest => dest.ShiftTime, opt => opt.MapFrom(src => src.StartTime.ToString("HH:mm") + " - " + src.EndTime.ToString("HH:mm")));
        }
    }
}
