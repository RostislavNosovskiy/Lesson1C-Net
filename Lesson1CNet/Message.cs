using System;
using System.Text.Json;

namespace Lesson1CNet
{
	public class Message
	{
		public string Text { get; set; }
		public DateTime DateTime { get; set; }
		public string NickNameFrom { get; set; }
        public string NickNameTo{ get; set; }

		public string SerialazeMasegeToJson()
		{
			return JsonSerializer.Serialize(this);
        }

		public static Message? DeserialazeJsonToMassage(string json) => JsonSerializer.Deserialize<Message>(json);

		public void Print()
		{
            Console.WriteLine(ToString());
        }
		public string ToString()
		{
			return $"{DateTime} получено сooбщение: '{Text}' oт {NickNameFrom} для {NickNameTo}";

        }
       
    }
}

