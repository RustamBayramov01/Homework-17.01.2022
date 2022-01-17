using PostNameSpace;
using UserNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AdminNamespace;
using NotificationNamespace;

namespace StartMenu
{
    class Menu
    {
        User user;
        Admin admin;
        Notification notification;

        public void Start(Post[] postsArr, User[] usersArr, Admin[] adminArr)
        {
            admin = new();
            user = new();

            Console.Clear();

            ConsoleKey key;

            Console.WriteLine("[ 1 ] Admin\n[ 2 ] User");

            key = Console.ReadKey(true).Key;

            if(key == ConsoleKey.D1)
            {
                admin.AdminMenu(usersArr, adminArr, postsArr);
            }
            else if(key == ConsoleKey.D2)
            {
                user.UserMenu(usersArr, postsArr, adminArr);
            }
            else
            {
                Console.WriteLine("\nYou made the wrong choice !");

                Thread.Sleep(1000);
                
                Console.Clear();
                
                Start(postsArr, usersArr, adminArr);
            }
        }

    }
}
