namespace BE.Models
{
    public class AppointmentDetail
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }        
        public string PatientCondition { get; set; } // tình trạng bệnh nhân trong buổi hẹn
        public string TreatmentProvided { get; set; } // chi tiết về điều trị, chăm sóc thực hiện
        public string? Notes { get; set; } //ghi chú về quá trình chăm sóc, điều kiện xung quanh
        public DateTime? NextAppointmentDate { get; set; } // đề xuất ngày hẹn tiếp theo
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
