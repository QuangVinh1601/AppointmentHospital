using System;
using AppointmentHospital.Entity;
using AppointmentHospital.Models;
using AppointmentHospital.ViewModels;

namespace AppointmentHospital.Repositories;

public interface IDoctorRepository
{
    public List<Doctor> getAllDoctors();
    public Doctor getDoctorById(Guid doctorId);
    public List<TimeSlot> getTimeSlotByDoctorId(Guid doctorId);
    public String getDoctorNameByDoctorId(Guid doctorId);
    public Task<Doctor> updateDoctor(Doctor request, string phoneNumber);
}
