using AppointmentHospital.Areas.Admin.DTOs.AdminDashBoard;
using AppointmentHospital.Areas.Admin.DTOs.ManagingPatient;
using AppointmentHospital.Areas.Admin.Repositories;
using AppointmentHospital.Helpers;
namespace AppointmentHospital.Areas.Admin.Services.Implement
{
    public class ManagingPatientService : IManagingPatientService
    {
        private readonly IManagingPatientRepository _managingPatientRepository;
        public ManagingPatientService(IManagingPatientRepository managingPatientRepository)
        {
            _managingPatientRepository = managingPatientRepository;
        }

        public async Task<bool> CreateNewPatientAsync(ManagingPatientRequest request)
        {
            return (await _managingPatientRepository.CreateNewPatientAsync(request));
        }

        public async Task DeletePatientAsync(Guid id)
        {
            await _managingPatientRepository.DeletePatientAsync(id);
        }

        public async Task EditPatientAsync(Guid id, ManagingPatientRequest request)
        {
            await _managingPatientRepository.EditPatientAsync(id, request);
        }

        public async Task<ManagingPatientResponse> GetPatientAsync(Guid id)
        {
            return await _managingPatientRepository.GetPatientAsync(id);
        }

        public async Task<Pagination<ManagingPatientResponse>> GetAllPatientAsync(int page, string searchTerm)
        {
            return await _managingPatientRepository.GetAllPatientAsync(page, searchTerm);
        }
    }
}
