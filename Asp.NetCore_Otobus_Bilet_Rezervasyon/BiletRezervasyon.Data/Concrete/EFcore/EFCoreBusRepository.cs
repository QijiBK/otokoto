using BiletRezervasyon.Data.Abstract;
using BiletRezervasyon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletRezervasyon.Data.Concrete.EFcore
{
    public class EFCoreBusRepository : EFCoreGenericRepository<Bus, BookingContext>, IBusRepository
    {
        //public int BusSeatCapacityOnRoute(int routeId)
        //{
        //    using (var context = new BookingContext())
        //    {
        //        return context.Buses.Where(i=>i.RouteId == routeId).Select(i=>i.BusSeatCapacity).FirstOrDefault();
        //    }
        //}
    }
}
