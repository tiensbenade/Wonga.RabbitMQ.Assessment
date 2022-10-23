using System;
using System.Text;
using RabbitMQ.Client;


namespace Wonga.RabbitMQ.Producer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            { 
                HostName = "localhost" 
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare("QSender", false, false, false, null);

            Console.WriteLine("Please enter your name: ");

            var name = Console.ReadLine();
            var message = string.Format("Hello, my name is {0}", name);
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish("", "QSender", null, body);
            
            Console.Write("Message was sent:\r\n [{0}] {1}", message, DateTime.Now.ToString("dd/MM/yy HH:mm:ss"));
            Console.ReadLine();
        }
    }
}
