using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wonga.RabbitMQ.Domain.Core.Events;

namespace Wonga.RabbitMQ.Domain.Core.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler
        where TEvent : Event
    {
        Task Handler(TEvent @event);
    }

    public interface IEventHandler
    {

    }     
}
