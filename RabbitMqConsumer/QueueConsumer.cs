using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqConsumer
{
    public static class QueueConsumer
    {
        public static void Consumer(IModel channel)
        {
            channel.QueueDeclare("demo-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            //After Declear queue ..create consumer 
            //which take IModel...so pass chnnel
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };
            //BasicConsume(queue,autoAck,consumer);
            channel.BasicConsume("demo-queue", true, consumer);
            Console.WriteLine("Consumer Started");
            Console.ReadLine();
        }
    }
}
