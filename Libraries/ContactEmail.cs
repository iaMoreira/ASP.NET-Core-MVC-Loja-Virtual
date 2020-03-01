using System.Net;
using System.Net.Mail;
using LojaVirtual.Models;

namespace LojaVirtual.Libraries
{
    public class ContactEmail
    {
        public static void SedContact(Contact contact)
        {
            /*
            * SMTP -> Sevidor responsavel por enviar 
            */
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("ianmoreira80@gmail.com", "99752137");
            smtp.EnableSsl = true;

            /*
                Corpo da mensagem
            */
            MailMessage message = new MailMessage();
            
        }
    }
}