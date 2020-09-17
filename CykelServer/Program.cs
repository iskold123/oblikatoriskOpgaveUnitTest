using System;
using System.Dynamic;

namespace CykelServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server worker = new Server();
            worker.Start();

            Console.ReadLine();
        }
    }
}
