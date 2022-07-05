using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;

namespace WebApi.Application.StatusOperations.Command.UpdateStatus
{
    public class UpdateStatusCommand
    {
        public UpdateStatusViewModel UpdateModel { get; set;}
        private readonly IToDoDbContext _dbContext;

        public int StatusId { get; set;}
        public UpdateStatusCommand(IToDoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var status = _dbContext.Statuses.SingleOrDefault(command => command.Id == StatusId);

            if(status is null)
            {
                throw new InvalidOperationException("The type of status you are trying to update could not be found.");
            }

            if(_dbContext.Statuses.Any(command => command.Name.ToLower() == UpdateModel.Name.ToLower() && command.Id != StatusId))
            {
                  throw new InvalidOperationException("A status type with the same name already exists.");
            }

            status.Name = !string.IsNullOrEmpty(UpdateModel.Name.Trim()) ? UpdateModel.Name : status.Name;

            _dbContext.SaveChanges();
        }
    }

    public class UpdateStatusViewModel
    {
        public string? Name { get; set;}
    }
}