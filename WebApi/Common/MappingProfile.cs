using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.Application.WorkOperations.Queries.GetWorks;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
              CreateMap<Work, WorksViewModel>().ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Name.ToString()));
        }
    }
}