using System;
using AppointmentHospital.Entity;
using AppointmentHospital.Models;

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
        return _context.Doctors.Find(doctorId)!;
    }

    public List<TimeSlot> getTimeSlotByDoctorId(Guid doctorId){
        return _context.TimeSlots.Where(x => x.DoctorId == doctorId).ToList();
    }

    public String getDoctorNameByDoctorId(Guid doctorId){
        return _context.Doctors.Find(doctorId)!.FullName;
    }
}