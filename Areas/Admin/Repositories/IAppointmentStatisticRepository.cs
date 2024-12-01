using AppointmentHospital.Areas.Admin.DTOs.AppointmentStatistic;

namespace AppointmentHospital.Areas.Admin.Repositories
{
    public interface IAppointmentStatisticRepository
    {
        Task<AppointmentStatisticResponse> GetStatistic(DateTime? date, int? week, int? month);
    }
}
