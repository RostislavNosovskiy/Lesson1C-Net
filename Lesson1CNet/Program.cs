namespace Lesson1CNet;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Lesson1CNet;


public class Program
{
    public static void Main()
    {
        Server("");  
    }

    public static void task1()
    {
        Message message = new Message() { Text = "Hello", DateTime = DateTime.Now, NickNameFrom = "User1", NickNameTo = "server" };
        string json = message.SerialazeMasegeToJson();
        Console.WriteLine(json);
        var message1 = Message.DeserialazeJsonToMassage(json);
        Console.WriteLine(message1);
    }

    public static void Server(string name)
    {
        UdpClient udpClient = new UdpClient(12345);
        IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);
        Console.WriteLine("Сервер ждёт сообщения от клиента");
        
        while (true)
        {
            byte[] buffer = udpClient.Receive(ref iPEndPoint);
            string massageText = Encoding.UTF8.GetString(buffer);
            Message? message = Message.DeserialazeJsonToMassage(massageText);
            message.Print();

            string mes = $"Сообщение '{message.Text}' отправлено";
            byte[] bufferSend = Encoding.UTF8.GetBytes(mes);
            udpClient.Send(bufferSend, bufferSend.Length, iPEndPoint);
            
        }
    }

}

