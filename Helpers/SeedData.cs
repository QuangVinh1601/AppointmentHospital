using AppointmentHospital.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace AppointmentHospital.Helpers
{
    public class SeedData
    {
        private readonly AppDbContext _context;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly UserManager<User> _userManager;
        public SeedData(AppDbContext context, RoleManager<IdentityRole<Guid>> roleManager, UserManager<User> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task InitialData()
        {
            if(!(await _roleManager.RoleExistsAsync("Admin")))
            {
                await _roleManager.CreateAsync(new IdentityRole<Guid>("Admin"));
            }
            if(!(await _roleManager.RoleExistsAsync("Patient")))
            {
                await _roleManager.CreateAsync(new IdentityRole<Guid>("Patient"));
            }
            if (!(await _roleManager.RoleExistsAsync("Doctor")))
            {
                await _roleManager.CreateAsync(new IdentityRole<Guid>("Doctor"));
            }
            
            if(!(await _context.Users.AnyAsync(u => u.UserName == "admin@gmail.com")))
            {
                var admin = new User
                {
                    Email = "admin@gmail.com",
                    UserName = "admin@gmail.com",
                    EmailConfirmed = true
                };
                var result = await _userManager.CreateAsync(admin, "Admin123#");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(admin, "Admin");
                }
            }
            if (!(await _context.Users.AnyAsync(u => u.UserName == "patient1@gmail.com")))
            {
                var user = new User
                {
                    Email = "patient1@gmail.com",
                    UserName = "patient1@gmail.com",
                    EmailConfirmed = true
                };
                var patient = new Patient
                {
                    FullName = "John Bracker",
                    Address = "Viet nam",
                    DateOfBirth = new DateTime(2002, 11, 11),
                    User = user
                };

                var result = await _userManager.CreateAsync(user, "Patient123#");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Patient");
                    _context.Patients.Add(patient);
                    await _context.SaveChangesAsync();
                }
            }
            if (!(await _context.Users.AnyAsync(u => u.UserName == "doctor@gmail.com")))
            {
                var user = new User
                {
                    Email = "doctor@gmail.com",
                    UserName = "doctor@gmail.com",
                    EmailConfirmed = true
                };
                var availableTime = new
                {
                    Monday = new[] { "08:00-12:00", "13:00-17:00" },
                    Tuesday = new[] { "08:00-12:00", "13:00-17:00" }
                };
                var availableTimeString = JsonSerializer.Serialize(availableTime);
                var doctor = new Doctor
                {
                    FullName = "John Bracker",
                    Specializaiton = "Khoa tim mạch",
                    ExperienceYear = 3,
                    AvailableTime = availableTimeString,
                    User = user,
                };

                var result = await _userManager.CreateAsync(user, "Doctor123#");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Doctor");
                    _context.Doctors.Add(doctor);
                    await _context.SaveChangesAsync();
                }
            }

        }
    }
}
