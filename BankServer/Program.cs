using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BankServer
{
    class Program
    {


        static void Main(string[] args)
        {
            CustomerLedger.Ledger.Add(1, 100000);
            CustomerLedger.Ledger.Add(2, 15356);
            CustomerLedger.Ledger.Add(3, -356);
            IPAddress ip = IPAddress.Parse("127.0.0.1");

            TcpListener serverSocket = new TcpListener(ip, 6789);
            serverSocket.Start();
            Console.WriteLine("Server started");




            while (true)
            {
                TcpClient connectionSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine("Server activated");
                Server s = new Server(connectionSocket);
                Task.Factory.StartNew(() => s.StartNewConnection());



                //TcpClient connectionSocket = serverSocket.AcceptTcpClient();
                ////Socket connectionSocket = serverSocket.AcceptSocket();
                //Console.WriteLine("Server activated");

                //Stream ns = connectionSocket.GetStream();
                //// Stream ns = new NetworkStream(connectionSocket);

                //StreamReader sr = new StreamReader(ns);
                //StreamWriter sw = new StreamWriter(ns);
                //sw.AutoFlush = true; // enable automatic flushing

                //string message;
                //message = "";
                //message = sr.ReadLine();
                //string answer = "";
                //while (true)
                //{

                //    Console.WriteLine("Client: " + message);
                //    if (message != null)
                //    {
                //        if (message == "quit")
                //        {
                //            break;
                //        }

                //        string[] splitmessage = message.Split(' ');
                //        string sId = splitmessage[0];
                //        int id = Int32.Parse(sId);
                //        string amount = splitmessage[1];
                //        double amountD = double.Parse(amount);

                //        CustomerLedger.Ledger[id] += amountD;
                //        answer = CustomerLedger.Ledger[id].ToString();
                //        sw.WriteLine(answer);



                //    }

                //    message = sr.ReadLine();
                //    // connection skal lukkes her, og der skal resettes
                //}

                ////ns.Close();
                //connectionSocket.Close();





            }
        }
    }
}
