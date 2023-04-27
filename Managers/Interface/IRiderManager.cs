using System.Collections.Generic;
using ECommerce_File.Models.Entities;

namespace ECommerce_File.Managers.Interface
{
    public interface IRiderManager
    {
         public Rider Register(string name, string phoneNumber, string password, string email,string address);
         public Rider Get(int id);
         public Rider Get(string email);
         public List<Rider> GetAll();
         public Rider Update(int id, string name, string address);
         public void Delete(int id);
         public Rider Login(string email, string password);
    }
}