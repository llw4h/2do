using Microsoft.EntityFrameworkCore;

namespace ToDo.Models.EF
{
    public class TodolistDbContext : DbContext
    {

        public TodolistDbContext(DbContextOptions<TodolistDbContext> options) : base(options)
        { }

        public DbSet<Todolist> Todolists { get; set; }
    }
}