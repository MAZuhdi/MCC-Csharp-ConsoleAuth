using System;
using System.Collections.Generic;

namespace AuthApp
{
    class Program
    {
        public static List<User> users = new List<User>();
        Auth auth = new Auth();
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
                        EditUser(users);
                        break;
                    case 3:
                        DeleteUser(users);
                        break;
                    case 4:
                        ShowUser(users);
                        break;
                    case 5:
                        SearchUser(users);
                        break;
                    case 6:
                        LoginMenu(users, auth);
                        break;
                    case 7:
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
            Console.WriteLine("2. Edit User");
            Console.WriteLine("3. Delete User");
            Console.WriteLine("4. Show User");
            Console.WriteLine("5. Search User");
            Console.WriteLine("6. Login");
            Console.WriteLine("7. Exit");
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
            Console.WriteLine("Tekan apa saja untuk kembali..");
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
            Console.WriteLine("Tekan apa saja untuk kembali..");
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
            Console.WriteLine("Tekan apa saja untuk kembali..");
            Console.ReadKey();
        }


        public static void LoginMenu(List<User> users, Auth auth)
        {
            Console.Clear();
            Console.Write("Username:");
            string username = Console.ReadLine();
            Console.Write("Password:");
            string password = Console.ReadLine();
            Console.WriteLine(auth.Login(username, password, users));
            Console.ReadKey();
        }

        public static void EditUser(List<User> users)
        {
            User editUser = null;
            string enteredUsername;
            Console.Write("Username :");
            do
            {
                try
                {
                    enteredUsername = Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Input tidak valid");
                    Console.Write("Username :");
                    continue;
                }
                break;
            } while (true);

            foreach (User user in users)
            {
                if (user.UserName == enteredUsername)
                {
                    editUser = user;
                } 
            }
            

            if (editUser != null)
            {
                Console.WriteLine("User ditemukan!");
                editUser.Details();
                Console.WriteLine("=====EDIT=====");
                Console.Write("Nama Depan: ");
                editUser.FirstName = Console.ReadLine();
                Console.Write("Nama Belakang: ");
                editUser.LastName = Console.ReadLine();
                Console.Write("Password: ");
                editUser.Password = Console.ReadLine();
                editUser.SetUsername(users);
                Console.WriteLine("User Updated!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("User tidak ditemukan");
            }

        }

        static void DeleteUser(List<User> users)
        {
            string deleteUser;
            Console.Clear();
            Console.WriteLine("");
            Console.Write("Masukkan user yang ingin anda delete: ");
            deleteUser = Console.ReadLine();

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].UserName == deleteUser)
                {
                    Console.WriteLine("Username yang akan didelete: " + deleteUser);

                    users.RemoveAt(i);
                    Console.WriteLine("User berhasil didelete");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Username yang ingin didelete tidak ada!");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

    }
}
