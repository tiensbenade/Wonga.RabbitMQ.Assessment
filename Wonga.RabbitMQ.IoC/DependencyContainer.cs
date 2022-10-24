using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Wonga.Infrastructure.Bus;
using Wonga.RabbitMQ.Domain.Core.Bus;

namespace Wonga.RabbitMQ.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IEventBus, RabbitMQBus>();
        }
    }
}
