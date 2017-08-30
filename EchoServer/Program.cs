using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;

namespace EchoServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Program P = new Program();
            P.Server();
        }

        public void Server()
        {
            Console.WriteLine("Ready to receive echo");
            TcpListener listener = new TcpListener(IPAddress.Loopback, 11000);
            listener.Start();

            TcpClient client = listener.AcceptTcpClient();
            NetworkStream stream = client.GetStream();
            StreamWriter writer = new StreamWriter(stream, Encoding.ASCII) { AutoFlush = true };
            StreamReader reader = new StreamReader(stream, Encoding.ASCII);

            while (true)
            {
                string inputLine = "";
                while (inputLine != null)
                {
                    inputLine = reader.ReadLine();
                    writer.WriteLine("Echo: " + inputLine);
                    Console.WriteLine("Echo: " + inputLine);

                }
                Console.ReadKey();
            }
        }
    }
}
