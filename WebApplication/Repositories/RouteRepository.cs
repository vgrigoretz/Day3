using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.Repositories
{
	public class RouteRepository
	{
		private static ConcurrentBag<Route> routeList = new ConcurrentBag<Route>()
		{
			new Route(1, "Chisinau", "Nisporeni", 70, "Volvo"),
			new Route(2, "Chisinau", "Orhei", 120, "Renault")
		};

		public List<Route> GetRouteList()
		{
			return routeList.ToList();
		}

		public Route GetRoute(int id)
		{
			return routeList.Where(p => p.Id == id).FirstOrDefault();
		}

		public void InsertRoute(Route route)
		{
			route.Id = routeList.Max(p => p.Id) + 1;
			routeList.Add(route);
		}

		public void UpdateRoute(Route route)
		{
			var storedRoute = GetRoute(route.Id);
			storedRoute.StartPoint = route.StartPoint;
			storedRoute.DestinationPoint = route.DestinationPoint;
			storedRoute.Distance = route.Distance;
			storedRoute.Vehicle = route.Vehicle;
		}

		public void Remove(int id)
		{
			routeList = new ConcurrentBag<Route>(routeList.Where(p => p.Id != id));
		}
	}
}