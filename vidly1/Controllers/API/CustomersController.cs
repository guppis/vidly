using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using vidly1.DTOs;
using vidly1.Models;

namespace vidly1.Controllers.API
{
    public class CustomersController : ApiController
    {
      private ApplicationDbContext _context;

      public CustomersController()
      {
        _context = new ApplicationDbContext();
      }

    
      //  GET /api/customers
      public IEnumerable<CustomerDTO> GetCustomers()
      {
        return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>);
      }

      // GET /api/customers/1
      public CustomerDTO GetCustomer(int id)
      {
        var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
        if (customer == null)
          throw new HttpResponseException(HttpStatusCode.NotFound);
        return Mapper.Map<Customer,CustomerDTO>(customer);
      }
      
      // CREATE /api/customers
      [HttpPost]
      public CustomerDTO CreateCustomer(CustomerDTO customerDTO)
      {
        if (!ModelState.IsValid)
          throw new HttpResponseException(HttpStatusCode.BadRequest);

        var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
        _context.Customers.Add(customer);
        _context.SaveChanges();
        customerDTO.Id = customer.Id;
        return customerDTO;
      }

      // UPDATE /api/customers/1
      [HttpPut]
      public void UpdateCustomer(int id, Customer customer)
      {
        if (!ModelState.IsValid)
          throw new HttpResponseException(HttpStatusCode.BadRequest);
        var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

        if (customerInDb == null) throw new HttpResponseException(HttpStatusCode.NotFound);

        customerInDb.Name = customer.Name;
        customerInDb.BirthDate = customer.BirthDate;
        customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
        customerInDb.MembershipTypeId = customer.MembershipTypeId;

        _context.SaveChanges();

       }

      // DELETE /api/customers/1
      [HttpDelete]
      public void DeleteCustomer(int id, Customer customer)
      {
        if (!ModelState.IsValid)
          throw new HttpResponseException(HttpStatusCode.NotFound);
        var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);


      _context.Customers.Remove(customerInDb);
        _context.SaveChanges();
      }
  }
} 
