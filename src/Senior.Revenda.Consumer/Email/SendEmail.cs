using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Senior.Revenda.Consumer.Email
{
    public class SendEmail
    {
        public static async Task SendAsync(string titulo, string corpo)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.UseDefaultCredentials = true;
                client.Credentials = new NetworkCredential("email", "senha");
                

                string to = "emaildestinatario";
                string from = "email";
                MailMessage mail = new MailMessage(from, to);

                mail.Subject = titulo;
                mail.Body = corpo;

                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                client.Send(mail);

                await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao enviar Email");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
