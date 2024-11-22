using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using AppointmentHospital.DTOs.Account;
using AppointmentHospital.Services;
using static AppointmentHospital.DTOs.Account.AccountRequest;
using Microsoft.AspNetCore.Identity;
using AppointmentHospital.Models;

namespace AppointmentHospital.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(IAccountService accountService, IHttpContextAccessor contextAccessor, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _accountService = accountService;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View(new LoginUserRequest() { Email = string.Empty, Password = string.Empty });
        }
        public IActionResult Register()
        {
            return View(new RegisterUserRequest() { ConfirmPassword = string.Empty, Email = string.Empty, FullName = string.Empty, Password = string.Empty });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            if (!await _accountService.LoginAsync(request))
            {
                ModelState.AddModelError("Login", "Cannot login");
                return View(request);
            }
            if (_contextAccessor.HttpContext.User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "AdminDashBoard", new { area = "Admin" });
            }
            if (_contextAccessor.HttpContext.User.IsInRole("Patient"))
            {
                return RedirectToAction("Index", "Patient");
            }
            if (_contextAccessor.HttpContext.User.IsInRole("Doctor"))
            {
                return RedirectToAction("Index", "Doctor");
            }
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            if (!(await _accountService.RegisterAsync(request)))
            {
                return View(request);
            }
            return RedirectToAction("Login");
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
