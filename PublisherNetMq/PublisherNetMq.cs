using System;
using System.Threading;
using NetMQ;
using NetMQ.Sockets;

namespace PublisherNetMq
{
    class PublisherNetMq
    {
        static void Main(string[] args)
        {
            string endpoint = "tcp://*:5556";
            
            using (var socket = new PublisherSocket())
            {
                socket.Bind(endpoint);

                for (var i = 0; i < 500; i++)
                {                    
                    var msg = "OPCE TopicA msg-" + i;
                    Console.WriteLine("Sending message : {0}", msg);
                    socket.SendFrame(msg);                    

                    Thread.Sleep(10000);
                }
            }
        }
    }
}
