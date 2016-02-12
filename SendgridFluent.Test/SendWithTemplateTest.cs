using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace SendgridFluent.Test
{
    [TestFixture]
    public class TemplateTest
    {
        private const string MyTestEmail = "test@gmail.com";
        private const string MyUserName = "testusername";
        private const string MyPassword = "testpassword";
        private const string TemplateId = "templateid";

        [Test]
        public void SendWithTemplate_Test()
        {

            SgEmail.WithCredentials(MyUserName, MyPassword)
                .WithTemplate(TemplateId)
                .Subject("Test")
                .To(MyTestEmail)
                .From(MyTestEmail).Deliver();

        }

        [Test]
        public async Task SendAsyncWithTemplate_Test()
        {

           await SgEmail.WithCredentials(MyUserName, MyPassword)
                .WithTemplate(TemplateId)
                .Subject("Test")
                .To(MyTestEmail)
                .From(MyTestEmail).DeliverAsync();

        }


        [Test]
        public void SendWithTemplate_ReplacingContent_Test()
        {

            SgEmail.WithCredentials(MyUserName, MyPassword)
                .WithTemplate(TemplateId)
                .To(MyTestEmail)
                .Subject("Test with replacable content")
                .Substitute("-name-","Test")
                .Substitute("-registrationlink-","http://google.com")
                .From(MyTestEmail).Deliver();
        }


    }
}




