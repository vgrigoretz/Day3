using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Repositories;

namespace WebApplication.Controllers
{
    public class UserController : Controller
    {
        public UserRepository userRepository = new UserRepository();
        // GET: Truck
        public ActionResult Index()
        {
            var userList = userRepository.GetUserList();
            return View(userList);
        }

        // GET: Truck/Details/5
        public ActionResult Details(int id)
        {
            var user = userRepository.GetUser(id);
            return View(user);
        }

        // GET: Truck/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Truck/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]User user)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    userRepository.InsertUser(user);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(user);
                }
            }
            catch
            {
                return View(user);
            }

        }

        // GET: Truck/Edit/5
        public ActionResult Edit(int id)
        {
            var truck = userRepository.GetUser(id);
            return View(truck);
        }

        // POST: Truck/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                userRepository.UpdateUser(user);
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
            var user = userRepository.GetUser(id);
            return View(user);
        }

        // POST: Truck/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                userRepository.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}