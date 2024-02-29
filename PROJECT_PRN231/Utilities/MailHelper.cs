using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace PROJECT_PRN231.Utilities
{
    public class MailHelper
    {
        private const string sendingEmail = "sonnvbhe161489@fpt.edu.vn";
        private const string sendingEmailPassword = "kqox ylvh galr axbo"; // mail password, if use 2 factor auth, this will be app password
        private const string smtpServer = "smtp.gmail.com"; // smtp server for gmail
        string OTPcode; // OTP code ..duh

        public async Task<string> PostMailAsync(String Email)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient(smtpServer))
                {
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential(sendingEmail, sendingEmailPassword);
                    smtpClient.EnableSsl = true;

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(sendingEmail);

                    // Create OTP code
                    Random random = new Random();
                    for (int i = 0; i < 5; i++)
                    {
                        OTPcode += random.Next(10);
                    }


                    //Create mail to send

                    mail.To.Add(Email);
                    mail.Subject = "Sending code for Exam system";
                    mail.Body = "Your OTP code " + OTPcode;

                    await smtpClient.SendMailAsync(mail);

                    return OTPcode;
                }
            }
            catch (Exception ex)
            {
                return "failed";
            }
        }
    }
}
