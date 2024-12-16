using AppointmentHospital.Models;
using AppointmentHospital.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentHospital.Controllers
{
    public class PatientController : Controller
    {
        private readonly AppDbContext appDbContext;
        private readonly IDoctorService doctorService;
        private readonly ILogger<DoctorController> _logger;
        public PatientController(AppDbContext appDbContext, IDoctorService doctorService, ILogger<DoctorController> logger){
            this.appDbContext = appDbContext;
            this.doctorService = doctorService;
            this._logger = logger;
        }

        public IActionResult Index()
        {
            List<Doctor> doctors = appDbContext.Doctors.ToList(); 
            return View(doctors);
        }

        public IActionResult BookSchedule(Guid id){
            _logger.LogInformation("Doctor Id: " + id);
            String DoctorName = doctorService.getDoctorNameByDoctorId(id);
            return View((object)DoctorName);
        }
    }
}
