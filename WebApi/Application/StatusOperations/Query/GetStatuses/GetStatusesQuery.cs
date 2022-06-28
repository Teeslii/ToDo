using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.StatusOperations.Query.GetStatuses
{
    public class GetStatusesQuery
    {

        private readonly IToDoDbContext _context;
        private readonly IMapper _mapper;
        public GetStatusesQuery(IToDoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<StatusesViewModel> Handle()
        {
            var statuses = _context.Statuses.OrderBy(query => query.Id);

            var objViewModel = _mapper.Map<List<StatusesViewModel>>(statuses);

            return objViewModel;
        }
    }

    public class StatusesViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}