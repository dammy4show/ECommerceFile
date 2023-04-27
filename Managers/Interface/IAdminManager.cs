using ECommerce_File.Managers.Implementation;
using ECommerce_File.Models.Entities;

namespace ECommerce_File.Managers.Interface
{
    public interface IAdminManager
    {
        public Admin Update(string email, string name,string phoneNumber,string password, string address );
        public Admin Login(string email, string password);
        
         
    }
}