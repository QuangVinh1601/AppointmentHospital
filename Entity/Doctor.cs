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

        [Required]
        [MaxLength(50)]
        public string Specializaiton { get; set; }
        public string? AvailableTime { get; set; }

        public int ExperienceYear { get; set; }

        [ForeignKey("DoctorId")]       
        public User User { get;set; }
    }
}
