using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Repositories;

namespace WebApplication.Controllers
{
    public class TruckController : Controller
    {
        public TruckRepository truckRepository = new TruckRepository();
        // GET: Truck
        public ActionResult Index()
        {
            var truckList = truckRepository.GetTruckList();
            return View(truckList);
        }

        // GET: Truck/Details/5
        public ActionResult Details(int id)
        {
            var truck = truckRepository.GetTruck(id);
            return View(truck);
        }

        // GET: Truck/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Truck/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]Truck truck)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    truckRepository.InsertTruck(truck);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(truck);
                }
            }
            catch
            {
                return View(truck);
            }

        }

        // GET: Truck/Edit/5
        public ActionResult Edit(int id)
        {
            var truck = truckRepository.GetTruck(id);
            return View(truck);
        }

        // POST: Truck/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Truck truck)
        {
            try
            {
                truckRepository.UpdateTruck(truck);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Truck/Delete/5
        public ActionResult Delete(int id)
        {
            var truck = truckRepository.GetTruck(id);
            return View(truck);
        }

        // POST: Truck/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                truckRepository.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
