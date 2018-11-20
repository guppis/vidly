using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using vidly1.DTOs;
using vidly1.Models;

namespace vidly1.App_Start
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      Mapper.Initialize(cfg => cfg.CreateMap<Customer,CustomerDTO>());
    }
  }
} 