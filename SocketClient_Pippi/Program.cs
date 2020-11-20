using System;
using System.Net;
using System.Net.Sockets;

namespace SocketClient_Pippi
{
    class Program
    {
        static void Main(string[] args)
        {

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp);

            string strlIpAddress = "";
            string strlPorta = "";
            IPAddress Address = null;
            int NPort;
            try
            {
                Console.WriteLine("Inserisci ip del server");
                strlIpAddress = Console.ReadLine();
                Console.WriteLine("Inserisci numero porta");
                strlPorta = Console.ReadLine();
                if (!IPAddress.TryParse(strlIpAddress.Trim(),out Address))
                {
                    Console.WriteLine("Ip non è valido");
                    return;
                }
                if(!int.TryParse(strlPorta,out NPort))
                {
                    Console.WriteLine("Porta non è valida");
                    return;
                }
                if(NPort<=0||NPort>= 65536)
                {
                    Console.WriteLine("Porta non è valida");
                    return;
                }


                Console.WriteLine("Endpoint del server "+Address.ToString()+ " "+ NPort);

                client.Connect(Address,NPort);
            }
            catch (Exception)
            {

                Console.WriteLine("C'è stato un problema");
            }
        }
    }
}
