using System;
using System.IO;
using System.Net.Mail;
namespace forNik
{
    class Program
    {

        static void Main(string[] args)
        {
            Mailbox help_me = new Mailbox("/Users/alex/Projects/forNik/forNik/Gmail", "1223", "1223");
            Mailbox fuck_me = new Mailbox("/Users/alex/Projects/forNik/forNik/Mail", "1223", "1223");
            Console.WriteLine("To Alex");
            Console.WriteLine("Theme");
            string them = Console.ReadLine();
            Console.WriteLine("Text:");
            string text = Console.ReadLine();
            help_me.send_email("/Users/alex/Projects/forNik/forNik/Mail/Inbox", "Alex", them, text);
        }

    }
}