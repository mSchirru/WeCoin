using API.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.AutoMapper
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<ApplicationUser, UserListDTO>();
        }

        public override string ProfileName
        {
            get { return "DomainToDTOMappings"; }
        }
    }

}