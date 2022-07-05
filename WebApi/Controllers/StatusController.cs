using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Application.StatusOperations.Command.CreateStatus;
using WebApi.Application.StatusOperations.Query.GetStatuses;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IToDoDbContext _context;
        private readonly IMapper _mapper;

        public StatusController(IToDoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetStatuses()
        {
            GetStatusesQuery query = new GetStatusesQuery(_context, _mapper);
        
            var result = query.Handle();

            return Ok(result);
        }
        
        [HttpPost]
        public IActionResult CreateStatus([FromBody] CreateStatusViewModel createModel)
        {
            CreateStatusCommand command = new CreateStatusCommand(_context, _mapper);
            command.CreateModel = createModel;

            CreateStatusCommandValidator validator = new CreateStatusCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }
       
    }
}