using System;
using System.Text;
using System.Collections.Generic;

namespace ECommerce_File.Models.Entities
{
    public class Order 
    {
        public int Id;
        public string Email;
        public Dictionary<string, int> Cart;
        public bool IsDeleted;

        public Order(int id, string email, Dictionary<string, int> cart, bool isDeleted) 
        {
            Id = id;
            Email = email;
            Cart = cart;
            IsDeleted = isDeleted;
        }

        public static Order ToOrder(string model)
        {
            var use = model.Split('\t');
            int id = int.Parse(use[0]);
            string email = use[1];
            bool isDeleted = bool.Parse(use[3]);


            var reuse = use[2].Split(',');
            Dictionary<string, int> cart = new Dictionary<string, int>();
            for(int i =0 ; i< reuse.Length-1 ; i++)
            {
                var anduse = reuse[i].Split(':');
                cart.Add(anduse[0], int.Parse(anduse[1]));
            }

            return new Order(id, email, cart, isDeleted);
        }

        public override string ToString()
        {

            StringBuilder str = new StringBuilder();
            {
                foreach( var item in Cart)
                {
                    str.Append($"{item.Key}: {item.Value}");
                }
            }
            return $"{Id}\t{Email}\t{Cart}\t{IsDeleted}";
        }
        
    }
}