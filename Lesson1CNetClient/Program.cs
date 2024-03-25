using System.Net;
using System.Net.Sockets;
using System.Text;
using Lesson1CNet;
using static System.Net.Mime.MediaTypeNames;

namespace Lesson1CNetClient;

public class Program
{
    public static void Main(string[] args)
    {

        SentMessage("127.0.0.1");
    }


    public static void SentMessage(string ip, string user = "User1" )
    {
        UdpClient udpClient = new UdpClient();
        IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(ip), 12345);
        
        while (true)
        {
            string? messageText;
            do
            {
                
                Console.WriteLine("Введите собщение");
                messageText = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(messageText));
            Message message = new Message() { Text = messageText, DateTime = DateTime.Now, NickNameFrom = user, NickNameTo = "Server" };
            string json = message.SerialazeMasegeToJson();
            byte[] data = Encoding.UTF8.GetBytes(json);
            udpClient.Send(data, data.Length, iPEndPoint);
            byte[] buffer = udpClient.Receive(ref iPEndPoint);
            string massageText = Encoding.UTF8.GetString(buffer);
            Console.WriteLine(massageText);
            
        }
    }
}
