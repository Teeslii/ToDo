using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class Work
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Title { get; set; } 
        public string? Content { get; set; }   
        public int StatusId { get; set; } 
        public Status Status { get; set; } 
        public bool  IsComplete { get; set; }  = false;
    }
}