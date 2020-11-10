using Models;
using System.Collections.Generic;

namespace Services
{
    public class Data
    {
        private static Data instance;

        public List<User> Users { get; set; }

        public User CurrentUser { get; set; }

        private Data()
        {
            Users = new List<User>();
        }

        public static Data GetInstance()
        {
            return instance ??= new Data();
        }
    }
}
