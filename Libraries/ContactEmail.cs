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


            string body = string.Format("<h2> Contato - Loja Virtual</h2>" +
                "<b>Nome: </b> {0} <br/>" +
                "<b>E-Mail: </b> {1} <br/>" +
                "<b>Texto: </b> {2} <br/>" +
                "<br/> E-mail enviado da automaticamente do site LojaVirtual.",
                    contact.Name, contact.Email, contact.Text 
                );

            /*
                Corpo da mensagem
            */
            MailMessage message = new MailMessage();
            message.From = new MailAddress("ianmoreira80@gmail.com");
            message.To.Add(contact.Email);
            message.Subject = "Contato - LojaVirtual - E-mail " + contact.Email;
            message.Body = body;
            message.IsBodyHtml = true;
            (new EmailSettings()).SendMail(message);
            // EmailSettings.SendMail(message);
        }   
    }
}