using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using oblikatoriskOpgave;
using RESTCykelService.Controllers;

namespace CykelServer
{
    public class Server
    {
        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 4646);

            server.Start();

            //Concurrent, flere klienter kan kører på samme tid.
            while (true)
            {
                TcpClient socket = server.AcceptTcpClient();
                Task.Run(() =>
                {

                    // Ingen ventetid for de forskellige klienter.
                    TcpClient tempSocket = socket;
                    DoClient(tempSocket);
                });
            }
        }

        private static readonly List<Cykel> cykler1 = new List<Cykel>
        {
            new Cykel(1, "yellow", 17, 33),
            new Cykel(2, "10", 3, 5),
            new Cykel(3, "ads", 4, 4),
            new Cykel(4, "asfgg", 20, 3)
        };

        private void DoClient(TcpClient socket)
        {
            StreamReader sr = new StreamReader(socket.GetStream());
            StreamWriter sw = new StreamWriter(socket.GetStream());

            var str = sr.ReadLine();

            if (str == "HentAlle") 
            {
                sw.WriteLine($"Bikes in list;");
                Console.WriteLine($"Cykler i listen: ");
                foreach (var cykler in cykler1) sw.WriteLine(cykler);
                foreach (var cykler in cykler1)
                {
                    Console.WriteLine(cykler);
                }
            }
            else if (str == "Hent")
            {
                Console.WriteLine("skriv id");
                sw.WriteLine("skriv id");

                sw.Flush();

                string str2;
                str2 = sr.ReadLine();

                var i = int.Parse(str2);
                var b = cykler1.FirstOrDefault(cykler1 => cykler1.Id == i);

                sw.WriteLine(b);
            }
            
            sw.Flush();

            //socket.Close();
        }
    }
}