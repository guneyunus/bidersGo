using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bidersGo.Services
{
    public class EmailSender
    {

        private readonly IConfiguration _configuration;

        public EmailSender (IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string SenderMail => _configuration.GetSection("EmailOptions:SenderMail").Value;
        public string Password => _configuration.GetSection("EmailOptions:Password").Value;
        public string Smtp => _configuration.GetSection("EmailOptions:Smtp").Value;
        public int SmtpPort => Convert.ToInt32(_configuration.GetSection("EmailOptions:SmtpPort").Value);



    }
}
