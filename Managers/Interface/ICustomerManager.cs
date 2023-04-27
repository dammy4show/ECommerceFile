using System.Collections.Generic;
using ECommerce_File.Models.Entities;

namespace ECommerce_File.Managers.Interface
{
    public interface ICustomerManager
    {
        public Customer Register(string email, string name, string phoneNumber, string password, string address);
        public Customer Get(string email);
        public Customer Get(int id);
        public List<Customer> GetAll();
        public Customer Update(string email,  string name, string phoneNumber,string password, string address);
        public void Delete(string email);
        public Customer Login(string email, string password);
        public void FundWallet( string email, decimal amount);
        public decimal MakePayment(decimal amount,string email);
    }
}