using System.Collections.Generic;
using ECommerce_File.Models.Entities;

namespace ECommerce_File.Managers.Interface
{
    public interface IUserManager
    {
         public User Register(string name, string phoneNumber, string password, string email,string address);
         public User Get(int id);
         public User Get(string email);
         public List<User> GetAll();
         public User Update(string name, string address, string email, string password, string phoneNumber);
         public void Delete(string email);
         public User Login(string email, string password);
    }
}