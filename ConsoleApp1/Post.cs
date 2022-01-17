using System;
using UserNamespace;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using StartMenu;
using AdminNamespace;
using NotificationNamespace;
using System.IO;

namespace PostNameSpace
{
    class Post
    {
        Menu menu;
        Admin admin;

        public string Content { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int LikeCount { get; set; }
        public int ViewCount { get; set; }

        public Post(string content, DateTime creationDateTime, int likeCount, int viewCount)
        {
            Content = content;
            CreationDateTime = creationDateTime;
            LikeCount = likeCount;
            ViewCount = viewCount;
        }

        public Post() { }

        public void AllShowPost(Post[] postArr, User[] userArr, Admin[] adminArr, int Index)
        {
            
            ConsoleKey key;

            int postSize = 0;
            string selection;

            Console.Clear();

            foreach (var item in postArr)
            {
                ++postSize;

                Console.WriteLine($"[ {postSize} ] Content : {item.Content}");
            }

            Console.WriteLine("\n[ M ] Back");

            Console.Write("\nSelection : ");
            selection = Console.ReadLine();

            if (selection.Length == 0)
            {
                Console.WriteLine("\nYou made the wrong choice !");
                Thread.Sleep(1000);
                AllShowPost(postArr, userArr, adminArr, Index);
            }
            else
            {
                if (selection == "M")
                {
                    menu = new();
                    menu.Start(postArr, userArr, adminArr);
                }
                else
                {
                    if (int.Parse(selection) > postSize)
                    {
                        Console.WriteLine("\nYou made the wrong choice !");
                        Thread.Sleep(1000);
                        AllShowPost(postArr, userArr, adminArr, Index);
                    }
                    else
                    {
                        Console.Clear();

                        string folder = @"C:\Users\LITHIUM\Desktop\Yeni klasör\ConsoleApp1\ConsoleApp1\Notification\NotfText.txt";  // folder icinde her notbuka gore txt adresin gosdere bilmedim  

                        FileStream fs = new FileStream(folder, FileMode.Append, FileAccess.Write, FileShare.Write);
                        StreamWriter sw = new StreamWriter(fs);


                        DateTime dateTime = DateTime.Now;
                        string name = userArr[Index].Name;

                        sw.WriteLine("---------------------");
                        sw.WriteLine(name);
                        sw.WriteLine(dateTime);

                        sw.Flush();
                        sw.Close();
                        fs.Close();

                        Console.WriteLine("-----------------------------------\n");
                        Console.WriteLine($"Content : {postArr[int.Parse(selection) - 1].Content}\nCreation DateTime : {postArr[int.Parse(selection) - 1].CreationDateTime}\nLike : {postArr[int.Parse(selection) - 1].LikeCount}\n");
                        Console.WriteLine("-----------------------------------");

                        Console.WriteLine("\n[ 1 ] Like Post\n\n[ Desired Button ] Back");

                        key = Console.ReadKey(true).Key;

                        if (key == ConsoleKey.D1)
                        {
                            postArr[int.Parse(selection) - 1].LikeCount += 1;
                            postArr[int.Parse(selection) - 1].ViewCount += 1;

                            AllShowPost(postArr, userArr, adminArr, Index);
                        }
                        else AllShowPost(postArr, userArr, adminArr, Index);
                    }
                }
            }

            
        }

        public void ShowCheckPosts(Post[] arr, User[] use, Admin[] adminA)
        {
            admin = new();

            Console.Clear();

            ConsoleKey key;

            foreach (var item in arr)
            {
                Console.WriteLine("-----------------------------------\n");
                Console.WriteLine($"Content : {item.Content}\nCreation DateTime : {item.CreationDateTime}\nLike : {item.LikeCount}\nView : {item.ViewCount}\n");
            }

            Console.WriteLine("\n[ M ] Back");

            key = Console.ReadKey(true).Key;

            if(key == ConsoleKey.M)
            {
                admin.AdminPanel(use, adminA, arr);
            }
            else
            {
                Console.WriteLine("\nYou made the wrong choice !");
                Thread.Sleep(1000);
                ShowCheckPosts(arr, use, adminA);
            }
        }
    }
}
