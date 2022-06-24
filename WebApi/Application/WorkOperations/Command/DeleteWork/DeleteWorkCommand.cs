using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;

namespace WebApi.Application.WorkOperations.Command.DeleteWork
{
    public class DeleteWorkCommand
    {
       public int WorkId { get; set;}

       private readonly IToDoDbContext _context;
       
       public DeleteWorkCommand(IToDoDbContext context)
       {
         _context = context;
       }
       public void Handle()
       {
         var work = _context.Works.SingleOrDefault(x => x.Id == WorkId);

         if(work is null)
                 throw new InvalidOperationException("The work record to be deleted was not found.");
         
         _context.Works.Remove(work);
         _context.SaveChanges();
       }
    }
}