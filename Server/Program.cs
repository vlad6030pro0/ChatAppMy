using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[SERVER]");

            StreamWriter writer = new StreamWriter("C:\\Users\\Влад\\source\\repos\\ChatAppMy\\log.txt");
            writer.WriteLine("-----------------------------");
            writer.WriteLine($"Начало новой сессии записи: {DateTime.Now}");
            
            string ipLine = "127.0.0.1";
            int port = 6030;

            IPAddress ipAdress = IPAddress.Parse(ipLine);
            IPEndPoint ipEndPoint = new IPEndPoint(ipAdress,port);

            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp);
            server.Bind(ipEndPoint);
            server.Listen(4);

            Console.WriteLine("Сервер запущен. Ожидается подключение");
            Socket client = server.Accept();

            Console.WriteLine("Получено подключение");

            int count = 0;
            byte[] bytes = new byte[512];
            while(Encoding.ASCII.GetString(bytes,0,count)!="exit")
            {
                bytes = new byte[512];
                count = client.Receive(bytes);
                string message = Encoding.ASCII.GetString(bytes,0,count);
                Console.WriteLine($"Сообщение от клиента: {message}");
                writer.WriteLine($"Сообщение от клиента: {message}");
            }
            Console.WriteLine("Клиент разорвал соединение. Нажмите на любую клавишу для завершения.");
            writer.WriteLine("Конец сессии записи");
            writer.WriteLine("-----------------------------");
            writer.Close();
            Console.ReadLine();
        }
    }
}
