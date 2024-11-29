﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AppointmentHospital.EnumStatus;

namespace AppointmentHospital.Models
{
    public class Appointment
    {
        [Key]
        public Guid AppointmentId { get; set; }

        [Required]
        public Guid PatientId { get; set; } // FK to Patient

        [Required]
        public Guid DoctorId { get; set; } // FK to Doctor

        [Required]
        public DateTime AppointmentTime { get; set; }

        [Required]
        [MaxLength(20)]
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;

        [MaxLength(255)]
        public string? CancellationReason { get; set; } 

        public string? Notes { get; set; } 

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
    }
}
