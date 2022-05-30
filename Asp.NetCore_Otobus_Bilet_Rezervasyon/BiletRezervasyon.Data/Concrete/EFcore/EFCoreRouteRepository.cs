using BiletRezervasyon.Data.Abstract;
using BiletRezervasyon.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletRezervasyon.Data.Concrete.EFcore
{
    public class EFCoreRouteRepository : EFCoreGenericRepository<Route, BookingContext>, IRouteRepository
    {
       
        public List<Route> FindRoute(string startCity, string endCity, DateTime routeDate)
        {
            startCity = startCity.ToLower();
            endCity = endCity.ToLower();
            string fakeRouteDate = routeDate.ToString("dd.MM.yyyy");
            using (var context = new BookingContext())
            {
                var routes = context.Routes.Where(i => i.Date.Contains(fakeRouteDate) && (i.FirstTerminal.ToLower().Contains(startCity) &&
                ((i.Terminal1.ToLower().Contains(endCity) ||
                i.Terminal2.ToLower().Contains(endCity) || i.Terminal3.ToLower().Contains(endCity) ||
                i.Terminal4.ToLower().Contains(endCity) || i.Terminal5.ToLower().Contains(endCity) ||
                i.Terminal5.ToLower().Contains(endCity) || i.LastTerminal.ToLower().Contains(endCity))) ||

                i.Terminal1.ToLower().Contains(startCity) && ((i.Terminal2.ToLower().Contains(endCity) ||
                i.Terminal3.ToLower().Contains(endCity) || i.Terminal4.ToLower().Contains(endCity) ||
                i.Terminal5.ToLower().Contains(endCity) || i.LastTerminal.ToLower().Contains(endCity))) ||

                i.Terminal2.ToLower().Contains(startCity) && ((i.Terminal3.ToLower().Contains(endCity) ||
                i.Terminal4.ToLower().Contains(endCity) || i.Terminal5.ToLower().Contains(endCity) ||
                i.LastTerminal.ToLower().Contains(endCity))) ||

                i.Terminal3.ToLower().Contains(startCity) && ((i.Terminal4.ToLower().Contains(endCity) ||
                i.Terminal5.ToLower().Contains(endCity) || i.LastTerminal.ToLower().Contains(endCity))) ||  
                
                i.Terminal4.ToLower().Contains(startCity) && ((i.Terminal5.ToLower().Contains(endCity) ||
                i.LastTerminal.ToLower().Contains(endCity))) ||

                i.Terminal5.ToLower().Contains(startCity) && (i.LastTerminal.ToLower().Contains((endCity)))))
                    .Include(c=>c.Bus)
                    .ToList();


                return routes;

            }
        }
        public int GetSeatCapacityFromBus(int routeId)
        {
            using (var context = new BookingContext())
            {
                return context.Routes.Where(i => i.RouteId == routeId).Select(i => i.Bus.BusSeatCapacity).FirstOrDefault();
            }
        }
        public Route GetRouteDetails(int id)
        {
            using (var context = new BookingContext())
            {
                return context.Routes.Where(i => i.RouteId == id).AsNoTracking().FirstOrDefault();
            }
        }
    }
}
