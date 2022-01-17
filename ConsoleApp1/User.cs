using AdminNamespace;
using PostNameSpace;
using StartMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UserNamespace
{
    class User
    {
        Menu menu;
        Post post;

        public static int Id { get; set; } = 0;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(string name, string surname, string age, string email, string password)
        {
            Id++;
            Name = name;
            Surname = surname;
            Age = age;
            Email = email;
            Password = password;
        }

        public User() {}

        public void UserMenu(User[] userArr, Post[] postsArr, Admin[] adminArr)
        {
            Console.Clear();

            ConsoleKey key;

            int size = 0;
            int UserId;
            string iEmail, iPassword;

            Console.Write("Email : ");
            iEmail = Console.ReadLine();

            Console.Write("Password : ");
            iPassword = Console.ReadLine();

            if(iEmail.Length == 0 || iPassword.Length == 0)
            {
                Console.WriteLine("\nDo not leave empty space !");
                Thread.Sleep(1000);
                UserMenu(userArr, postsArr, adminArr);
            }
            else
            {

                for (int i = 0; i < userArr.Length; i++)
                {
                    size++;

                    if(userArr[i].Email == iEmail)
                    {
                        UserId = size - 1;

                        if(userArr[UserId].Password == iPassword)
                        {
                            post = new();
                                
                            post.AllShowPost(postsArr, userArr, adminArr, UserId);
                            
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

                                menu.Start(postsArr, userArr, adminArr);

                                break;
                            }
                            else
                            {
                                UserMenu(userArr, postsArr, adminArr);
                                break;
                            }
                        }
                        
                    }
                    else
                    {
                        if (i == userArr.Length - 1)
                        {
                            Console.WriteLine("\nEmail not found");

                            Thread.Sleep(1000);

                            Console.Clear();

                            Console.WriteLine("[ 1 ] Back\n[ Desired Button ] Contiune");
                            
                            key = Console.ReadKey(true).Key;
                            
                            if (key == ConsoleKey.D1)
                            {
                                menu = new();

                                menu.Start(postsArr, userArr, adminArr);

                                break;
                            }
                            else
                            {
                                UserMenu(userArr, postsArr, adminArr);
                                break;
                            }
                        } 
                    }
                }
            }
        }
    }
}
