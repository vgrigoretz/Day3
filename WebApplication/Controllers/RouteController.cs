using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Repositories;

namespace WebApplication.Controllers
{
	public class RouteController : Controller
	{
		public RouteRepository routeRepository = new RouteRepository();
		// GET: Truck
		public ActionResult Index()
		{
			var routeList = routeRepository.GetRouteList();
			return View(routeList);
		}

		// GET: Truck/Details/5
		public ActionResult Details(int id)
		{
			var route = routeRepository.GetRoute(id);
			return View(route);
		}

		// GET: Truck/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Truck/Create
		[HttpPost]
		public ActionResult Create([Bind(Exclude = "Id")]Route route)
		{
			try
			{
				if (ModelState.IsValid)
				{

					routeRepository.InsertRoute(route);
					return RedirectToAction("Index");
				}
				else
				{
					return View(route);
				}
			}
			catch
			{
				return View(route);
			}

		}

		// GET: Truck/Edit/5
		public ActionResult Edit(int id)
		{
			var truck = routeRepository.GetRoute(id);
			return View(truck);
		}

		// POST: Truck/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, Route route)
		{
			try
			{
				routeRepository.UpdateRoute(route);
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
			var route = routeRepository.GetRoute(id);
			return View(route);
		}

		// POST: Truck/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				routeRepository.Remove(id);
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}