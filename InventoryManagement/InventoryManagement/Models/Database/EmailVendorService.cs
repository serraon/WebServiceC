using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
namespace Examples.SmptExamples.Async
{
    public class EmailVendorService
    {
        public static void sendMail(string emailaddrTo, string firstName, string lastName, string bodymsg)
        {
            var fromAddress = new MailAddress("nicolefserrao25@gmail.com", "ABC Group");
            var toAddress = new MailAddress(emailaddrTo, firstName + " " + lastName);
            const string fromPassword = "290798118766560943";
            const string subject = "Quote Request From FunGroup";
            string body = bodymsg;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }

        }


        public static string Body(string firstname, string productname, string qty)
        {
            string msg = "";

            msg = "Hello " + firstname;
            msg = msg + "\n\n";
            msg = msg + "Please give us a quote for " + qty + " x " + productname;
            msg = msg + "\n\n";
            msg = msg + "Thank you, \n Fun GRoup";

            return msg;
        }
    }
}