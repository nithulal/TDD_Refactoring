using System;

namespace LegacyApp.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            ProveAddUser(args);
        }

        public static void ProveAddUser(string[] args)
        {
           
            var userService = new UserService();
            var addResult = userService.AddUser("Nithu", "Lal", "test@gmail.com", new DateTime(1991, 1, 1), 4);
            Console.WriteLine("Adding Nithu Lal was " + (addResult ? "successful" : "unsuccessful"));
        }
    }
}
