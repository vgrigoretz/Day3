using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.Repositories
{
    public class TruckRepository
    {
        private static ConcurrentBag<Truck> truckList = new ConcurrentBag<Truck>()
        {
            new Truck(1,"Renault", 2000, 500_000, 20),
            new Truck(2,"Volvo", 2010, 250_000, 20)
        };

        public List<Truck> GetTruckList()
        {
            return truckList.ToList();
        }

        public Truck GetTruck(int id)
        {
            return truckList.Where(p => p.Id == id).FirstOrDefault();
        }

        public void InsertTruck(Truck truck)
        {
            truck.Id = truckList.Max(p => p.Id) + 1;
            truckList.Add(truck);
        }

        public void UpdateTruck(Truck truck)
        {
            var storedTruck = GetTruck(truck.Id);
            storedTruck.Model = truck.Model;
            storedTruck.YearOfProduction = truck.YearOfProduction;
            storedTruck.Distance = truck.Distance;
            storedTruck.Capacity = truck.Capacity;
        }

        public void Remove(int id)
        {
            truckList = new ConcurrentBag<Truck>(truckList.Where(p => p.Id != id));
        }
    }
}