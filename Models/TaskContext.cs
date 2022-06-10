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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(cat => 
            {
                cat.ToTable("Category");
                cat.HasKey(p => p.CategoryId);

                cat.Property(p => p.Name).IsRequired().HasMaxLength(150);
                cat.Property(p => p.Description);
            });

            modelBuilder.Entity<Task>(task =>
            {
                task.ToTable("Task");
                task.HasKey(p => p.TaskId);
                task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);

                task.Property(p => p.Title).IsRequired().HasMaxLength(150);
                task.Property(p => p.Description);
                task.Property(p => p.PriorityTask);
                task.Property(p => p.CreationDate);

            });
        }

    }
}