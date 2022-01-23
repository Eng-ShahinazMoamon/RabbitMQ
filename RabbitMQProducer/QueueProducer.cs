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
   public static class QueueProducer
    {
        public static void Publish(IModel channel)
        {

            ////After access model now can declear queue 
            ////QueueDeclare(QueueName,
            ////durable(make it true to need to hang out until consumer read),
            ////exclusive,
            ////autoDelete,
            ////arguments)
            channel.QueueDeclare("demo-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            //send Multipule messages in same time 
            int count = 0;
            while(true)
            {
                //After Declear queue ..publish message to queue 
                //anonomes type 
                var message = new { Name = "Producer", Message = $"Hello the count is {count}" };
                //when sending need to connvert to Bytes 
                //GetBytes take a string but in this case take object 
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                //now publish message basic publish(exchang(pass empty mean use defualt),routing key(pass name),basic property, body)
                channel.BasicPublish("", "demo-queue", null, body);
                count++;
                Thread.Sleep(1000);
            }

        }
    }
}
