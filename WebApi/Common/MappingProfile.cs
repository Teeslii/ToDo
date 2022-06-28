using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.Application.StatusOperations.Query.GetStatuses;
using WebApi.Application.WorkOperations.Command.CreateWork;
using WebApi.Application.WorkOperations.Queries.GetWorks;
using WebApi.Application.WorkOperations.Query.GetWorkDetail;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
              CreateMap<Work, WorksViewModel>().ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Name.ToString()));

              CreateMap<Work, WorkDetailViewModel>().ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Name.ToString()));

              CreateMap<CreateWorkViewModel, Work>();
              
              CreateMap<Status, StatusesViewModel>();
        }
    }
}