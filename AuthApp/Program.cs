using System;
using System.Collections.Generic;

namespace AuthApp
{
    class Program
    {
        public static List<User> users = new List<User>();
        public static Auth auth = new Auth();
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
                        auth.CheckLogin();
                        break;
                    case 8:
                        auth.Logout();
                        break;
                    case 9:
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
            if (auth.FirstName != null)
            {
                Console.WriteLine("Halo, " + auth.FirstName);
            }
            Console.WriteLine("=========================");
            Console.WriteLine("Silahkan pilih menu:     ");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Edit User");
            Console.WriteLine("3. Delete User");
            Console.WriteLine("4. Show User");
            Console.WriteLine("5. Search User");
            Console.WriteLine("6. Login");
            Console.WriteLine("7. Check Login");
            Console.WriteLine("8. Logout");
            Console.WriteLine("9. Exit");
            Console.Write("=> ");
        }

        private static User CreateUser(List<User> users)
        {
            User user = new User();
            Console.Clear();
            do
            {
                try
                {
                    Console.Write("Nama Depan: ");
                    user.FirstName = Console.ReadLine();
                    Console.Write("Nama Belakang: ");
                    user.LastName = Console.ReadLine();
                    Console.Write("Password: ");
                    user.Password = Console.ReadLine();
                    user.SetUsername(users);

                    if (user.FirstName != String.Empty && user.LastName != String.Empty && user.Password != String.Empty && user.FirstName.Length >= 2 && user.LastName.Length >= 2)
                        //if (user.FirstName != "" && user.LastName != "" && user.Password != "" && user.FirstName.Length >= 2 && user.LastName.Length >= 2)
                    {
                        Console.WriteLine("\nUser Created!");
                    }
                    else {
                        Console.WriteLine("\nInput tidak valid");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nInput tidak valid");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                break;
            } while (true);

            Console.WriteLine("\nPress any key to continue");
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
                do
                {
                    try
                    {
                        Console.WriteLine("User ditemukan!");
                        editUser.Details();

                        Console.WriteLine("=====EDIT=====");
                        Console.Write("Nama Depan: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Nama Belakang: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Password: ");
                        string password = Console.ReadLine();

                        if (firstName != "" && lastName != "" && password != "" && firstName.Length >=2 && lastName.Length >=2)
                        {
                            editUser.FirstName = firstName;
                            editUser.LastName = lastName;
                            editUser.Password = password;
                            editUser.SetUsername(users);
                            Console.WriteLine("\nUser Created!");
                        }
                        else
                        {
                            Console.WriteLine("\nInput tidak valid");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        }

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nInput tidak valid");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                    break;
                } while (true);

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
            string msg = "";
            Console.Clear();
            Console.WriteLine("");
            Console.Write("Masukkan Username yang ingin anda delete: ");
            deleteUser = Console.ReadLine();
            
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].UserName == deleteUser)
                {
                    if (auth.UserName != null)
                    {
                        if (auth.UserName == deleteUser)
                        {
                            Console.WriteLine("Username tidak bisa dihapus");
                            Console.ReadKey();
                            break;
                        }
                    }
                    Console.WriteLine("Username yang akan didelete: " + deleteUser);

                    users.RemoveAt(i);
                    msg = "User berhasil didelete";
                    //Console.WriteLine("User berhasil didelete");
                    //Console.WriteLine("Press any key to continue...");
                    //Console.ReadLine();
                }
                else
                {
                    msg = "Username yang ingin didelete tidak ada!";
                    //Console.WriteLine("Username yang ingin didelete tidak ada!");
                    //Console.ReadLine();
                    //Console.Clear();
                }
            }
            Console.WriteLine(msg);
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.Clear();
        }

    }
}
