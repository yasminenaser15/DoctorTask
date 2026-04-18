namespace DoctorTask.Models
{
    public class Doctor
    {


        public int Id { get; set; }
        public string Name { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Appointement> Appointements { get; set; }
        public int SpecilizationId { get; set; }
        public Specilization Specilization { get; set; }

    }
}
