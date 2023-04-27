using System.Collections.Generic;
using ECommerce_File.Models.Entities;

namespace ECommerce_File.Managers.Interface
{
    public interface IProductManager
    {
        public Product Register( );
        public Product Get(string productName);
        public Product GetByID(int id);
        public List<Product> GetAll();
        public Product Update(int id, string productName, int quantity, decimal price);
        public Product Delete(int id);
        
    }
}