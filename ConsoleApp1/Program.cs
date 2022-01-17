using PostNameSpace;
using UserNamespace;
using StartMenu;
using System;
using AdminNamespace;
using NotificationNamespace;

Menu menu = new();

DateTime dateTime = DateTime.Now;


Post post1 = new("#WINNINGWEDNESDAY is back with Vancouver based businesses", dateTime, 0, 0);
Post post2 = new("Carmen Sandiego found dead in a ditch", dateTime, 0, 0);
Post post3 = new("How to clean the front load sea", dateTime, 0, 0);
Post post4 = new("To celebrate #InternationalDogDay we wanted to share this video of our #HootDogs We miss seeing them around the office a little extra today. ", dateTime, 0, 0);
Post post5 = new("IT'S MEET DAY", dateTime, 0, 0);


User user1 = new("Rustam", "Bayramov", "18", "rustam.bayramov.989@gmail.com", "123123");
User user2 = new("Resul", "Aliyarli", "25", "resul.aliyarli.898@gmail.com", "123456");


Notification[] Notifications = new Notification[] { };


Post[] postsArr = new Post[]
{
    post1,
    post2,
    post3,
    post4,
    post5
};


Admin admin = new("Telman", "Telman.Melikov@gmail.com", "admin123", postsArr, Notifications);


Admin[] adminArr = new Admin[]
{
    admin
};


User[] usersArr = new User[]
{
    user1,
    user2
};

menu.Start(postsArr, usersArr , adminArr);