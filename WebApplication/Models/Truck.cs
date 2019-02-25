using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Truck
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int YearOfProduction { get; set; }
        public int Distance { get; set; }
        public int Capacity { get; set; }

        public Truck()
        {
        }

        public Truck(int id, string model, int yearOfProduction, int distance, int capacity)
        {
            Id = id;
            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException($"Invalid Truck Model introduced {model}");
            if (yearOfProduction <= 0)
                throw new ArgumentException();
            if (distance <= 0)
                throw new ArgumentException();

            Model = model;
            YearOfProduction = yearOfProduction;
            Distance = distance;
            Capacity = capacity;
        }

        public override string ToString()
        {
            return Model + " " + YearOfProduction + " " + Distance;
        }
    }
}