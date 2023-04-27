using System;
using System.Collections.Generic;
using System.IO;
using ECommerce_File.Managers.Interface;
using ECommerce_File.Models.Entities;

namespace ECommerce_File.Managers.Implementation
{
    public class RiderManager : IRiderManager
    {
        List<Rider> riderDB = new List<Rider>();
        string file = @"C:\Users\user\Desktop\ECommerceAppFile\Files\rider.txt";


        private void ReadToFile()
        {
            if(File.Exists(file))
            {
                var riders = File.ReadAllLines(file);
                foreach(var rider in riders)
                {
                    riderDB.Add(Rider.ToRider(rider));
                }
            }
            else
            {
                string path =  @"C:\Users\user\Desktop\ECommerceAppFile\Files";
                Directory.CreateDirectory(path);
                string fileName = "riderDB.txt";
                string fullPath = Path.Combine(path, fileName);
                File.Create(fullPath);
            }
        }

        private void AddRiderToFile(Rider rider)
        {

            using (StreamWriter stw = new StreamWriter(file, true))
            {
                stw.WriteLine(rider.ToString());
            }
        }

        private void RefreshFile()
        {
            using(StreamWriter stw = new StreamWriter(file))
            {
                foreach(var rider in riderDB)
                {
                    stw.WriteLine(rider.ToString());
                }
                
            }
        }
        public void Delete(int id)
        {
           
            var rider = CheckIfExist(id);
            if(rider != null)
            {
                riderDB.Remove(rider);
                Console.WriteLine($"{rider.Id} has been successfully deleted");
            }
                Console.WriteLine($"{rider.Id} does not exist "); 
        }
          

        public Rider Get(int id)
        {
            foreach(var rider in riderDB)
            {
                if(rider.Email == email)
                {
                    return rider;
                }
            }
            return null;
        }

        public Rider Get(string email)
        {
            foreach(var rider in riderDB)
            {
                if(rider.Email == email)
                {
                    return rider;
                }
            }
            return null;
        }

        public List<Rider> GetAll()
        {
            return riderDB;
        }

        public Rider Login(string email, string password)
        {
            foreach(var rider in riderDB)
            {
                if(rider.Email == email && rider.Password == password)
                {
                    Console.WriteLine("You have succesffully log in");
                    return rider;
                }
            }
            return null;
        }

        public Rider Register(string name, string phoneNumber, string password, string email, string address)
        {
            double wallet = 0;
            string role = "Rider";
            bool isDeleted = false;
            Rider rider =  new Rider(id, name, email,password, address,  phoneNumber, wallet, role, isDeleted);
            riderDB.Add(rider);
            AddRiderToFile(rider);
            return rider;
        }

        public Rider Update(int id, string name, string address)
        {
            
            var rider = CheckIfExist(id);
            if(rider != null)
            {
                rider.Id = id;
                rider.Name = name;
                rider.PhoneNumber = phoneNumber;
                rider.Address = address;
                return rider;
            }

        }
         private Rider CheckIfExist(string email)
        {
            foreach(var rider in riderDB)
            {
                if(rider.Email == email)
                {
                    return rider;
                }
            }
            return null;
        }

        private Rider CheckIfExist(int id)
        {
            foreach(var rider in riderDB)
            {
                if(rider.Id == id)
                {
                    return rider;
                }
            }
            return null;
        }
        
    }
}