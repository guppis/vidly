using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using vidly1.Models;

namespace vidly1.DTOs
{
  public class CustomerDTO
  {
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }

//    [Min18YearsIfMember]
    public DateTime? BirthDate { get; set; }

    public bool IsSubscribedToNewsletter { get; set; }

    public string MembershipName { get; set; }

    public byte MembershipTypeId { get; set; }
  }
}
