using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQProducer
{
    public static class TopicExchangeProducer
    {
        public static void Publish(IModel channel)
        {
            var timeToLeave = new Dictionary<string, object>
            {
                {"x-msg-ttl",30000 }
            };
            ////After access model now can declear Exchange 
            ////ExchangeDeclare(QueueName,
            ////ExchangeType(Direct),
            ////exclusive,
            ////autoDelete,
            ////arguments)
            channel.ExchangeDeclare("demo-topic-exchange",
                ExchangeType.Topic, arguments: timeToLeave);
            //send Multipule messages in same time 
            int count = 0;
            while (true)
            {
                //After Declear queue ..publish message to queue 
                //anonomes type 
                var message = new { Name = "Producer", Message = $"Hello the count is {count}" };
                //when sending need to connvert to Bytes 
                //GetBytes take a string but in this case take object 
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                //now publish message basic publish(exchang(pass exchange type),routing key(),basic property, body)
                channel.BasicPublish("demo-topic-exchange", "account.init", null, body);
                count++;
                Thread.Sleep(1000);
            }
        }
    }
}
