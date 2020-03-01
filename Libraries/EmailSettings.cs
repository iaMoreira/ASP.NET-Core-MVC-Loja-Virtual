using System.Runtime.CompilerServices;
using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace LojaVirtual.Libraries
{
    public class EmailSettings
    {
        public static String PrimaryDomain { get; set; }
        public static int PrimaryPort { get; set; }
        public static String UsernameEmail { get; set; }
        public static String UsernamePassword { get; set; }
        public static String FromEmail { get; set; }
        private static SmtpClient smtp;

        public static IConfiguration Configuration;
        public EmailSettings () {
            // Object x = Configuration.GetSection("EmailSettings").GetConnectionString();
            smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("ianmoreira80@gmail.com", "");
            smtp.EnableSsl = true;
        }

        public void SendMail(MailMessage message){
            smtp.Send(message);
        }
    }
}