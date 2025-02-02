using BE.Dtos;

namespace BE.Repositories.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<PaginatedResult<AppointmentDto>> GetAllAppointmentAsync(int status, int pageNumber, int pageSize);
        Task<AppointmentDto> GetAppointmentByIdAsync(int id);
        Task<IEnumerable<AppointmentDto>> GetAppointmentBySubAsync(int subId);
        Task AddAppointmentAsync(AppointmentCreateDto appointmentDto);
        Task UpdateAppointmentAsync(int id, AppointmentCreateDto appointmentDto);
        Task DeleteAppointmentAsync(int id);
        Task CompleteAppointmentAsync(AppointmentDetailCreateDto detail);
        Task ReviewAppointmentAsync(AppointmentReviewCreateDto review);

        Task<IEnumerable<DailyAppointmentsModel>> GetWeeklyAppointments(DateTime startDate);
        Task<IEnumerable<DailyAppointmentsModel>> GetWeeklyAppointmentsById(DateTime startDate, string staffId);
        Task ConfirmAppointment (int id, string staffId);
        Task<IEnumerable<PatientRecord>> GetPatientRecordAsync(string patientId);
        Task<PaginatedResult<AppointmentDto>> GetAllReviews(int pageNumber, int pageSize);
        Task<StaffReviewDto> GetReviewsForStaff(string staffId);

        Task UpdateApppointmentDaily();
    }
}
