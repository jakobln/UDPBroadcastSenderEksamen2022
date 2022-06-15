using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace UDPBroadcastSender
{
    class Program
    {
        public const int Port = 7000;
        private static string NewDirection = "NewDirection";

        static void Main()
        {
            Random rand = new Random();


            UdpClient socket = new UdpClient();
            socket.EnableBroadcast = true; // IMPORTANT
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, Port);
            while (true)
            {
                string message = "The wind speed is " + rand.Next(0, 2) + " |" + "and the wind direction is " + "North";
                byte[] sendBuffer = Encoding.ASCII.GetBytes(message);
                socket.Send(sendBuffer, sendBuffer.Length, endPoint);
                Console.WriteLine("Message sent to broadcast address {0} port {1}", endPoint.Address, Port);
                WindData randomData = new WindData() { Direction = NewDirection, Speed = rand.Next(0, 2)};
                string serializedData = JsonSerializer.Serialize(randomData);
                byte[] data = Encoding.UTF8.GetBytes(serializedData);
                socket.Send(data, data.Length, endPoint);
                Console.WriteLine("Send JSON: " + serializedData);
                Thread.Sleep(5000);
            }

        }
    }
}
