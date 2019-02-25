using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.Repositories
{
    public class UserRepository
    {
        private static ConcurrentBag<User> userList = new ConcurrentBag<User>()
        {
            new User(1,"Popescu", "Ion", "01/03/2006"),
            new User(2,"Grigore", "Ion", "01/03/2006")
        };

        public List<User> GetUserList()
        {
            return userList.ToList();
        }

        public User GetUser(int id)
        {
            return userList.Where(p => p.Id == id).FirstOrDefault();
        }

        public void InsertUser(User user)
        {
            user.Id = userList.Max(p => p.Id) + 1;
            userList.Add(user);
        }

        public void UpdateUser(User user)
        {
            var storedUser = GetUser(user.Id);
            storedUser.Name = user.Name;
            storedUser.Surname = user.Surname;
            storedUser.EmployDate = user.EmployDate;
        }

        public void Remove(int id)
        {
            userList = new ConcurrentBag<User>(userList.Where(p => p.Id != id));
        }
    }
}