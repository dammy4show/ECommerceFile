using System.Collections.Generic;
using ECommerce_File.Models.Entities;

namespace ECommerce_File.Managers.Interface
{
    public interface IOrderManager
    {
         public Order Create(string email, Dictionary<string, int> car);
         public Order Get(int id);
         public Order Update(string email, Dictionary<string, int>cart);
         
         public List<Order> GetAll();
          
          public void Delete(int id);
    }
}