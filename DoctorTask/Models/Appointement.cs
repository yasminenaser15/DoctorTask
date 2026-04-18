using System.Numerics;

namespace DoctorTask.Models
{
    public class Appointement
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string PatientName { get; set; }
        public string PatientEmail { get; set; }
        public string PatientPhone { get; set; }
        public DateTime AppointmentDate { get; set; }     
        public TimeSpan TimeSlot { get; set; }            
        public string? Problem { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
