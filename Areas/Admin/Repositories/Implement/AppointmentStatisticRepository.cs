using AppointmentHospital.Areas.Admin.DTOs.AppointmentStatistic;
using AppointmentHospital.Models;
using Microsoft.EntityFrameworkCore;
using AppointmentHospital.EnumStatus;

namespace AppointmentHospital.Areas.Admin.Repositories.Implement
{
    public class AppointmentStatisticRepository : IAppointmentStatisticRepository
    {
        private readonly AppDbContext _context;
        public AppointmentStatisticRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<AppointmentStatisticResponse> GetStatistic(DateTime? date, int? week, int? month)
        {
            if (date.HasValue)
            {
                var totalAppointments = await _context.Appointments.Where(a => a.CreatedAt.Date == date).CountAsync();
                var cancelledAppointments = await _context.Appointments.Where(a => a.Status == AppointmentStatus.Canceled && a.CreatedAt.Date == date).CountAsync();
                var confirmedAppointments = await _context.Appointments.Where(a => a.Status == AppointmentStatus.Confirmed && a.CreatedAt.Date == date).CountAsync();

            }
            else if (week.HasValue)
            {
                var totalAppointments = await _context.Appointments.Where(a => a.CreatedAt.Month == month).CountAsync();
                var cancelledAppointments = await _context.Appointments.Where(a => a.Status == AppointmentStatus.Canceled && a.CreatedAt == date).CountAsync();
                var confirmedAppointments = await _context.Appointments.Where(a => a.Status == AppointmentStatus.Confirmed && a.CreatedAt.Date == date).CountAsync();
            }
            else if (month.HasValue)
            {
                var totalAppointments = await _context.Appointments.Where(a => a.CreatedAt.Month == month).CountAsync();
                var cancelledAppointments = await _context.Appointments.Where(a => a.Status == AppointmentStatus.Canceled && a.CreatedAt.Month == month).CountAsync();
                var confirmedAppointments = await _context.Appointments.Where(a => a.Status == AppointmentStatus.Confirmed && a.CreatedAt.Month == month).CountAsync();
                var top5Doctor = await GetTop5DoctorWithMostAppointment(month);
            }
            return new AppointmentStatisticResponse();
        }
        private async Task<List<DoctorResponse>> GetTop5DoctorWithMostAppointment(int? month)
        {
            var top5DoctorInfo = await _context.Appointments.Include(a => a.Doctor).Where(a => a.CreatedAt.Month == month && a.Status == AppointmentStatus.Confirmed)
                                                        .GroupBy(a => a.Doctor.DoctorId)
                                                        .Select(g => new
                                                        {
                                                            DoctorId = g.Key,
                                                            AppointmentCount = g.Count()
                                                        }).OrderByDescending(a => a.AppointmentCount)
                                                        .Take(5).ToListAsync();
            var doctorIdList =  top5DoctorInfo.Select(a => a.DoctorId);
            var doctors = await _context.Doctors.Where(d => doctorIdList.Contains(d.DoctorId)).Select(d => new DoctorResponse
            {
                DoctorId = d.DoctorId,
                DoctorName = d.FullName,
                ExperienceYear = d.ExperienceYear,
                Specialization = d.Specializaiton,
                TotalConfirmAppointments = top5DoctorInfo.Where(a => a.DoctorId == d.DoctorId).Select(a => a.AppointmentCount).FirstOrDefault()
            }).ToListAsync();
            return doctors;
        }
    }
}
