using BE.Models;

namespace BE.Dtos
{
    public class PatientRecord
    {
        public string ServiceType { get; set; } 
        public List<AppointmentDto> Appointments { get; set; }
    }
}
