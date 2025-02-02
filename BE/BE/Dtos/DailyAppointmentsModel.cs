namespace BE.Dtos
{
    public class DailyAppointmentsModel
    {
        public string Date { get; set; }
        public List<ShiftAppointmentsModel> Shifts { get; set; } = new List<ShiftAppointmentsModel>();
    }
}
