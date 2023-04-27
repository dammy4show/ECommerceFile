using System;
using System.Collections.Generic;
using System.IO;
using ECommerce_File.Managers.Interface;
using ECommerce_File.Models.Entities;

namespace ECommerce_File.Managers.Implementation
{
    public class AdminManager :IAdminManager
    {
        List<Admin> adminDB = new List<Admin>();
         string file = @"C:\Users\user\Desktop\ECommerceAppFile\Files\admin.txt";

         private void ReadAdminToFile()
         {
            if(File.Exists(file))
            {
                var admins = File.ReadAllLines(file);
                foreach (var admin in admins)
                {
                    adminDB.Add(Admin.ToAdmin(admin));
                }

            }
            else
            {
                string path = @"C:\Users\user\Desktop\ECommerceAppFile\Files";
                Directory.CreateDirectory(path);
                string fileName = "admin.txt";
                string fullPath = Path.Combine(path, fileName);
                File.Create(fullPath);
            }
         }

         private void AddAdminToFile(Admin admin)
         {
            using (StreamWriter stw = new StreamWriter(file, true))
            {
                stw.WriteLine(admin.ToString());
            }
         }

         private void RefreshFile()
         {
            using(StreamWriter stw = new StreamWriter(file))
            foreach(var item in adminDB)
            {
                stw.WriteLine(item.ToString());
            }
         }

         

        public Admin Update(string email, string name, string phoneNumber, string password, string address)
        {
            var admin = CheckIfExist(email);
            if(admin != null)
            {
                
                admin.Name = name;
                admin.Email = email;
                admin.PhoneNumber = phoneNumber;
                admin.Password = password;
                admin.Address = address;
                Console.WriteLine($"{admin.Name}\t {admin.Email}\t {admin.PhoneNumber}\t{admin.Password} {admin.Address} has been updated.");
                return admin;
            }
            return null;
        }

        public Admin Login(string email, string password)
        {
            foreach(var item in adminDB)
            {
                if(item.Email== email && item.Password ==password )
                {
                    Console.WriteLine($"You are welcome {item.Name} as the Admin.");
                    return item;
                }
            }
            return null;
        }

        private Admin CheckIfExist(string email)
        {
            foreach(var admin in adminDB)
            {
                
                if(admin.Email == email)
                {
                    return admin;
                }
            }
            return null;
        }

       
    }
}