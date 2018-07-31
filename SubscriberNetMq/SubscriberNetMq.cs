using System;
using NetMQ;
using NetMQ.Sockets;

namespace SubscriberNetMq
{
    class SubscriberNetMq
    {
        static void Main(string[] args)
        {
            string endpoint1 = "tcp://127.0.0.1:5556";
            string endpoint2 = "tcp://127.0.0.1:5557";

            try
            {
                using (var socket2 = new SubscriberSocket())
                using (var socket1 = new SubscriberSocket())
                {
                    socket1.Connect(endpoint1);
                    socket1.Subscribe("");
                    Console.WriteLine($"Subscriber NetMQ. Binding on {endpoint1}");

                    socket2.Connect(endpoint2);
                    socket2.Subscribe("");
                    Console.WriteLine($"Subscriber NetMQ. Binding on {endpoint2}");


                    while (true)
                    {
                        string messageTopicReceived1 = socket1.ReceiveFrameString();
                        string messageTopicReceived2 = socket2.ReceiveFrameString();

                        Console.WriteLine(messageTopicReceived2);
                        Console.WriteLine(messageTopicReceived1);
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
