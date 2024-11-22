using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentHospital.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class AdminDashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
