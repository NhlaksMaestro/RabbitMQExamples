using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.CSharp.Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Input part 1 to 5 for different RABBITMQ publishing Examples");


            string testString = (Console.ReadLine()).ToLower();

            while (!testString.Equals("q"))
            {
                if (testString.Equals("part1"))
                {
                    testString = PublisherPart1.Publish();
                }
                else if (testString.Contains("part2"))
                {
                    testString = PublisherPart2.Publish(testString.Replace("part2", "").Split(' '));
                }
                else if (testString.Contains("part3"))
                {
                    testString = PublisherPart3.Publish(testString.Replace("part3", "").Split(' '));
                }
                else if (testString.Contains("part4"))
                {
                    testString = PublisherPart4.Publish(testString.Replace("part4", "").Split(' '));
                }
                else if (testString.Contains("part5"))
                {
                    testString = PublisherPart5.Publish(testString.Replace("part5", "").Split(' '));
                }
                else if (testString.Contains("part6"))
                {
                    PublisherPart6.Publish();
                }
            }
        }
    }
}
