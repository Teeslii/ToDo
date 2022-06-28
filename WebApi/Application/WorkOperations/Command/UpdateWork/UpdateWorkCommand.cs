using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;

namespace WebApi.Application.WorkOperations.Command.UpdateWork
{
    public class UpdateWorkCommand
    {
        public int WorkId { get; set; } 
        public UpdateWorkViewModel Model { get; set; }
        private readonly IToDoDbContext _context;
        
        public UpdateWorkCommand(IToDoDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var work = _context.Works.SingleOrDefault(x => x.Id == WorkId);

            if(work is null)
                  throw new InvalidOperationException("No work record found to update.");

            work.Title = Model.Title == default ? work.Title : Model.Title;
            work.Content = Model.Content == default ? work.Content : Model.Content;
            work.StatusId = Model.StatusId == default ? work.StatusId : Model.StatusId;
            work.IsComplete = Model.IsComplete == default ? work.IsComplete : Model.IsComplete;

            _context.SaveChanges(); 
        }
    }

    public class UpdateWorkViewModel
    {
         public string? Title { get; set; } 
         public string? Content { get; set; }   
         public int StatusId { get; set; } 
         public  bool  IsComplete { get; set; } 
    }
}