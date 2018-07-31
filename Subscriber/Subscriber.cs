using System;
using System.Linq;
using ZeroMQ;

namespace Subscriber
{
    class Subscriber
    {
        static void Main(string[] args)
        {
            string endpoint = "tcp://127.0.0.1:5556";

            try
            {
                using (var subscriber = new ZSocket(ZSocketType.SUB))
                {
                    subscriber.Connect(endpoint);
                    subscriber.Subscribe("");

                    Console.WriteLine($"Subscriber ZeroMQ. Binding on {endpoint}");

                    while (true)
                    {
                        using (var replyFrame = subscriber.ReceiveFrame())
                        {
                            Console.WriteLine(replyFrame.ReadString());
                        }

                        using (ZMessage message = subscriber.ReceiveMessage())
                        {
                            Console.WriteLine(message.First().Read().ToString());
                        }
                    }                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
