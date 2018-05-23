using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkAndRide_REST.Context;
using ParkAndRide_REST.Models;


namespace ParkAndRide_REST.Controllers
{
    public class EventsController : Controller
    {
        parkandrelaxContext db = new parkandrelaxContext();

        public ViewResult Index()
        {
            return View();
        }

        public IEnumerable<Event> search( string date=null, string category=null)
        {
           

            if (date!=null)
            {
                var filteredEvents = from e in db.Event
                                     where e.Date.Contains(date)
                                     select e;
                return filteredEvents;
            }
            else
            {
                var filteredEvents = from e in db.Event
                                     where e.Category.Contains(category)
                                     select e;
                return filteredEvents;
            }

                       
        }
    }
}