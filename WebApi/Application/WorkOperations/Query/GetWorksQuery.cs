using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.WorkOperations.Queries.GetWorks
{
    public class GetWorksQuery
    {

        private readonly IToDoDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetWorksQuery(IToDoDbContext dbContext,  IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public List<WorksViewModel> Handle()
        {
            var works = _dbContext.Works.Include(x => x.Status).OrderBy(w => w.Id).Where(w => w.IsComplete == false);
            List<WorksViewModel> returnObj = _mapper.Map<List<WorksViewModel>>(works);
            return returnObj;
        }
        
    }

    public class WorksViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; } 
        public string? Content { get; set; }   
        public string Status { get; set; } 
        public bool  IsComplete { get; set; }
    }
}