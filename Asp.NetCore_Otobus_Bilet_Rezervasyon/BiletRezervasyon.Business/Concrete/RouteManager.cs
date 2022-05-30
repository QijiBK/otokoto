using BiletRezervasyon.Business.Abstract;
using BiletRezervasyon.Data.Abstract;
using BiletRezervasyon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletRezervasyon.Business.Concrete
{
    public class RouteManager : IRouteService
    {
        private IRouteRepository _routeRepository;
        public RouteManager(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public void Create(Route entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Route entity)
        {
            throw new NotImplementedException();
        }

        public List<Route> FindRoute(string startCity, string endCity, DateTime routeDate)
        {
            return _routeRepository.FindRoute(startCity, endCity, routeDate);
        }

        public List<Route> GetAll()
        {
            throw new NotImplementedException();
        }
        public int GetSeatCapacityFromBus(int routeId)
        {
            return _routeRepository.GetSeatCapacityFromBus(routeId);
        }

        public Route GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Route GetRouteDetails(int id)
        {
            return _routeRepository.GetRouteDetails(id);
        }

        public void Update(Route entity)
        {
            throw new NotImplementedException();
        }
    }
}
