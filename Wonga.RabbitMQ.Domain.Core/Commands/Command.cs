using System;
using System.Collections.Generic;
using System.Text;

namespace Wonga.RabbitMQ.Domain.Core.Commands
{
    public abstract class Command : Events.Message
    {
        public DateTime TimeStamp { get; protected set; }

        protected Command()
        {
            TimeStamp = DateTime.UtcNow;
        }
    }
}
