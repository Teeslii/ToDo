using WebApi.DBOperations;

namespace WebApi.Application.StatusOperations.Command.DeleteStatus
{
    public class DeleteStatusCommand
    {
         public int StatusId { get; set; }
         private readonly IToDoDbContext _dbContext;

         public DeleteStatusCommand(IToDoDbContext dbContext)
         {
            _dbContext = dbContext;
         }

         public void Handle()
         {
            var status = _dbContext.Statuses.SingleOrDefault( command => command.Id == StatusId);

            if(status is null)
            {
                 throw new InvalidDataException("The type of status you tried to delete could not be found.");
            }
            
            _dbContext.Statuses.Remove(status);
            _dbContext.SaveChanges();

         }
    }
}