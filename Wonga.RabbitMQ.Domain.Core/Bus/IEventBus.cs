using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Wonga.RabbitMQ.Domain.Core.Commands;
using Wonga.RabbitMQ.Domain.Core.Events;

namespace Wonga.RabbitMQ.Domain.Core.Bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;

        void Publish<T>(T @event) where T : Event;

        void Subscribe<T, TH>() 
            where T : Event 
            where TH : IEventHandler<T>;
    }
}
