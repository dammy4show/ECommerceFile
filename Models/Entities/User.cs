namespace ECommerce_File.Models.Entities
{
    public class User
    {
        public int Id;
        public string Name;
        public string Email;
        public string Password;
        public string Address;
        public decimal Wallet;
        public string Role;
        public string PhoneNumber;
        
        public bool IsDeleted;

        public User(int id,string name, string email, string password, string address, decimal wallet, string role, string phoneNumber, bool isDeleted)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Address = address;
            Wallet = wallet;
            Role = role;
            PhoneNumber = phoneNumber;
            IsDeleted = isDeleted;
        }

        public static User ToUser(string sample)
        {
            var use = sample.Split('\t');
            int id = int.Parse(use[0]);
            string name = use[1];
            string email = use[2];
            string password = use[3];
            string address = use[4];
            decimal wallet = decimal.Parse(use[5]);
            string role = use[6];
            string phoneNumber = use[7];
            bool isDeleted = bool.Parse(use[8]);

            return new User(id, name, email,password,address, wallet, role, phoneNumber, isDeleted);
        }

        public override string ToString()
        {
            return $"{Id}\t{Name}\t{Email}\t{Password}\t{Address}\t{Wallet}\t{Role}\t{PhoneNumber}\t{IsDeleted}";
        }
    }
}