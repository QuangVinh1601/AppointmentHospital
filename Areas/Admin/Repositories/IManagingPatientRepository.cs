using AppointmentHospital.Areas.Admin.DTOs.AdminDashBoard;
using AppointmentHospital.Areas.Admin.DTOs.ManagingPatient;
using AppointmentHospital.Helpers;

namespace AppointmentHospital.Areas.Admin.Repositories
{
    public interface IManagingPatientRepository
    {
        Task<Pagination<ManagingPatientResponse>> GetAllPatientAsync(int page,string searchTerm);
        Task<bool> CreateNewPatientAsync(ManagingPatientRequest request);
        Task DeletePatientAsync(Guid id);
        Task EditPatientAsync(Guid id, ManagingPatientRequest request);
        Task<ManagingPatientResponse> GetPatientAsync(Guid id);
    }
}
