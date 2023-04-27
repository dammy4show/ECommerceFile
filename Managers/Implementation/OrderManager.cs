using System;
using System.Collections.Generic;
using System.IO;
using ECommerce_File.Managers.Interface;
using ECommerce_File.Models.Entities;

namespace ECommerce_File.Managers.Implementation
{
    
        public class OrderManager : IOrderManager
        {

            List<Order> orderDB = new List<Order>();
            string file = @"C:\Users\user\Desktop\ECommerceAppFile\Files\order.txt";

        private void ReadToFile()
        {
            if(File.Exists(file))
            {
                var orders = File.ReadAllLines(file);
                foreach(var order in orders)
                {
                    orderDB.Add(Order.ToOrder(order));
                }
            }
            else
            {
                string path =  @"C:\Users\user\Desktop\ECommerceAppFile\Files";
                Directory.CreateDirectory(path);
                string fileName = "orderDB.txt";
                string fullPath = Path.Combine(path, fileName);
                File.Create(fullPath);
            }
        }

        private void AddOrderToFile(Order order)
        {
            using(StreamWriter stw = new StreamWriter(file, true))
            {
                stw.WriteLine(order.ToString());
            }
        }
        private void RefreshFile()
        {
            using(StreamWriter stw = new StreamWriter(file))
            {
                foreach(var order in orderDB)
                {
                    stw.WriteLine(order.ToString());
                }
                
            }
        }

        public Order Create( string customerEmail, Dictionary<string, int> cart )
        {
            
            int id = orderDB.Count +1;
            bool isDeleted = false;
            Order order = new Order(id, customerEmail, cart, isDeleted);
            orderDB.Add(order);
            AddOrderToFile(order);
            return order;

        }

        public void Delete(int id)
        {
            var order = CheckIfExist(id);
            if(order != null)
            {
                orderDB.Remove(order);
                Console.WriteLine($"{order.Id} has been successfully deleted");
            }
            Console.WriteLine($"{order.Id} does not exist");
            
            
        }

        public Order Get(int id)
        {
            foreach(var order in orderDB)
            {
                if(order.Id == id)
                {
                    return order;
                }
            }
            return null;
        }

        public List<Order> GetAll()
        {
            return orderDB;
        }

        private Order CheckIfExist(int id)
        {
            foreach(var order in orderDB)
            {
                if(order.Id == id)
                {
                    return order;
                }
            }
            return null;

        }

        private Order CheckIfExist(string email)
        {
            foreach(var order in orderDB)
            {
                if(order.Email== email)
                {
                    return order;
                }
            }
            return null;

        }

        public Order Update(string Email, Dictionary<string, int> cart)
        {
            var order = CheckIfExist(email);
            {
                if(order != null)
                {
                    order.CustomerEmail  = customerEmail;
                    order.Cart = cart;
                    return order;
                }
                Console.WriteLine($"{order.Name} does not exist...Sign Up");
                return null;
            }
        }
    }
}