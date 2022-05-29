using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public interface IToDoDbContext
    {
         DbSet<Work> Works { get; set; }    
         DbSet<Status> Statuses { get; set; } 

         int SaveChanges();
    }
}