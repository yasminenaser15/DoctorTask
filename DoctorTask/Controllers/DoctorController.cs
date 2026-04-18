using DoctorTask.DataAcess;
using DoctorTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoctorTask.ViewModels;


namespace DoctorTask.Controllers
{
    public class DoctorController:Controller
    {
        private readonly ApplicationDbContext dbContext=new ApplicationDbContext();
        public IActionResult Index(string search, int? specialization, int page = 1)
        {
            var doctors = dbContext.Doctors.Include(d => d.Specilization).AsQueryable();
                
            
            if (!string.IsNullOrEmpty(search))
            {
                doctors = doctors.Where(d => d.Name.Contains(search));
            }

           
            if (specialization.HasValue)
            {
                doctors = doctors.Where(d => d.SpecilizationId == specialization);
            }

            int pageSize = 2;
            int totalPages = (int)Math.Ceiling(doctors.Count() / 2.0);

            var doctorspag = doctors.Skip((page - 1) * pageSize).Take(pageSize).ToList();
               

            var vm = new DoctorFilterViewModel
            {
                Doctors = doctorspag,
                Search = search,
                SpecializationId = specialization,
                Specializations = dbContext.specilizations.ToList(),
                Page = page,
                TotalPages = totalPages
            };

            return View(vm);
        }


    }
}
