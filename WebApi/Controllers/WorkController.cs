using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
     
    }
}