using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi I am the server...");
        //  IPEndPoint ipEnd = new IPEndPoint(IPAddress.Any, 5656);

            IPAddress address = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipEnd = new IPEndPoint(address, 5656);

            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Bind(ipEnd);
            sock.Listen(100);

            Socket clientSock = sock.Accept();
            byte[] clientData = new byte[1024];
            int receivedBytesLen = clientSock.Receive(clientData);
            string clientDataInString = Encoding.ASCII.GetString(clientData, 0, receivedBytesLen);
            Console.WriteLine("Received Data {0}", clientDataInString);

            string clientStr = "Client Data Received";
            byte[] sendData = new byte[1024];
            sendData = Encoding.ASCII.GetBytes(clientStr);
            clientSock.Send(sendData);

            clientSock.Close();
            Console.ReadLine();
        }
    }
}
