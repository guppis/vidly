﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly1.Models
{
  public class Customer
  {
    public int Id { get; set; }

    [Required] [StringLength(255)] public string Name { get; set; }
    [Display(Name="Date of Birth")]
    public DateTime? BirthDate { get; set; }

    public bool IsSubscribedToNewsletter { get; set; }

    public MembershipType MembershipType { get; set; }

    public string MembershipName { get; set; }

    [Display(Name = "Membership type")]
    public byte MembershipTypeId { get; set; }
  }
}