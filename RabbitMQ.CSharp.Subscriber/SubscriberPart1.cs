using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.CSharp.Subscriber
{
    public class SubscriberPart1
    {
        public static string Subscribe()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                };
                channel.BasicConsume(queue: "hello",
                                     autoAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Subscribing completed!");
            }

            return (Console.ReadLine()).Trim().ToLower();
        }
        public static void SubscribeApi()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                };
                channel.BasicConsume(queue: "hello",
                                     autoAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Subscribing completed!");
                Console.ReadLine();
            }
        }
        public static EventingBasicConsumer SubscriberEventingBasicConsumer()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                };
                channel.BasicConsume(queue: "hello",
                                     autoAck: true,
                                     consumer: consumer);

                return consumer;
            }
        }

        //private async void startSearchBtn_Click(object sender, EventArgs e)
        //{
        //    await Search(files, selectTxcDirectory.SelectedPath, status, SearchCompleted); // <-- pass the callback method here
        //}

        //private static async Task Search(List<string> files, string path, Label statusText, Action<string> callback)
        //{
        //    foreach (string file in files)
        //    {
        //        XmlDocument xmlDoc = new XmlDocument();
        //        xmlDoc.Load(file);

        //        statusText.Text = "Started scanning...";
        //        using (XmlReader reader = XmlReader.Create(new StringReader(xmlDoc.InnerXml), new XmlReaderSettings() { Async = true }))
        //        {
        //            while (await reader.ReadAsync())
        //            {
        //                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "LineName"))
        //                {
        //                    Console.WriteLine(reader.ReadInnerXml());
        //                }
        //            }
        //        }

        //        // Here you're done with the file so invoke the callback that's it.
        //        callback(file); // pass which file is finished
        //    }
        //}

        //private static void SearchCompleted(string file)
        //{
        //    // This method will be called whenever a file is processed.
        //}
    }
}
