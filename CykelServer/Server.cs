using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace CykelServer
{
    class Server
    {
        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 4646);

            server.Start();

            //Concurrent, flere klienter kan kører på samme tid.
            while (true)
            {
                Task.Run(() =>
                {
                    TcpClient socket = server.AcceptTcpClient();

                    // Ingen ventetid for de forskellige klienter.
                    TcpClient tempSocket = socket;
                    DoClient(tempSocket);
                });
            }
        }

        private void DoClient(TcpClient socket)
        {
            StreamReader sr = new StreamReader(socket.GetStream());
            StreamWriter sw = new StreamWriter(socket.GetStream());

            string str = sr.ReadLine();

            sw.Flush();

            socket.Close();
        }
    }
}