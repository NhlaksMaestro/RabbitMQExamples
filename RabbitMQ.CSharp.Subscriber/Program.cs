using RabbitMQ.CSharp.Subscriber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Input part 1 to 5 for different RABBITMQ Subscribing Examples");

            string testString = (Console.ReadLine()).Trim().ToLower();
            
            while (!testString.Equals("q"))
            {
                if (testString.Equals("part1"))
                {
                    SubscriberPart1.SubscribeApi();
                    testString = (Console.ReadLine()).Trim().ToLower();
                }
                else if (testString.Equals("part2"))
                {
                    testString = SubscriberPart2.Subscribe();
                }
                else if (testString.Equals("part3"))
                {
                    testString = SubscriberPart3.Subscribe();
                }
                else if (testString.Contains("part4"))
                {
                    SubscriberPart4.Subscribe(testString.Replace("part4", "").Split(' '));
                    testString = (Console.ReadLine()).Trim().ToLower();
                }
                else if (testString.Contains("part5"))
                {
                    SubscriberPart5.Subscribe(testString.Replace("part5", "").Split(' '));
                    testString = (Console.ReadLine()).Trim().ToLower();
                }
                else if (testString.Contains("part6"))
                {                    
                    testString = SubscriberPart6.Subscribe();
                }
            }
        }
        static void MainNew(string[] args)
        {
            Console.WriteLine(" Input part 1 to 5 for different RABBITMQ Subscribing Examples");
            int exampleToRun = 0;
            string exampleStringToRun = (Console.ReadLine()).Trim().ToLower();
            bool exampleStringToRunIsValid = int.TryParse(exampleStringToRun, out exampleToRun);

            while (exampleStringToRunIsValid)
            {
                string testString = (Console.ReadLine()).Trim().ToLower();
                while (!testString.Equals("q"))
                {
                    if (exampleToRun == 1)
                    {
                        testString = SubscriberPart1.Subscribe();
                    }
                    else if (exampleToRun == 2)
                    {
                        testString = SubscriberPart2.Subscribe();
                    }
                    else if (exampleToRun == 3)
                    {
                        testString = SubscriberPart3.Subscribe();
                    }
                    else if (exampleToRun == 4)
                    {
                        SubscriberPart4.Subscribe(testString.Replace("4", "").Split(' '));
                        testString = (Console.ReadLine()).Trim().ToLower();
                    }
                    else if (exampleToRun == 5)
                    {
                        SubscriberPart5.Subscribe(testString.Replace("5", "").Split(' '));
                        testString = (Console.ReadLine()).Trim().ToLower();
                    }
                    else if (exampleToRun == 6)
                    {
                        testString = SubscriberPart6.Subscribe();
                    }
                }
                exampleStringToRun = (Console.ReadLine()).Trim().ToLower();
                exampleStringToRunIsValid = int.TryParse(exampleStringToRun, out exampleToRun);
            }
        }
    }
}
