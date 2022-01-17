using NotificationNamespace;
using PostNameSpace;
using StartMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserNamespace;

namespace AdminNamespace
{
    class Admin
    {
        Menu menu = new();
        Post post = new();
        Notification notification;

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Post[] Posts { get; set; }
        public Notification[] Notifications { get; set; }

        public Admin(string username, string email, string password, Post[] posts, Notification[] notifications)
        {
            Username = username;
            Email = email;
            Password = password;
            Posts = posts;
            Notifications = notifications;
        }

        public Admin() { }

        public void AdminMenu(User[] userArr, Admin[] admin, Post[] postsArr)
        {
            Console.Clear();

            ConsoleKey key;

            int size = 0;
            int AdminId;
            string iEmail, iPassword;

            Console.Write("Email : ");
            iEmail = Console.ReadLine();

            Console.Write("Password : ");
            iPassword = Console.ReadLine();

            if (iEmail.Length == 0 || iPassword.Length == 0)
            {
                Console.WriteLine("\nDo not leave empty space !");
                Thread.Sleep(1000);
                AdminMenu(userArr, admin, postsArr);
            }
            else
            {

                for (int i = 0; i < admin.Length; i++)
                {
                    size++;

                    if (admin[i].Email == iEmail)
                    {
                        AdminId = size - 1;

                        if (admin[AdminId].Password == iPassword)
                        {
                            AdminPanel(userArr, admin, postsArr);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nEmail not found");

                            Thread.Sleep(1000);

                            Console.Clear();

                            Console.WriteLine("[ 1 ] Back\n[ Desired Button ] Contiune");

                            key = Console.ReadKey(true).Key;

                            if (key == ConsoleKey.D1)
                            {
                                menu = new();

                                menu.Start(postsArr, userArr, admin);

                                break;
                            }
                            else
                            {
                                AdminMenu(userArr, admin, postsArr);
                                break;
                            }
                        }

                    }
                    else
                    {
                        if (i == admin.Length - 1)
                        {
                            Console.WriteLine("\nEmail not found");

                            Thread.Sleep(1000);

                            Console.Clear();

                            Console.WriteLine("[ 1 ] Back\n[ Desired Button ] Contiune");

                            key = Console.ReadKey(true).Key;

                            if (key == ConsoleKey.D1)
                            {
                                menu = new();

                                menu.Start(postsArr, userArr , admin);

                                break;
                            }
                            else
                            {
                                AdminMenu(userArr, admin, postsArr);
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void AdminPanel(User[] userArr, Admin[] admin, Post[] postsArr)
        {
            ConsoleKey key;

            Console.Clear();

            Console.WriteLine("[ 1 ] Check posts\n[ 2 ] Notification\n[ 3 ] Back");

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.D1)
            {
                post.ShowCheckPosts(postsArr, userArr, admin);
            }
            else if (key == ConsoleKey.D2)
            {
                notification = new();
                notification.NotificationPanel();
                Thread.Sleep(5000);
                AdminPanel(userArr, admin, postsArr);
                
            }
            else if (key == ConsoleKey.D3)
            {
                menu.Start(postsArr, userArr, admin);
            }
            else
            {
                Console.WriteLine("\nYou made the wrong choice !");
                Thread.Sleep(1000);
                AdminPanel(userArr, admin, postsArr);
            }
        }
    }
}
