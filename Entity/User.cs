using Microsoft.AspNetCore.Identity;

namespace AppointmentHospital.Models
{
    public class User : IdentityUser<Guid>
    {
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}
