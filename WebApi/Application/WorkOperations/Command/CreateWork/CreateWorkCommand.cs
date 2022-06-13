using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.WorkOperations.Command.CreateWork
{
    public class CreateWorkCommand
    {
        public CreateWorkViewModel CreateModel {get; set;}
        private readonly IToDoDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateWorkCommand(IToDoDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            
            var work = _dbContext.Works.SingleOrDefault(w => w.Title.Replace(" ","") == CreateModel.Title.Replace(" ", ""));
            if(work is not null)
            {
                throw new InvalidOperationException("This work has already been added.");
            }

            work = _mapper.Map<Work>(CreateModel);
            
            _dbContext.Works.Add(work);
            _dbContext.SaveChanges();
                
        }
    }

    public class CreateWorkViewModel
    {
        public string? Title { get; set; } 
        public string? Content { get; set; }   
        public int StatusId { get; set; } 
    }
}