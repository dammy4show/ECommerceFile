using System.Collections.Generic;
using System.Text;

namespace ECommerce_File.Models.Entities
{
    public class Product 
    {
        public int Id;
        Dictionary<string, Dictionary<int, decimal>> Goods;
        public bool IsDeleted;
        

        public Product(int id,  Dictionary<string, Dictionary<int, decimal>> goods, bool isDeleted)
        {
            Id = id;
            Goods = goods;
            IsDeleted = isDeleted;
        }

        public static  Product ToProduct(string model)
        {
            var use = model.Split('\t');
            int id = int.Parse(use[0]);
            bool isDeleted = bool.Parse(use[2]);


            Dictionary<string, Dictionary<int, decimal>> goods = new Dictionary<string, Dictionary<int, decimal>>();
            var reuse = use[1].Split('>');
            for(int i =0; i < reuse.Length-1; i++)
            {
                Dictionary<int, decimal> s = new Dictionary<int, decimal>();
                var asd = reuse[i].Split(':');
                var abc = asd[1].Split(',');
                for(int j = 0; j < abc.Length; i++)
                {
                    var d = abc[j].Split('-');
                    s.Add(int.Parse(d[0]), decimal.Parse(d[1]));
                }
                goods.Add(asd[0], s);
                
            }
            return new Product(id, goods, isDeleted);


 
        }
        public override string ToString()
        {
            StringBuilder abc = new StringBuilder();
            foreach(var item in Goods)
            {
                abc.Append($"{item.Key}>");
                foreach( var itm in item.Value)
                {
                    abc.Append($"{item.Key} : {item.Value}, ");
                }
                abc.Append('|');
            }

            return $"{Id}\t{abc}\t{IsDeleted}";
        }
    }
}