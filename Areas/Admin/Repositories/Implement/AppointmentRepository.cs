using AppointmentHospital.Areas.Admin.DTOs.Appointment;
using AppointmentHospital.EnumStatus;
using AppointmentHospital.Helpers;
using AppointmentHospital.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AppointmentHospital.Areas.Admin.Repositories.Implement
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _context;
        public AppointmentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Pagination<AppointmentResponse>> GetAllAppointmentAsync(int page, string? searchTerm, Specialization? specialization)
        {
            var query = _context.Appointments.Include(a => a.Patient).Include(a => a.Doctor).Select(a => new AppointmentResponse
            {
                PatientId = a.PatientId,
                PatientName = a.Patient.FullName,
                DoctorId = a.DoctorId,
                Specialization = a.Doctor.Specializaiton,
                AppointmentId = a.AppointmentId,
                DoctorName = a.Doctor.FullName,
                Status = a.Status,
                AppointmentTime = a.AppointmentTime,
                CreatedAt = a.CreatedAt,
            });
            if (searchTerm != null && specialization == null)
            {
                query = query.Where(a => a.DoctorName.ToLower().Contains(searchTerm.ToLower()) || a.PatientName.ToLower().Contains(searchTerm.ToLower()));
            }
            if (searchTerm == null && specialization != null)
            {
                query = query.Where(a => a.Specialization == specialization);
            }
            if (searchTerm != null && specialization != null)
            {
                query = query.Where(a => (a.PatientName.ToLower().Contains(searchTerm.ToLower()) || a.DoctorName.ToLower().Contains(searchTerm.ToLower())) && a.Specialization == specialization);
            }
            return await Pagination<AppointmentResponse>.PaginatedList(query, page);
        }

        public List<SelectListItem> GetStatus()
        {
            var statusList = Enum.GetValues(typeof(AppointmentStatus)).Cast<AppointmentStatus>().Select(s => new SelectListItem
            {
                Text = s.ToString(),
                Value = ((int)s).ToString()
            }).ToList();
            return statusList;
        }

        public List<SelectListItem> GetSpecialization()
        {
            var specializationList = Enum.GetValues(typeof(Specialization)).Cast<Specialization>().Select(s => new SelectListItem
            {
                Text = GetDisplayNameSpecializatiton(s),
                Value = ((int)s).ToString()
            }).ToList() ;
            return specializationList;
        }
        public static string GetDisplayNameSpecializatiton(Enum value)
        {
            var displayName = value.GetType().GetField(value.ToString())?.GetCustomAttribute<DisplayAttribute>()?.Name ?? value.ToString();
            return displayName;
        }

        public async Task<AppointmentResponse> GetAppointmentAsync(Guid id)
        {
            var appointment =  await _context.Appointments.Include(a => a.Patient).Include(a => a.Doctor).Select(a => new AppointmentResponse
            {
                PatientId = a.PatientId,
                PatientName = a.Patient.FullName,
                DoctorId = a.DoctorId,
                Specialization = a.Doctor.Specializaiton,
                AppointmentId = a.AppointmentId,
                DoctorName = a.Doctor.FullName,
                Status = a.Status,
                AppointmentTime = a.AppointmentTime,
                CreatedAt = a.CreatedAt,
                CancellationReason = a.CancellationReason,
                Notes = a.Notes,
            }).FirstOrDefaultAsync();
            return appointment;
        }
    }
}
