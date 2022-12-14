using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Wonga.RabbitMQ.Consumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RabbitMQ.Consumer.
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            {
                channel.QueueDeclare("QSender", false, false, false, null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body.ToArray());

                    if(!string.IsNullOrEmpty(message))
                    {
                        Console.Write("Hello {0}, I am your father!");
                        Console.ReadLine();
                    }

                    channel.BasicConsume("QSender", true, consumer);

                };

            }

        }
    }
}
