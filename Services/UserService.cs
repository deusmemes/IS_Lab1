using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class UserService : IUser
    {
        private readonly Data _data;

        public UserService()
        {
            _data = Data.GetInstance();
        }

        public void AddUser(User user)
        {
            user.Password = HashService.Md4Hash(user.Password);
            if (_data.Users.FirstOrDefault(u => u.Name == user.Name) != null) throw new Exception("Пользователь с таким именем уже существует");

            if (user.Type == UserEnum.ADMIN) throw new Exception("Невозможно добавить пользователя с такими привилегиями");

            _data.Users.Add(user);
        }

        public void DeleteUser(string userName)
        {
            var user = _data.Users.FirstOrDefault(u => u.Name == userName);
            if (user != null)
            {
                _data.Users.Remove(user);
            }
        }

        public List<User> GetList()
        {
            return _data.Users;
        }

        public User GetUser(string name)
        {
            return _data.Users.FirstOrDefault(u => u.Name == name);
        }

        public void UpdateUser(User user)
        {
            var old = _data.Users.FirstOrDefault(u => u.Name == user.Name);

            if (old == null) throw new Exception("Пользователь не найден");

            old.Password = user.Password;
            old.IsBlocked = user.IsBlocked;
            old.PasswordRestriction = user.PasswordRestriction;
        }

        public User Auth(User user)
        {
            var res = _data.Users.FirstOrDefault(u => u.Name == user.Name);

            if (res == null)
            {
                throw new Exception("Пользователь не найден");
            }

            if (res.Password != user.Password)
            {
                throw new Exception("Неправильный пароль");
            }

            if (res.IsBlocked)
            {
                throw new Exception("Пользователь заблокирован администратором");
            }

            _data.CurrentUser = res;
            return res;
        }

        public void UpdatePassword(string name, string password)
        {
            var user = GetUser(name);
            if (user == null) throw new Exception("Пользователь не найден");
            user.Password = HashService.Md4Hash(password);
        }

        public void LoadUsers(List<User> users)
        {
            _data.Users.Clear();
            _data.Users.AddRange(users);
        }
    }
}
