FluentSendGrid  
==============

SendGrid template engine is smart but is a little bit tricky to use from .net. This library wraps all complexities and exposes nice fluent notation to easily send emails with SendGrid templates. 

How to? 

1. Create a SendGrid template ( make sure it is activated) and get the template id
   https://sendgrid.com/templates


2. Use the following fluent notation to deliver emails 

      
      ```SgEmail.WithCredentials("your sendgrid user name", "your password")
         .WithTemplate("sendgrid template id")
         .To("receiver@gmail.com")
         .Subject("Test")
         .From("sender@gmail.com");
         email.Deliver();```
            
3. To replace content in the template 

       SgEmail.WithCredentials("your sendgrid user name", "your password")
         .WithTemplate("sendgrid template id")
         .To("receiver@gmail.com")
         .Subject("Test with replacable content")
         .Substitute("-name-","Test") // -name- tag in the template will be replaced by "Test"
         .Substitute("-registrationlink-","http://google.com") //-registrationlink- will be replaced by "http://google.com".
         .From(MyTestEmail).Deliver();
        }
