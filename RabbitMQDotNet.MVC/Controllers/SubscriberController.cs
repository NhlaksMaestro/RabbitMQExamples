using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.CSharp.Subscriber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace RabbitMQDotNet.MVC.Controllers
{
    public class SubscriberController : Controller
    {
        private string _hostName = "localhost";
        private const string _queueName = "PythonSubscriberRequired";
        List<string> _messages;
        IConnection _connection;
        IModel _channel;
        EventingBasicConsumer _consumer;
        public SubscriberController()
        {
            var factory = new ConnectionFactory() { HostName = _hostName };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _messages = new List<string>();
        }
        private static EventingBasicConsumer InitializeConsumer(IModel channel)
        {
            return new EventingBasicConsumer(channel);
        }
        // GET: Subscriber
        public ActionResult Index()
        {
            _channel.QueueDeclare(queue: "hello",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            _consumer = InitializeConsumer(_channel);
            _consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received {0}", message);
                _messages.Add(message);
                Display(string.Format(" [x] Received {0}", message));
            };
            _channel.BasicConsume(queue: "hello",
                                 autoAck: true,
                                 consumer: _consumer);

            Display(string.Format(" [x] Received {0}", _messages.ToString()));
            return View();
        }
        [ChildActionOnly]
        public ActionResult Display(string name)
        {
            return Content("Hello: " + name);
        }
    }
}