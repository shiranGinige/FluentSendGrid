using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SendGrid;

namespace SendgridFluent
{
    public class SgEmail : ISgMail
    {
        private  readonly SendGridMessage _myMessage;
        private  readonly Web _transportWeb;

        private SgEmail(string username, string password)
        {
            var credentials = new System.Net.NetworkCredential(username, password);
            _transportWeb = new Web(credentials);
            _myMessage = new SendGridMessage {Text = "<%body%>", Html = "<p><p>" , Subject = " "};

            //Well, just the way SG behaves with templates
        }

        public static ISgMail WithCredentials(string username, string password)
        {
         
            return new SgEmail(username, password);
        }
        public ISgMail From(string @fromAddress , string fromName=null)
        {
            _myMessage.From = new MailAddress(fromAddress,fromName);
            return this;
        }

        public ISgMail To(string to, string toName = null)
        {
            _myMessage.AddTo(to);

            return this;
        }

        public ISgMail Subject(string subject)
        {
            _myMessage.Subject = subject;
            return this;

        }

        public void Deliver()
        {
            _transportWeb.Deliver(_myMessage);
        }

        public ISgMail WithTemplate(string templateId)
        {
            var rawJson = ReadFile();
            var json = rawJson.Replace("--templateid--", templateId);
            _myMessage.Headers.Add("X-SMTPAPI", json);
            return this;

        }

        private string ReadFile()
        {
            StreamReader reader = new StreamReader(@"JSON\SGTemplate-XSMTPAPI.txt");
            return reader.ReadToEnd();
        }
    }
}
