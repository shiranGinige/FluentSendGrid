FluentSendGrid (Inspired by FluentEmail by @lukencode ) 
==============

SendGrid template engine is beautiful but is a little bit tricky to use from .net. This library wraps all complexities and exposes nice fluent notation to easily send emails with SendGrid templates. 

How to? 

1. Create a SendGrid template ( make sure it is activated) and get the template id
   https://sendgrid.com/templates

2. Use the following fluent notation to deliver emails 

            var email =
                SgEmail.WithCredentials("your sendgrid user name", "your password")
                    .WithTemplate("sendgrid template id")
                    .To("receiver@gmail.com")
                    .From("sender@gmail.com");
            email.Deliver();
            
