using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace SendgridFluent
{
    public interface ISgMail
    {
        ISgMail From(string from, string fromName = null);
        ISgMail To(string to, string toName=null);
        ISgMail Subject(string subject);
        ISgMail WithTemplate(string templateId);
        ISgMail Substitute(string tag, string content);
        void Deliver();
    }
}
