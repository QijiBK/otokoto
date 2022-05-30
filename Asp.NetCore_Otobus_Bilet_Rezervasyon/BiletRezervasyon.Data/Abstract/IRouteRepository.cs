using BiletRezervasyon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletRezervasyon.Data.Abstract
{
    public interface IRouteRepository : IRepository<Route>
    {
       List<Route> FindRoute(string startCity, string endCity, DateTime routeDate);
        Route GetRouteDetails(int id);
        int GetSeatCapacityFromBus(int routeId);



    }
}
