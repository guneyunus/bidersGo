using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidersGo.Application.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace bidersGo.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection collection)
        {
            collection.AddTransient<IEmailSender, EmailSender>();
        }
    }
}
