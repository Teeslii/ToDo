using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
 using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new ToDoDbContext(serviceProvider.GetRequiredService<DbContextOptions<ToDoDbContext>>()))
            {

                if(context.Works.Any())
                {
                    return;
                }
                context.Works.AddRange(
                   new Work
                   {
                       Title = "Apple Project",
                       Content = "Fake data to be used in the project will be created.",
                       StatusId = 1,
                       IsComplete = false
                   },
                   new Work
                   {
                       Title = "Apple Project part 2",
                       Content = "The listing will be done through the data.",
                       StatusId = 2,
                       IsComplete = false
                   },
                     new Work
                   {
                       Title = "Banana Project part 2",
                       Content = "The listing will be done through the data.",
                       StatusId = 2,
                       IsComplete = false
                   }
                );

                context.Statuses.AddRange(

                    new Status
                    {
                       Name = "very very immediate"
                    },
                    new Status
                    {
                        Name = "very immediate"
                    },
                    new Status
                    {
                        Name = "immediate"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}