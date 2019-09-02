using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;

namespace BankServer
{
    public class Server
    {
        private TcpClient serverSocket;
        public Server(TcpClient listerner)
        {
            serverSocket = listerner;
        }
        internal void StartNewConnection()
        {
            
            //Socket connectionSocket = serverSocket.AcceptSocket();
           

            Stream ns = serverSocket.GetStream();
            // Stream ns = new NetworkStream(connectionSocket);

            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; // enable automatic flushing

            string message;
            message = "";
            message = sr.ReadLine();
            string answer = "";
            while (true)
            {

                Console.WriteLine("Client: " + message);
                if (message != null)
                {
                    if (message == "quit")
                    {
                        break;
                    }

                    string[] splitmessage = message.Split(' ');
                    string sId = splitmessage[0];
                    int id = Int32.Parse(sId);
                    string amount = splitmessage[1];
                    double amountD = double.Parse(amount);

                    CustomerLedger.Ledger[id] += amountD;
                    answer = CustomerLedger.Ledger[id].ToString();
                    sw.WriteLine(answer);



                }

                message = sr.ReadLine();
                // connection skal lukkes her, og der skal resettes
            }

            //ns.Close();
            serverSocket.Close();
            
        }
        
        

        

    }
}