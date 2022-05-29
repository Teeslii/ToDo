using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class ToDoDbContext : DbContext, IToDoDbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base (options) { }
        public DbSet<Work> Works { get; set; }
        public DbSet<Status> Statuses { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}