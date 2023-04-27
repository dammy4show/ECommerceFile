using System;
using System.Collections.Generic;
using System.IO;
using ECommerce_File.Managers.Interface;
using ECommerce_File.Models.Entities;

namespace ECommerce_File.Managers.Implementation
{
        public class CustomerManager : ICustomerManager
        {
            List<Customer> customerDB = new List<Customer>();
            string file = @"C:\Users\user\Desktop\ECommerceAppFile\Files\customer.txt";

        private  void ReadCustomerToFile()
        {
            if(File.Exists(file))
            {
                var customers = File.ReadAllLines(file);
                foreach(var customer in customers)
                {
                    customerDB.Add(Customer.ToCustomer(customer));
                }
            }
            else
            {
                string path = @"C:\Users\user\Desktop\ECommerceAppFile\Files";
                Directory.CreateDirectory(path);
                string fileName = "customer.text";
                string fullPath = Path.Combine(path, fileName);
                File.Create(fullPath);

            }
        }

        private void AddCustomerToFile(Customer customer)
        {

            using (StreamWriter stw = new StreamWriter(file, true))
            {
                stw.WriteLine(customer.ToString());
            }
        }

        private void RefreshFile()
        {
            using(StreamWriter stw = new StreamWriter(file))
            {
                foreach(var customer in customerDB)
                {
                    stw.WriteLine(customer.ToString());
                }
                
            }
        }
        public void Delete(string email)
        {
            var customer = CheckIfExist(email);
            
            if(customer != null)
            {
                customerDB.Remove(customer);
                Console.WriteLine($"{customer.Name} has been successfully deleted");
            }
                Console.WriteLine($"{customer.Name} does not exist ");
        }

        public void FundWallet(string email, decimal amount)
        {
            var customer = CheckIfExist(email);
            if( amount < 0)
            {
                Console.WriteLine("You have entered a wrong input");
            }
            else
            {
                customer.Wallet += amount;
                Console.WriteLine($"Your account has been funded with {amount} and your balance is {customer.Wallet}");
            }
        }

        public Customer Get(string email)
        {
            foreach(var customer in customerDB)
            {
                if(customer.Email == email)
                {
                    return customer;
                }
            }
            return null;
        }

        public List<Customer> GetAll()
        {
            return customerDB;
        }

        public Customer Login(string email, string password)
        {
            foreach(var customer in customerDB)
            {
                if(customer.Email == email && customer.Password == password)
                {
                    Console.WriteLine("You have succesffully log in");
                    return customer;
                }
            }
            return null;
        }

        public decimal MakePayment(decimal amount, string email)
        {
            foreach(var customer in customerDB)
            {
                if(customer.Email == email)
                {
                    if(customer.Wallet >= amount )
                    {
                        customer.Wallet -= amount;
                        DateTime  now = DateTime.Now;
                        Console.WriteLine($"Your account has been debited with {amount} at {now.ToString("F")} and your balance is {customer.Wallet}");
                        return amount;
                    }
                    else 
                    {
                        Console.WriteLine("Insufficent Balance");
                        FundWallet(email, amount);
                        return 0;

                    }
                }
            }
            return 0;
        }

        public Customer Register(string email, string name, string phoneNumber, string password, string address)
        {
            int id = customerDB.Count + 1;
            decimal wallet = 0;
            string role = "Customer";
            bool isDeleted = false;
            Customer customer =  new Customer(id, name, email,password, address, wallet,  role,phoneNumber, isDeleted);
            customerDB.Add(customer);
            AddCustomerToFile(customer);
            return customer;
        }

        public Customer Update(int id, string name, string phoneNumber, string address)
        {
            var customer = CheckIfExist(id);
            if(customer != null)
            {
                customer.Id = id;
                customer.Name = name;
                customer.PhoneNumber = phoneNumber;
                customer.Address = address;
                return customer;


            }
            Console.WriteLine($"{customer.Name} does not exist...Sign Up");
            return null;
        }

        

        

        public Customer Get(int id)
        {
        foreach(var customer in customerDB)
        {
            if(customer.Id == id)
            {
                return customer;
            }
        }
        return null;
        }

        public Customer Update(string email, string name, string phoneNumber, string password, string address)
        {
            var customer = CheckIfExist(email);
            {
                if(customer != null)
                {
                    customer.Email = email;
                    customer.Name = name;
                    customer.PhoneNumber = phoneNumber;
                    customer.Password = password;
                    customer. Address = address;
                    return customer;
                }
                return null;

            }
        }


        private Customer CheckIfExist(string email)
        {
            foreach(var customer in customerDB)
            {
                if(customer.Email == email)
                {
                    return customer;
                }
            }
            return null;
        }
        private Customer CheckIfExist(int id)
        {
            foreach(var customer in customerDB)
            {
                if(customer.Id == id)
                {
                    return customer;
                }
            }
            return null;
        }
    }
}