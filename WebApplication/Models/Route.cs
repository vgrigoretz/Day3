using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Route
    {
        public int Id { get; set; }
        public string StartPoint { get; set; }
        public string DestinationPoint { get; set; }
        public int Distance { get; set; }
        public string Vehicle { get; set; }

        public Route()
        {
	    }
	
        public Route(int id, string startPoint, string destinationPoint, int distance, string vehicle)
        {
            Id = id;
            if (string.IsNullOrWhiteSpace(startPoint))
                throw new ArgumentException($"Invalid Start Point introduced {startPoint}");
            if (string.IsNullOrWhiteSpace(destinationPoint))
				throw new ArgumentException($"Invalid Destination Point introduced {destinationPoint}");
			if (distance <= 0)
                throw new ArgumentException();

            StartPoint = startPoint;
            DestinationPoint = destinationPoint;
            Distance = distance;
            Vehicle = vehicle;
        }

        public override string ToString()
        {
            return StartPoint + " " + DestinationPoint + " " + Distance + " " + Vehicle;
        }
    }
}