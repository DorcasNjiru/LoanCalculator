using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    interface ISendEmail
    {
        void SendEmail(string from, string recipients, string subject, string body,string ID);
    }
} 
