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
        private const string MyTestEmail = "shiranginige@gmail.com";
        private const string MyUserName = "shiranginige";
        private const string MyPassword = "Rewq4321";
        private const string TemplateId = "51824a40-8db6-4858-b756-9cd50541a9c3";

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




