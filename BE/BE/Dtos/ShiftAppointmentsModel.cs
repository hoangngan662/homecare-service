namespace BE.Dtos
{
    public class ShiftAppointmentsModel
    {
        public int ShiftId { get; set; }
        public List<AppointmentDto> Appointments { get; set; } = new List<AppointmentDto>();
    }
}
