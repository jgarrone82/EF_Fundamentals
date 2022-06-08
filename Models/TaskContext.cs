using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EF_Fundamentals.Models
{
    public class TaskContext : DbContext
    {
        public DbSet<Category> categories { get; set; }

        public DbSet<Task> tasks { get; set; }

        public TaskContext(DbContextOptions<TaskContext> options): base(options)
        {
            
        }

    }
}