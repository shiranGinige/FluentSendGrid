FluentSendGrid
==============

How to? 

1. Create a SendGrid template 

2. Use the following fluent notation to deliver emails 

            var email =
                SgEmail.WithCredentials("shiranginige", "Rewq4321")
                    .WithTemplate("51824a40-8db6-4858-b756-9cd50541a9c3")
                    .To("shiranginige@gmail.com")
                    .From("shiranginige@gmail.com");
            email.Deliver();
            
