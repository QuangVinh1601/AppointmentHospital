using System;
using AppointmentHospital.Entity;
using AppointmentHospital.Models;
using AppointmentHospital.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AppointmentHospital.Repositories.Implement;

public class DoctorRepository : IDoctorRepository
{
    private readonly AppDbContext _context;
    public DoctorRepository(AppDbContext context){
        _context = context; 
    }

    public List<Doctor> getAllDoctors(){
        return _context.Doctors.ToList();
    }

    public Doctor getDoctorById(Guid doctorId){
        return _context.Doctors
        .Include(d => d.User)
        .FirstOrDefault(d => d.DoctorId == doctorId)!;
    }
    public async Task<Doctor> updateDoctor(Doctor request, string phoneNumber) {
        var doctor = _context.Doctors.Where(d => d.DoctorId == request.DoctorId).FirstOrDefault();
        doctor.DateOfBirth = request.DateOfBirth;
        doctor.Description = request.Description;
        doctor.FullName = request.FullName;
        doctor.ExperienceYear = request.ExperienceYear;
        doctor.Gender = request.Gender;
        doctor.Degree = request.Degree;
        doctor.Specializaiton = request.Specializaiton;
        doctor.User.PhoneNumber = phoneNumber;
        _context.Update(doctor);
        await _context.SaveChangesAsync();
        return doctor;
    }

    public List<TimeSlot> getTimeSlotByDoctorId(Guid doctorId){
        return _context.TimeSlots.Where(x => x.DoctorId == doctorId).ToList();
    }

    public String getDoctorNameByDoctorId(Guid doctorId){
        return _context.Doctors.Find(doctorId)!.FullName;
    }
}
