using System;
using System.Collections.Generic;
using System.Text;

namespace AuthApp
{
    public class Auth : User
    {
        //public string Username { get; private set; }
        //public string Password { get; private set; }
        //public Auth(string username, string password)
        //{
        //    Username = username;
        //    Password = password;
        //}
        public Auth() { }
        public string Login(string username, string password, List<User> users)
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