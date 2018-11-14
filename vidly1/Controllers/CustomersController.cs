using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    private int id;

    public CustomersController()
    {
      _context = new ApplicationDbContext();
    }

    protected override void Dispose(bool disposing)
    {
      _context.Dispose();
    }

    // GET: Customers

    public ActionResult New()
    {
      var memberShipTypes = _context.MembershipTypes.ToList();
      var viewModel = new NewCustomerViewModel
      { 
        MembershipTypes = memberShipTypes
      };
       return View(viewModel);
    }

    public ViewResult Index()
    {
      var customers = _context.Customers.Include(c => c.MembershipType).ToList();

      return View(customers);
    }

    [Route("customers/details/{id:regex(\\d)}")]
    public ActionResult Details(int id)
    {
      var customers = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

      if (customers == null) return HttpNotFound();
      return View(customers);
    }   
}
}