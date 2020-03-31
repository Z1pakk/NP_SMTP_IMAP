using MailKit.Net.Imap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailExample2
{
    class Program
    {
        static void Main(string[] args)
        {
            Imap();
            //Smtp();
        }

        static void Smtp()
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("wladiktest420@gmail.com", "Qwertyu-1");

            MailMessage mail = new MailMessage();
            mail.To.Add("wladik420@gmail.com");
            mail.To.Add("Roma_7ake@student.itstep.org");
            mail.To.Add("Karn_xx5c@student.itstep.org");
            mail.To.Add("Golu_wpt2@student.itstep.org");
            mail.To.Add("Agap_wai8@student.itstep.org");

            mail.From = new MailAddress("wladiktest420@gmail.com");
            mail.Subject = "This is Subject!";
            mail.Body = "This is Body!";
            mail.IsBodyHtml = true;

            // MIME
            Attachment attachment = new Attachment(@"C:\Users\Vlad\Desktop\dz2.txt");
            mail.Attachments.Add(attachment);

            smtpClient.Send(mail);
            Console.WriteLine("Все ок!");
        }

        static void Imap()
        {
            using (ImapClient imapClient = new ImapClient())
            {
                imapClient.Connect("imap.gmail.com", 993, true);

                imapClient.Authenticate("wladiktest420@gmail.com", "Qwertyu-1");

                var inbox = imapClient.Inbox;
                inbox.Open(MailKit.FolderAccess.ReadOnly);

                for (int i = inbox.Count-1; i > inbox.Count-11; i--)
                {
                    var message = inbox.GetMessage(i);
                    Console.WriteLine($"Subject: {message.Subject}\n Body: {message.Body}" );
                }

                Console.WriteLine($"Count of all Messages: {inbox.Count}");
            }
        }
    }
}
