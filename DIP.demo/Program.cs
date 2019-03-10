using System;
using System.Collections.Generic;

namespace DIP.demo
{
    class Program
    {
        static void Main(string[] args)
        {
            ICollection<IMessage> msgs= new List<IMessage>();
            msgs.Add(new Email());
            msgs.Add(new SMS());

            Notification n = new Notification(msgs);
            n.Send();
        }
    }


    public interface IMessage
    {
        void SendMessage();

    }

    public class Email : IMessage
    {
        public string ToAddress { get; set; }
        public string FromAddress { get; set; }
        public string Content { get; set; }
        public void SendMessage()
        {
            Console.WriteLine("Email Sent");
        }
    }

    public class SMS : IMessage
    {
        public string PhoneNumber { get; set; }
        public string Message { get; set; }

        public void SendMessage()
        {
            Console.WriteLine("SMS sent");
        }

    }

    public class Notification
    {
        private ICollection<IMessage> _messages;

        public Notification(ICollection<IMessage> messages)
        {
            this._messages = messages;
        }
        public void Send()
        {
            foreach (var message in _messages)
            {
                message.SendMessage();
            }
        }

    }
}
