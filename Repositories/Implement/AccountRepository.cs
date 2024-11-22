using AppointmentHospital.Models;
using AppointmentHospital.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using static AppointmentHospital.DTOs.Account.AccountRequest;

namespace AppointmentHospital.Repositories.Implement
{
    public class AccountRepository : IAccountRepository
    {
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly AppDbContext _appDbContext;
        public AccountRepository(RoleManager<IdentityRole<Guid>> roleManager, UserManager<User> userManager, SignInManager<User> signInManager, AppDbContext appDbContext)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _appDbContext = appDbContext;
        }
        public async Task<bool> LoginAsync(LoginUserRequest request)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);
            return signInResult.Succeeded;
        }


        public async Task<bool> RegisterAsync(RegisterUserRequest request)
        {
            var user = new User
            {
                Email = request.Email,
                UserName = request.Email,
                EmailConfirmed = true,
            };
            var patient = new Patient
            {
                FullName = request.FullName,
                User = user
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Patient");
                await _appDbContext.Patients.AddAsync(patient);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
