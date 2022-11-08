using Microsoft.EntityFrameworkCore;
using NewApi.Models;

namespace NewApi.Data
{
    public class ToDoApiDbContext : DbContext
    {
        public ToDoApiDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ToDo> ToDo { get; set; }
    }
}
