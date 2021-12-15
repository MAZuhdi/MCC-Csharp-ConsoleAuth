using System;
using System.Collections.Generic;

namespace AuthApp
{
    class Program
    {
        public static List<User> users = new List<User>();
        static void Main(string[] args)
        {

            bool run = true;
            while (run)
            {
                Console.Clear();
                Menu();
                int choiceMenu;
                do
                {
                    try
                    {
                        choiceMenu = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Input tidak valid");
                        continue;
                    }
                    break;
                } while (true);

                switch (choiceMenu)
                {
                    case 1:
                        users.Add(CreateUser(users));
                        break;
                    case 2:
                        ShowUser(users);
                        break;
                    case 3:
                        SearchUser(users);
                        break;
                    case 4:
                        LoginMenu(users);
                        break;
                    case 5:
                        run = false;
                        Console.WriteLine("APLIKASI DITUTUP..");
                        break;
                    default:
                        break;
                }
            }
        }

        public static void Menu()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("=====Selamat datang======");
            Console.WriteLine("Silahkan pilih menu:     ");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Show User");
            Console.WriteLine("3. Search User");
            Console.WriteLine("4. Login");
            Console.WriteLine("5. Exit");
            Console.Write("=> ");
        }

        private static User CreateUser(List<User> users)
        {
            User user = new User();
            Console.Clear();
            Console.Write("Nama Depan: ");
            user.FirstName = Console.ReadLine();
            Console.Write("Nama Belakang: ");
            user.LastName = Console.ReadLine();
            Console.Write("Password: ");
            user.Password = Console.ReadLine();
            user.SetUsername(users);
            Console.WriteLine("User Created!");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            return user;
        }

        public static void ShowUser(List<User> users)
        {
            Console.Clear();
            Console.Write("2. Show User");
            foreach (User user in users)
            {
                user.Details();
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public static void SearchUser(List<User> users)
        {
            Console.Clear();
            Console.Write("3. Search Username: ");
            string searchedUsername = Console.ReadLine();
            foreach (User user in users)
            {
                if (user.UserName == searchedUsername)
                {
                    user.Details();
                    break;
                }
                Console.WriteLine("USERNAME TIDAK DITEMUKAN");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }


        public static void LoginMenu(List<User> users)
        {
            Auth auth = new Auth();
            Console.Write("Username:");
            string username = Console.ReadLine();
            Console.Write("Password:");
            string password = Console.ReadLine();

            Console.WriteLine(Login(username, password, users));;
            Console.ReadKey();
        }

        public static string Login(string username, string password, List<User> users)
        {
            foreach (User user in users)
            {
                if (username == user.UserName)
                {
                    if (password == user.Password)
                    {
                        return "Login Berhasil";
                    }
                    else
                    {
                        return "Password Salah";
                    }
                }
            }
            return "Username tidak ditemukan";
        }

    }
}
