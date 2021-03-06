using BiletRezervasyon.Business.Abstract;
using BiletRezervasyon.Entities;
using BiletRezervasyon.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace BiletRezervasyon.WebUI.Controllers
{
    public class TicketController : Controller
    {
        private IRouteService _routeService;
        private ITicketService _ticketService;
      
        public TicketController(IRouteService routeService, ITicketService ticketService) 
        {
            _routeService = routeService;
            _ticketService = ticketService;
            
        }
        public IActionResult Index()
        {
             
            return View();
        }
        public IActionResult FindRoute(string startCity, string endCity, DateTime routeDate)
        {

            ViewBag.From = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(startCity);
            ViewBag.toWhere = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(endCity); 

            return View(_routeService.FindRoute(startCity, endCity, routeDate));
        }
        public IActionResult GetTicketsFromRoute(int id, string startCity, string endCity)
        {
            int seatCapacityOnRoute = _routeService.GetSeatCapacityFromBus(id);
            ViewBag.seatCapacity = seatCapacityOnRoute; 
            ViewBag.From = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(startCity);
            ViewBag.toWhere = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(endCity);
            return View(_ticketService.GetTicketsFromRoute(id));      
        }
        public IActionResult GetPassengerInfo(int routeId, int seatNo, int busId, string startCity, string endCity)
        {
            
            Random rnd = new Random();
            int pnr = rnd.Next(100000000, 900000000);
            ViewBag.pnr = pnr;
            ViewBag.fromWhere = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(startCity);
            ViewBag.toWhere = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(endCity);
            ViewBag.busId = busId; 
            ViewBag.routeId = routeId;
            ViewBag.seatNo = seatNo;
            
            return View(); 
        }
        [HttpPost]
        public IActionResult CreateTicket(Ticket ticket)
        {
            _ticketService.Create(ticket);
            return RedirectToAction("Succesfully");
        }

        public IActionResult Succesfully()
        {
            Ticket newTicket = _ticketService.GetLastTicket();
            int routeId = _ticketService.GetTicketId();
            string routeHour = _ticketService.GetHour(routeId);
            string routeDate = _ticketService.GetDate(routeId);
            double routePrice = _ticketService.GetPrice(routeId);

            var routeTicketModel = new RouteTicketModel()
            {
                Date = routeDate,
                Hour = routeHour,
                Price = routePrice,
                Ticket = newTicket
            };
            return View(routeTicketModel);
        }
        public IActionResult Search(string searchString,string searchStringg, int routeId)
        {
            string routeHour = _ticketService.GetHour(routeId);
            string routeDate = _ticketService.GetDate(routeId);
            double routePrice = _ticketService.GetPrice(routeId);
            ViewBag.routeHour = routeHour;
            ViewBag.routeDate = routeDate;
            ViewBag.routePrice = routePrice;
            return View(_ticketService.GetSearchedTicket(searchString, searchStringg));
        }
        public IActionResult TicketDelete(int ticketId)
        {
            var entity = _ticketService.GetById(ticketId);
            _ticketService.Delete(entity);
            return RedirectToAction("Index", "Home");
        }
    }
}
