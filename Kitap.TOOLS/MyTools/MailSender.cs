using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.TOOLS.MyTools
{
   public static class MailSender
    {
        public static void Sende(string receiver, string password, string body="Deneme",string subject="Test",string sender = "mirayalinn@gmail.com")
        {
            MailAddress senderEmail = new MailAddress(sender);
            MailAddress receiverEmail = new MailAddress(receiver);

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp-mail.outlook.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)//2. parametreye şifrenizi yazmayı unutmayın
            };

            using(var mesaj=new MailMessage(senderEmail, receiverEmail)
            {
                Subject=subject,
                Body=body
            })
            {
                smtp.Send(mesaj);//Mail'i gönderdik.
            }

        }
    }
}
