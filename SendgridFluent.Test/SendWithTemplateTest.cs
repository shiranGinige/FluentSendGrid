using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SendgridFluent.Test
{
    [TestFixture]
    public class TemplateTest
    {
        [Test]
        public void SendWithTemplate_Test()
        {
            var email =
                SgEmail.WithCredentials("shiranginige", "Rewq4321")
                    .WithTemplate("51824a40-8db6-4858-b756-9cd50541a9c3")
                    .To("shiranginige@gmail.com")
                    .From("shiranginige@gmail.com");
            email.Deliver();
            
        }
    }
}
