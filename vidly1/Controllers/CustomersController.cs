using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly1.Models;
using vidly1.ViewModels;

namespace vidly1.Controllers
{
  public class CustomersController : Controller
  {
    private ApplicationDbContext _context;

    public CustomersController()
    {
      _context = new ApplicationDbContext();
    }

    protected override void Dispose(bool disposing)
    {
      _context.Dispose();
    }

    // GET: Customers

    public ActionResult Index()
    {
      var customers = _context.Customers.ToList();
        return View(customers);
    }

    [Route("customers/details/{id:regex(\\d)}")]
    public ActionResult Details(int id)
    {
      var customers = _context.Customers.SingleOrDefault(c => c.Id == id);

      if (customers == null) return HttpNotFound();
      return View(customers);
    }   
}
}