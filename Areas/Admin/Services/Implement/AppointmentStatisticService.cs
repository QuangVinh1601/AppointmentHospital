using AppointmentHospital.Areas.Admin.DTOs.AppointmentStatistic;
using AppointmentHospital.Areas.Admin.Repositories;

namespace AppointmentHospital.Areas.Admin.Services.Implement
{
    public class AppointmentStatisticService : IAppointmentStatisticService
    {
        private readonly IAppointmentStatisticRepository _appointmentStatisticRepository;
        public AppointmentStatisticService(IAppointmentStatisticRepository appointmentStatisticRepository)
        {
            _appointmentStatisticRepository = appointmentStatisticRepository;
        }
        public async Task<AppointmentStatisticResponse> GetStatistic(DateTime? date, int? week, int? month )
        {
            return await _appointmentStatisticRepository.GetStatistic(date, week, month);
        }
    }
}
