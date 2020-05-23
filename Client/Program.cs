using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi I am the client...");

        //  IPAddress[] ipAddress = Dns.GetHostAddresses("localhost");
        //  IPEndPoint ipEnd = new IPEndPoint(ipAddress[1], 5656);      //127.0.0.1

            IPAddress address = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipEnd = new IPEndPoint(address, 5656); 
            Socket clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSock.Connect(ipEnd);

            string strData = "Message from client end.";
            byte[] clientData = new byte[1024];
            clientData = Encoding.ASCII.GetBytes(strData);
            clientSock.Send(clientData);

            byte[] serverData = new byte[1024];
            int len = clientSock.Receive(serverData);
            Console.WriteLine(Encoding.ASCII.GetString(serverData, 0, len));

            clientSock.Close();
            Console.ReadLine();
        }
    }
}

