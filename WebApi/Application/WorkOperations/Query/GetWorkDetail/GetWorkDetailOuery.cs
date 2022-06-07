using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.WorkOperations.Query.GetWorkDetail
{
    public class GetWorkDetailQuery
    {
        public string WorkTitle{ get; set;}
        private readonly IToDoDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetWorkDetailQuery(IToDoDbContext dbContext,  IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<WorkDetailViewModel> Handle()
        {
           // var work = _dbContext.Works.SingleOrDefault(x => x.Id == WorkId && x.IsComplete == false);
            var work = _dbContext.Works.Include(x => x.Status).OrderBy(w => w.Id).Where(x => x.Title.Contains(WorkTitle));

            if(work.Count() == 0)
            {
                throw new InvalidOperationException("The searched task was not found.");
            }

            var returnObj = _mapper.Map<List<WorkDetailViewModel>>(work);
            return returnObj;
        }
    }
     public class WorkDetailViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; } 
        public string? Content { get; set; }   
        public string Status { get; set; } 
    }
}