using System;
using System.Threading;
using ZeroMQ;

namespace Publisher
{
    class Publisher
    {
        static void Main(string[] args)
        {
            string endpoint = "tcp://*:5557"; //"tcp://127.0.0.1:5556";

            using (var publisher = new ZSocket(ZSocketType.PUB))
            {
                Console.WriteLine($"Publisher. Binding on {endpoint}");
                publisher.Bind(endpoint);

                var rnd = new Random();

                while (true)
                {
                    Thread.Sleep(10000);
                    int temperature = rnd.Next(-55, +45);
                    var update = $"OPCE {temperature}";
                    Console.WriteLine(update);
                    using (ZMessage msg = new ZMessage())
                    using (var updateFrame = new ZFrame(update))
                    {
                        msg.Add(updateFrame);
                        publisher.SendMessage(msg);
                    }                    
                }
            }
        }
    }
}
