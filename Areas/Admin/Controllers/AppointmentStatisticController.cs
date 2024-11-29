using AppointmentHospital.Areas.Admin.Services;
using AppointmentHospital.Areas.Admin.Services.Implement;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentHospital.Areas.Admin.Controllers
{
    public class AppointmentStatisticController : Controller
    {
        private readonly IAppointmentStatisticService _appointmentStatisticService;
        public AppointmentStatisticController(IAppointmentStatisticService appointmentStatisticService)
        {
            _appointmentStatisticService = appointmentStatisticService;
        }
        public IActionResult Index(DateTime? date, int? week, int? month)
        {
            return View();
        }
    }
}
