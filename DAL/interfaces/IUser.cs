using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUser
    {
        List<User> GetList();

        User GetUser(string name);

        void AddUser(User user);

        void DeleteUser(string userName);

        void UpdateUser(User user);

        User Auth(User user);

        void LoadUsers(List<User> users);
    }
}
