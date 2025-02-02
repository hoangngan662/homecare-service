using BE.Dtos;
using BE.Repositories;
using BE.Repositories.Interfaces;

namespace BE.Services
{
    public class AppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<PaginatedResult<AppointmentDto>> GetAllAppointmentAsync(int status, int pageNumber, int pageSize)
        {
            return await _appointmentRepository.GetAllAppointmentAsync(status, pageNumber, pageSize);
        }

        public async Task<AppointmentDto> GetAppointmentByIdAsync(int id)
        {
            var app = await _appointmentRepository.GetAppointmentByIdAsync(id);
            return app;
        }

        public async Task AddAppointmentAsync(AppointmentCreateDto appointmentDto)
        {
            await _appointmentRepository.AddAppointmentAsync(appointmentDto);
        }
        public async Task UpdateAppointmentAsync(int id, AppointmentCreateDto appointmentDto)
        {
            await _appointmentRepository.UpdateAppointmentAsync(id, appointmentDto);
        }
        public async Task DeleteAppointmentAsync(int id)
        {
            await _appointmentRepository.DeleteAppointmentAsync(id);
        }
        public async Task CompleteAppointmentAsync(AppointmentDetailCreateDto detail)
        {
            await _appointmentRepository.CompleteAppointmentAsync(detail);
        }

        public async Task ReviewAppointmentAsync(AppointmentReviewCreateDto review)
        {
            await _appointmentRepository.ReviewAppointmentAsync(review);
        }

        public async Task<IEnumerable<AppointmentDto>> GetAppointmentBySubAsync(int subId)
        {
            return await _appointmentRepository.GetAppointmentBySubAsync(subId);
        }

        public async Task<IEnumerable<DailyAppointmentsModel>> GetWeeklyAppointments(DateTime startDate)
        {
            return await _appointmentRepository.GetWeeklyAppointments(startDate);
        }

        public async Task<IEnumerable<DailyAppointmentsModel>> GetWeeklyAppointmentsById(DateTime startDate, string staffId)
        {
            return await _appointmentRepository.GetWeeklyAppointmentsById(startDate, staffId);
        }

        public async Task ConfirmAppointment(int id, string staffId)
        {
            await _appointmentRepository.ConfirmAppointment(id, staffId);
        }
        public async Task<IEnumerable<PatientRecord>> GetPatientRecordAsync(string patientId)
        {
            return await _appointmentRepository.GetPatientRecordAsync(patientId);
        }

        public async Task<PaginatedResult<AppointmentDto>> GetAllReviews(int pageNumber, int pageSize)
        {
            return await _appointmentRepository.GetAllReviews(pageNumber, pageSize);
        }

        public async Task<StaffReviewDto> GetReviewsForStaff(string staffId)
        {
            return await _appointmentRepository.GetReviewsForStaff(staffId);
        }

        public async Task UpdateApppointmentDaily()
        {
            await _appointmentRepository.UpdateApppointmentDaily();
        }
    }
}
