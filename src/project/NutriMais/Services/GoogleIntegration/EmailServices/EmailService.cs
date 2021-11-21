using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using NutriMais.Models;
using System.Net.Mail;
using MimeKit;
using System.Net;

namespace NutriMais.Services.GoogleIntegration.EmailServices
{
    public class EmailService : EmailServiceInterface
    {
        private readonly SmtpClient _client;

        public EmailService()
        {
            var user = Environment.GetEnvironmentVariable("SEND_EMAIL");
            var password = Environment.GetEnvironmentVariable("SEND_EMAIL_PASSWORD");
            _client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(user, password),
                EnableSsl = true
            };
        }

        public void Send(string to, string subject, string body)
        {
            var user = Environment.GetEnvironmentVariable("SEND_EMAIL");
            _client.Send(user, to, subject, body);
        }
    }
}
