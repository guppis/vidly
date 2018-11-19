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
      var viewModel = new CustomerFormViewModel
      {
        Customer = new Customer(),
        MembershipTypes = memberShipTypes
      };
      return View("CustomerForm",viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Save(Customer customer)
    {
      if (!ModelState.IsValid)
      {
        var viewModel = new CustomerFormViewModel
        {
          Customer = customer,
          MembershipTypes = _context.MembershipTypes.ToList()
        };
        return View("CustomerForm", viewModel);
      }

      if (customer.Id == 0 ) _context.Customers.Add(customer);
      else
      {
        var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
        customerInDb.Name = customer.Name;
        customerInDb.BirthDate = customer.BirthDate;
        customerInDb.MembershipTypeId = customer.MembershipTypeId;
        customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
      }
      _context.SaveChanges();
      return RedirectToAction("Index", "Customers");
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

    public ActionResult Edit(int id)
    {
      var customer = _context.Customers.SingleOrDefault(i => i.Id == id);

      if (customer == null) return HttpNotFound();

      var viewModel = new CustomerFormViewModel
      {
        Customer = customer,
        MembershipTypes = _context.MembershipTypes.ToList()
      };

      return View("CustomerForm", viewModel);
    }
  }
}