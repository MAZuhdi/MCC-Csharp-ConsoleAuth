using System;
using System.Collections.Generic;
using System.Text;

namespace AuthApp
{
    public class Auth : User
    {
        public Auth() { }
        public string Login(string username, string password, List<User> users)
        {
            foreach (User user in users)
            {
                if (username == user.UserName)
                {
                    if (password == user.Password)
                    {
                        FirstName = user.FirstName;
                        LastName = user.LastName;
                        UserName = user.UserName;
                        Password = user.Password;
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

        public void CheckLogin()
        {
            if (FirstName != null && 
                LastName != null && 
                UserName != null && 
                Password != null)
            {
                Console.Clear();
                Console.WriteLine("Check Login");
                Details();
                Console.WriteLine("Tekan apa saja untuk kembali..");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Anda belum login");
                Console.WriteLine("Tekan apa saja untuk kembali..");
                Console.ReadKey();
            }
        }

        public void Logout()
        {
            Console.WriteLine("Berhasil Logout");
            if (FirstName != null &&
                LastName != null &&
                UserName != null &&
                Password != null)
            {
                FirstName = null;
                LastName = null;
                UserName = null;
                Password = null;
                Console.Clear();
                Console.WriteLine("Berhasil Logout");
                Console.WriteLine("Tekan apa saja untuk kembali..");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Anda belum login");
                Console.WriteLine("Tekan apa saja untuk kembali..");
                Console.ReadKey();
            }
        }

    }
}