using AppointmentHospital.Areas.Admin.DTOs.AppointmentStatistic;

namespace AppointmentHospital.Areas.Admin.Services
{
    public interface IAppointmentStatisticService
    {
        Task<AppointmentStatisticResponse> GetStatistic(DateTime? date, int? week, int? month);
    }
}
