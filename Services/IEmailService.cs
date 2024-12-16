namespace AppointmentHospital.Services
{
    public interface IEmailService
    {
        Task SendMailAsync(string toEmail, string subject, string body);
        Task<string> GetBookingTemplate(DateTime appointmentTime, string doctorName, string fullUserName);
        Task<string> GetRemindedTemplate(DateTime appointmentTime, string doctorName, string fullUserName);
        Task<string> GetCancelledTemplate(DateTime appointmentTime, string doctorName, string fullUserName);
    }
}
