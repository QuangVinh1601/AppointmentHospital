using AppointmentHospital.Entity;
using AppointmentHospital.EnumStatus;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentHospital.Models
{
    public class Doctor
    {
        [Key]
        public Guid DoctorId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        public Specialization Specializaiton { get; set; }

        public int ExperienceYear { get; set; }

        public string ImagePath { get; set; }

        [ForeignKey("DoctorId")]       
        public User User { get; set; }
        
        public ICollection<Appointment> Appointments { get; set; }
        
        public ICollection<TimeSlot> TimeSlots { get; set; }
    }
}
