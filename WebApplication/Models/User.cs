using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmployDate { get; set; }

        public User()
        {
        }

        public User(int id, string name, string surname, string employdate)
        {
        
            Id = id;

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"Invalid Name {name}");
            }
            if (string.IsNullOrWhiteSpace(surname))
            {
                throw new ArgumentException($"Invalid Surname {surname}");
            }
            
            Name = name;
            Surname = surname;
            EmployDate = employdate;
        }

        public override string ToString()
        {
            return Name + " " + Surname + " " + EmployDate;
        }
    }
}