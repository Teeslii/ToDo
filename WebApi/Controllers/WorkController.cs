using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Application.WorkOperations.Command.CreateWork;
using WebApi.Application.WorkOperations.Command.DeleteWork;
using WebApi.Application.WorkOperations.Command.UpdateWork;
using WebApi.Application.WorkOperations.Queries.GetWorks;
using WebApi.Application.WorkOperations.Query.GetWorkDetail;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkController : ControllerBase
    {
        private readonly IToDoDbContext _dbContext;
        private readonly IMapper _mapper;

        public WorkController(IToDoDbContext dbContext,  IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetWorks()
        {
            GetWorksQuery query = new GetWorksQuery(_dbContext, _mapper);
            var result = query.Handle();
            
            return Ok(result);
        }
        
        [HttpGet("{title}")]
        public IActionResult GetWorkDetail(string title)
        {
            var query = new GetWorkDetailQuery(_dbContext, _mapper);
            query.WorkTitle = title;
            
            GetWorkDetailQueryValidator validator = new GetWorkDetailQueryValidator();
            validator.ValidateAndThrow(query);
            
            var result = query.Handle();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateWork([FromBody] CreateWorkViewModel createModel)
        {
            CreateWorkCommand command = new CreateWorkCommand(_dbContext, _mapper);
            command.CreateModel = createModel;
        
            CreateWorkCommandValidator validator = new CreateWorkCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteWork(int id)
        {
            DeleteWorkCommand command = new DeleteWorkCommand(_dbContext);
            command.WorkId = id;

            DeleteWorkCommandValidator validator = new DeleteWorkCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateWork(int id, [FromBody] UpdateWorkViewModel model)
        {
           UpdateWorkCommand command = new UpdateWorkCommand(_dbContext);
           command.WorkId = id;
           command.Model = model;

           UpdateWorkCommandValidator validator = new UpdateWorkCommandValidator();
           validator.ValidateAndThrow(command);
            
           command.Handle();

           return Ok();
        }
    }
}