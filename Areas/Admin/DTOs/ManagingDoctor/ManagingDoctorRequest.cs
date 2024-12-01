﻿using AppointmentHospital.EnumStatus;

namespace AppointmentHospital.Areas.Admin.DTOs.ManagingDoctor
{
    public class ManagingDoctorRequest
    {
        public string PhoneNumber { set; get; }
        public string FullName { get; set; }
        public Specialization Specializaiton { get; set; }
        public string EmailAddress { get; set; }

        public int ExperienceYear { get; set; }
    }
}