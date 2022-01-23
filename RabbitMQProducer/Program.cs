using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitMQProducer
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
          
            //QueueProducer.Publish(channel);
            DirectExchangeProducer.Publish(channel);

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
            //    autoDelete:false,
            //    arguments:null);
            ////After Declear queue ..publish message to queue 
            ////anonomes type 
            //var message = new { Name = "Producer", Message = "Hello" };
            ////when sending need to connvert to Bytes 
            ////GetBytes take a string but in this case take object 
            //var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            ////now publish message basic publish(exchang(pass empty mean use defualt(AMQP exchange)),
            ////routing key(pass name),basic property, body)
            //channel.BasicPublish("", "demo-queue", null, body); 

            #endregion

        }
    }
}
