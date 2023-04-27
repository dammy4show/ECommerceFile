using System;
using System.Collections.Generic;
using System.IO;
using ECommerce_File.Managers.Interface;
using ECommerce_File.Models.Entities;

namespace ECommerce_File.Managers.Implementation
{
    public class UserManager : IUserManager
    {

        List<User> userDB = new List<User>();
        string file =  @"C:\Users\user\Desktop\ECommerceAppFile\Files\user.txt";

        private void ReadUserToFile()
        {
            if(File.Exists(file))
            {
                var users = File.ReadAllLines(file);
                foreach(var user in users)
                {
                    userDB.Add(User.ToUser(user));
                }
            }
            else
            {
                string path =@"C:\Users\user\Desktop\ECommerceAppFile\Files";
                Directory.CreateDirectory(path);
                string fileName = "user.txt";
                string fullpath = Path.Combine(path, fileName);
                File.Create(fullpath);


            }
            
        }

        private void AddUserToFile(User user)
        {

            using (StreamWriter stw = new StreamWriter(file, true))
            {
                stw.WriteLine(user.ToString());
            }
        }

        public void Delete(string email)
        {
            var user =  CheckIfExist(email);
            {
                if(user != null)
                {
                    userDB.Remove(user);
                    Console.WriteLine("User successfully deleted");
                }
                Console.WriteLine("User does not exists");
            }
        }

        public User Get(int id)
        {
            foreach(var user in userDB )
            {
                if(user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }

        public User Get(string email)
        {
            foreach(var user in userDB)
            {
                if(user.Email == email)
                {
                    return user;
                }
            }
            return null;
        }

        public List<User> GetAll()
        {
            return userDB;
        }

        public User Login(string email, string password)
        {
            foreach(var user in userDB)
            {
                if(user.Email == email && user.Password == password)
                {
                    Console.WriteLine("You are welcome...Thank you for visiting our store");
                    return user;
                }
            }
            Console.WriteLine("You need to sign up");
            return  null;

        }

        public User Register(string name, string phoneNumber, string password, string email, string address)
        {
            int id = userDB.Count +1;
            decimal wallet = 0;
            string role = "user";
            bool isDeleted = false;
            User user = new  User(id, name, email, password, address, wallet, role, phoneNumber, isDeleted);
            userDB.Add(user);
            AddUserToFile(user);
            return user;
        }

        public User Update( string name, string address, string email, string password, string phoneNumber)
        {
            var user = CheckIfExist(email);
            if(user != null)
            {
                user.Name = name;
                user.Address = address;
                user.Email = email;
                user.Password = password;
                user.PhoneNumber = phoneNumber;
                return user;
            }
            return null;


        }

        

        private User CheckIfExist(string email)
        {
            foreach( var user in userDB)
            {
                if(user.Email == email)
                {
                    return user;
                }
            }
            return null;
        }
    }
}