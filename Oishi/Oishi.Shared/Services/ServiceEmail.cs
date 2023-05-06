using SendGrid;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Oishi.Shared.Services
{
    public class ServiceEmail
    {
        public bool EnviarEmail(string email, string assunto, string mensagem, string host, string nome, string userName, string senha, int porta)
        {
            MailMessage mail = new MailMessage()
            {
                From = new MailAddress(userName, nome)
            };
            mail.To.Add(email);
            mail.Subject = assunto;
            mail.Body = mensagem;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            using (SmtpClient smpt = new SmtpClient(host, porta))
            {
                smpt.Credentials = new NetworkCredential(userName, senha);
                smpt.Send(mail);
                return true;
            }
        }
    }
}

