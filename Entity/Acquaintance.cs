using System;
using AppointmentHospital.Controllers;
using AppointmentHospital.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentHospital.Models
{
    public class Acquaintance
    {
        [Key]
        public Guid Id { get; set;}

        [Required]
        [MaxLength(100)]
        public string Name { get; set;}

        [Required]
        public DateTime DateOfBirth { get; set;}

        [Required]
        public string Gender { get; set;}

        [Required]
        public int IdentificationNumber { get; set;}

        [Required]
        [MaxLength(100)]
        public string Address { get; set;}

        [Required]
        public Guid PatientId { get; set; }

        [ForeignKey("PatientId")]
<<<<<<< HEAD
        public Patient Patient { get; set; } 

        public ICollection<Appointment> Appointment { get; set; }
=======
        public virtual Patient Patient { get; set; } 
>>>>>>> 1ed4583 (Update function schedule)
    }
}

