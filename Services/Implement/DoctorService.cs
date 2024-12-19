using AppointmentHospital.Entity;
using AppointmentHospital.Models;
using AppointmentHospital.Repositories;
using AppointmentHospital.ViewModels;

namespace AppointmentHospital.Services.Implement;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository doctorRepository;

    public DoctorService(IDoctorRepository _doctorRepository){
        doctorRepository = _doctorRepository;
    }

    public Doctor getDoctorById(Guid doctorId)
    {
        return doctorRepository.getDoctorById(doctorId);
    }

    public async Task<Doctor> updateDoctor(Doctor request, string phoneNumber) {
        return await doctorRepository.updateDoctor(request, phoneNumber);
    }
    public List<Doctor> getAllDoctors(){
        return doctorRepository.getAllDoctors();
    }

    public List<TimeSlot> getTimeSlotByDoctorId(Guid doctorId){
        return doctorRepository.getTimeSlotByDoctorId(doctorId);
    }

    public String getDoctorNameByDoctorId(Guid doctorId){
        return doctorRepository.getDoctorNameByDoctorId(doctorId);
    }
}
