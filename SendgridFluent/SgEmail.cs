using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.SmtpApi;

namespace SendgridFluent
{
    public class SgEmail : ISgMail
    {
        private readonly SendGridMessage _myMessage;
        private readonly Web _transportWeb;
        private  SgHeader _header;

        private SgEmail(string username, string password)
        {
            var credentials = new System.Net.NetworkCredential(username, password);
            _transportWeb = new Web(credentials);
            _myMessage = new SendGridMessage { Text = "<%body%>", Html = "<p><p>", Subject = " " };

            //Well, just the way SG behaves with templates
        }
        /// <summary>
        /// SendGrid credentials
        /// </summary>
        /// <param name="username">SendGrid username</param>
        /// <param name="password">SendGrid password</param>
        /// <returns></returns>
        public static ISgMail WithCredentials(string username, string password)
        {
            return new SgEmail(username, password);
        }

        /// <summary>
        /// Sender
        /// </summary>
        /// <param name="fromAddress">Sender's address</param>
        /// <param name="fromName">Sender's name</param>
        /// <returns></returns>
        public ISgMail From(string @fromAddress, string fromName = null)
        {
            _myMessage.From = new MailAddress(fromAddress, fromName);
            return this;
        }

        /// <summary>
        /// Recipient
        /// </summary>
        /// <param name="to">Receiver's address</param>
        /// <param name="toName">Receiver's name</param>
        /// <returns></returns>
        public ISgMail To(string to, string toName = null)
        {
            _myMessage.AddTo(to);

            return this;
        }

        /// <summary>
        /// Subject to be appended to the template's subject
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        public ISgMail Subject(string subject)
        {
            _myMessage.Subject = subject;
            return this;

        }

        /// <summary>
        /// Substitutes the specified tag with.
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public ISgMail Substitute(string tag, string content)
        {
           Header.sub.Add(new KeyValuePair<string, string[]>(tag,new []{content}));
            return this;
        }

        
    
        /// <summary>
        /// Call this method right at the end of the fluent syntax.
        /// </summary>
        public void Deliver()
        {
            _myMessage.Headers.Add("X-SMTPAPI", Header.JsonSerialize());

            Task.Run(async () => { await _transportWeb.DeliverAsync(_myMessage); }).Wait();
            
        }

        public async Task DeliverAsync()
        {
            _myMessage.Headers.Add("X-SMTPAPI", Header.JsonSerialize());

            await _transportWeb.DeliverAsync(_myMessage); 

        }


        /// <summary>
        /// Specify the template you want to send the email with
        /// </summary>
        /// <param name="templateId">Template Id</param>
        /// <returns></returns>
        public ISgMail WithTemplate(string templateId)
        {
            Header.filters.templates.settings.template_id = templateId;
            return this;

        }


        private SgHeader Header
        {
            get
            {
                if (_header == null)
                    _header = SgHeader.Initialize();
                return _header;
            }
        }
    }
}
