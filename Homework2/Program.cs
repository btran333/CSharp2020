//Bao Tran
//Homework 2

using System;
using System.Linq;
using System.Collections.Generic;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steveg" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            //Find users that has password as "hello" and display on console
            var findHello = users.Where(t => t.Password == "hello");
            Console.WriteLine("Users have password as \'hello\':");
            findHello.Select(i => { Console.WriteLine("Name: " + i.Name + ".  Password: " 
                + i.Password); return false; }).ToList();


            //Delete any passwrds that are lower cased version of their name.
            Console.WriteLine("\nDelete Passwords that are lower cased of their name:");
            var delPwd = users.Where(t => t.Name.ToLower() == t.Password);

            if (delPwd == null || delPwd.Count() == 0)
            {
                Console.WriteLine("Not found.");
            }
            else
            {
                Console.WriteLine(delPwd.Count() + " records found.");
                delPwd.Select(i => { i.Password = null; return false; }).ToList();                
            }


            //Delete the first User that has password "hello"
            Console.WriteLine("\nDelete first user that has password \'hello\'");
            var delFirstHello = users.FirstOrDefault(t => t.Password == "hello");
            users.Remove(delFirstHello);


            //Display to the console the remaining Users.
            Console.WriteLine("\nThe remain users: ");
            users.Select(i => {Console.WriteLine("Name: " + i.Name + ".  Password: "+ i.Password); return false;}).ToList();
        }
    }
}
