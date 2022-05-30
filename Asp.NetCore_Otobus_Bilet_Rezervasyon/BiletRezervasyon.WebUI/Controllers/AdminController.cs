using BiletRezervasyon.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BiletRezervasyon.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private ITicketService _ticketService;
        private IRouteService _routeService;
        private IBusService _busService;
        public AdminController(IRouteService routeService, ITicketService ticketService, IBusService busService)
        {
            _routeService = routeService;
            _ticketService = ticketService;
            _busService = busService;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAdminTickets()
        {
            return View(_ticketService.GetAll());
        }

        public IActionResult AdminDelete(int ticketId)
        {
            var entity = _ticketService.GetById(ticketId);
            _ticketService.Delete(entity);
            return RedirectToAction("GetAdminTickets");
        }
    }
}
