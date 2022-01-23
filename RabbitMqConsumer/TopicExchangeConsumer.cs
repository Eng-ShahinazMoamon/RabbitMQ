
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqConsumer
{
    public static class TopicExchangeConsumer
    {
        public static void Consumer(IModel channel)
        {
            channel.ExchangeDeclare("demo-topic-exchange", ExchangeType.Topic);
            channel.QueueDeclare("demo-topic-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            //Need to bind exchange with queue
            //QueueBind(QueueName , ExchangeName,RoutingKey)
            channel.QueueBind("demo-topic-queue", "demo-topic-exchange", "account.*");
            //allow to user to get 10 msg at time (prefetch)
            channel.BasicQos(0, 10, false);
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
            channel.BasicConsume("demo-topic-queue", true, consumer);
            Console.WriteLine("Consumer Started");
            Console.ReadLine();
        }
    }
}
