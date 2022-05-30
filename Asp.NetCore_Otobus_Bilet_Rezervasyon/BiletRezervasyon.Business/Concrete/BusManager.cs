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
    public class BusManager : IBusService
    {
        private IBusRepository _busRepository;
        public BusManager(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        //public int BusSeatCapacityOnRoute(int routeId)
        //{
        //   return _busRepository.BusSeatCapacityOnRoute(routeId);
        //}

        public void Create(Bus entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Bus entity)
        {
            throw new NotImplementedException();
        }

        public List<Bus> GetAll()
        {
            throw new NotImplementedException();
        }

        public Bus GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Bus entity)
        {
            throw new NotImplementedException();
        }
    }
}
