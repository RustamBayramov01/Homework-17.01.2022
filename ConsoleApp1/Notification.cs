using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserNamespace;

namespace NotificationNamespace
{
    class Notification
    {

        public static int Id { get; set; } = 0;
        public string Text { get; set; }
        public DateTime DateTimee { get; set; }
        public string FromUser { get; set; }

        public Notification(string text, DateTime dateTimee, string fromUser)
        {
            Id++;
            Text = text;
            DateTimee = dateTimee;
            FromUser = fromUser;
        }

        public Notification() { }

        public void NotificationPanel()
        {
            Console.Clear();
        
            string folder = @"C:\Users\LITHIUM\Desktop\Yeni klasör\ConsoleApp1\ConsoleApp1\Notification\NotfText.txt";  // folder icinde her notbuka gore txt adresin gosdere bilmedim  
            FileStream fs = new FileStream(folder, FileMode.Open, FileAccess.Read);

            StreamReader sw = new StreamReader(fs);

            string text = sw.ReadLine();
            while (text != null)
            {
                Console.WriteLine(text);
                text = sw.ReadLine();
            }

            Console.WriteLine("\nAfter 5 seconds, you will be directed to the admin panel.");
            
            sw.Close();
            fs.Close();
            
        }
    }
}
