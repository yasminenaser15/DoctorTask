using DoctorTask.DataAcess;
using DoctorTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoctorTask.Controllers
{
    public class AllAppointmentController : Controller
    {
        private readonly ApplicationDbContext db;
        public AllAppointmentController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var appointments = db.Appointements.Include(a => a.Doctor).OrderBy(a => a.AppointmentDate).ToList();
                  

            return View(appointments);
        }
    }
}
