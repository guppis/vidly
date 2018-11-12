using System.Collections.Generic;
using vidly1.Models;

namespace vidly1.ViewModels
{
  public class CustomersDetailsViewModel
  {
    public Customer Customer;
    public List<Customer> Customers { get; set; }
  }
}