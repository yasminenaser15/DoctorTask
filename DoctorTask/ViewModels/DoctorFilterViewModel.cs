using DoctorTask.Models;

namespace DoctorTask.ViewModels
{
    public class DoctorFilterViewModel
    {
        public List<Doctor> Doctors { get; set; }

        public string Search { get; set; }
        public int? SpecializationId { get; set; }

        public List<Specilization> Specializations { get; set; }

        public int Page { get; set; }
        public int TotalPages { get; set; }
    }
}
