using DoctorTask.DataAcess;
using DoctorTask.Models;
using DoctorTask.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoctorTask.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext db=new ApplicationDbContext();
        public IActionResult Index(AppointmentVM vm)
        {
            var doctorId = vm.Appointement.DoctorId;

            var doctor = db.Doctors
                .Include(d => d.Specilization)
                .FirstOrDefault(d => d.Id == doctorId);

            if (doctor == null)
                return NotFound();

            var viewModel = new AppointmentVM
            {
                Doctor = doctor,
                Appointement = new Appointement()
            };

            return View(viewModel);

        }
        [HttpPost]
        public IActionResult Index(AppointmentVM vm, string Time)
        {
            var doctor = db.Doctors
                .Include(d => d.Specilization)
                .FirstOrDefault(d => d.Id == vm.Appointement.DoctorId);

            if (string.IsNullOrEmpty(Time))
            {
                ModelState.AddModelError("", "اختاري وقت");
                vm.Doctor = doctor;
                return View(vm);
            }

            DateTime fullDate = vm.Appointement.AppointmentDate.Date + TimeSpan.Parse(Time);

            if (fullDate.DayOfWeek == DayOfWeek.Friday ||
                fullDate.DayOfWeek == DayOfWeek.Saturday)
            {
                ModelState.AddModelError("", "no booking in friday and ");
                vm.Doctor = doctor;
                return View(vm);
            }

            if (fullDate.Hour < 8 || fullDate.Hour >= 17)
            {
                ModelState.AddModelError("", "المواعيد من 8 لـ 5 فقط");
                vm.Doctor = doctor;
                return View(vm);
            }

            bool exists = db.Appointements.Any(a =>
                a.DoctorId == vm.Appointement.DoctorId &&
                a.AppointmentDate == fullDate);

            if (exists)
            {
                ModelState.AddModelError("", "هذا الموعد محجوز بالفعل");
                vm.Doctor = doctor;
                return View(vm);
            }

            vm.Appointement.AppointmentDate = fullDate;

            db.Appointements.Add(vm.Appointement);
            db.SaveChanges();

            return RedirectToAction("Index", new { id = vm.Appointement.DoctorId });
        }
    }
}
