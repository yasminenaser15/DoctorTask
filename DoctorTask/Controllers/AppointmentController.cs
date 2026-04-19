using DoctorTask.DataAcess;
using DoctorTask.Models;
using DoctorTask.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoctorTask.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext db;
        public AppointmentController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index(int doctorId)
        {
            var doctor = db.Doctors
         .Include(d => d.Specilization)
         .FirstOrDefault(d => d.Id == doctorId);

            if (doctor == null)
                return NotFound();

            var viewModel = new AppointmentVM
            {
                Doctor = doctor,
                Appointement = new Appointement { DoctorId = doctorId }
            };

            return View(viewModel);

        }
        [HttpPost]
        public IActionResult Index(AppointmentVM vm, string Time)
        {
            var doctor = db.Doctors
         .Include(d => d.Specilization)
         .FirstOrDefault(d => d.Id == vm.Appointement.DoctorId);

           
            DateTime fullDate = vm.Appointement.AppointmentDate.Date
                              + vm.Appointement.TimeSlot;

            if (fullDate.DayOfWeek == DayOfWeek.Friday ||
                fullDate.DayOfWeek == DayOfWeek.Saturday)
            {
                ModelState.AddModelError("", "No booking on Fridays and Saturdays");
                vm.Doctor = doctor;
                return View(vm);
            }

            if (fullDate.Hour < 8 || fullDate.Hour >= 17)
            {
                ModelState.AddModelError("", "Booking from 8 to 5 only");
                vm.Doctor = doctor;
                return View(vm);
            }

            bool exists = db.Appointements.Any(a =>
                a.DoctorId == vm.Appointement.DoctorId &&
                a.AppointmentDate == fullDate);

            if (exists)
            {
                ModelState.AddModelError("", "This date is booked Aleardy");
                vm.Doctor = doctor;
                return View(vm);
            }

            vm.Appointement.AppointmentDate = fullDate;
            db.Appointements.Add(vm.Appointement);
            db.SaveChanges();

            return RedirectToAction("Index", new { doctorId = vm.Appointement.DoctorId });


        }
    }
}
