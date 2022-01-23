using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitMqConsumer
{
    static class Program
    {
        static void Main(string[] args)
        {
            //Create a connection factory 
            var factory = new ConnectionFactory { HostName = "localhost" };
            //Create a connection ..that return i connection 
            using var connection = factory.CreateConnection();
            //Create a channel .. that return i model
            using var channel = connection.CreateModel();
            //QueueConsumer.Consumer(channel);
            //DirectExchangeConsumer.Consumer(channel);
            TopicExchangeConsumer.Consumer(channel);

            #region  Rabbit MQ Using single Producer with single consumer 
            ////Create a connection factory 
            //var factory = new ConnectionFactory { HostName = "localhost" };
            ////Create a connection ..that return i connection 
            //using var connection = factory.CreateConnection();
            ////Create a channel .. that return i model
            //using var channel = connection.CreateModel();
            ////After access model now can declear queue 
            ////QueueDeclare(QueueName,
            ////durable(make it true to need to hang out until consumer read),
            ////exclusive,
            ////autoDelete,
            ////arguments)
            //channel.QueueDeclare("demo-queue",
            //    durable: true,
            //    exclusive: false,
            //    autoDelete: false,
            //    arguments: null);
            ////After Declear queue ..create consumer 
            ////which take IModel...so pass chnnel
            //var consumer = new EventingBasicConsumer(channel);
            //consumer.Received += (sender, e) =>
            //{
            //    var body = e.Body.ToArray();
            //    var message = Encoding.UTF8.GetString(body);
            //    Console.WriteLine(message);
            //};
            ////BasicConsume(queue,autoAck,consumer);
            //channel.BasicConsume("demo-queue",true,consumer);
            //Console.ReadLine(); 
            #endregion
        }
    }
}