using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly1.Models;

namespace vidly1.ViewModels
{
  public class NewCustomerViewModel
  {
    public IEnumerable<MembershipType> MembershipTypes { get; set; }
    public Customer Customer { get; set; }
  }
}