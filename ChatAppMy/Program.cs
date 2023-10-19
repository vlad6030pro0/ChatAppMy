using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChatAppMy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[CLIENT]");

            string ipLineServer = "127.0.0.1";
            int port = 6030;

            IPAddress ipAdress = IPAddress.Parse(ipLineServer);
            IPEndPoint ipEndPoint = new IPEndPoint(ipAdress, port);

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Нажмите любую клавишу чтобы подключиться к серверу");
         
            client.Connect(ipEndPoint);
            Console.WriteLine("Клиент подлючился к серверу. Напишите сообщение");
            string phrase = "";
            while (phrase!="exit")
            {
                phrase = Console.ReadLine();
                byte[] bytes = Encoding.ASCII.GetBytes(phrase);
                client.Send(bytes);
                Console.WriteLine("Информация отправлена на сервер");
            }

            Console.WriteLine("Вы разорвали соединение с сервером. Нажмите на любую клавишу для завершения.");

            Console.ReadLine();
        }
    }
}
