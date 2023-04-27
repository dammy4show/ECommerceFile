using System.Collections.Generic;
using System.IO;
using ECommerce_File.Managers.Interface;
using ECommerce_File.Models.Entities;

namespace ECommerce_File.Managers.Implementation
{
    public class ProductManager : IProductManager
    {

        List<Product> productDB = new List<Product>();
            string file = @"C:\Users\user\Desktop\ECommerceAppFile\Files\customer.txt";

        private  void ReadCustomerToFile()
        {
            if(File.Exists(file))
            {
                var products = File.ReadAllLines(file);
                foreach(var customer in products)
                {
                    productDB.Add(Customer.ToProduct(product));
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
        public Product Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Product Get(string productName)
        {
            throw new System.NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Product GetByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public Product Register(string productName, decimal price, int quantity)
        {
            throw new System.NotImplementedException();
        }

        public Product Update(int id, string productName, int quantity, decimal price)
        {
            throw new System.NotImplementedException();
        }
    }
}