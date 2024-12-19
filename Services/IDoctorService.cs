using System;
using AppointmentHospital.Entity;
using AppointmentHospital.Models;
using AppointmentHospital.ViewModels;

namespace AppointmentHospital.Services;

public interface IDoctorService
{
    public Doctor getDoctorById(Guid doctorId);
    public List<Doctor> getAllDoctors();
    public Task<Doctor> updateDoctor(Doctor request, string phoneNumber);
    public List<TimeSlot> getTimeSlotByDoctorId(Guid doctorId);
    public String getDoctorNameByDoctorId(Guid doctorId);
}
