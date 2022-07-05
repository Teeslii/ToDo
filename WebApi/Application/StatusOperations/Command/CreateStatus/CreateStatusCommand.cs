using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.StatusOperations.Command.CreateStatus
{
    public class CreateStatusCommand
    {
        public CreateStatusViewModel CreateModel { get; set; }
        private readonly IToDoDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateStatusCommand(IToDoDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var status = _dbContext.Statuses.SingleOrDefault(command => command.Name == CreateModel.Name);

            if(status is not null)
            {
                throw new InvalidOperationException("This status has already been added.");
            }
 
            status = new Status();
            status.Name = CreateModel.Name;


            _dbContext.Statuses.Add(status);
            _dbContext.SaveChanges();
        }
    }

    public class CreateStatusViewModel
    {
        public string? Name { get; set; }
    }
}