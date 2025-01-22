using StudentAPI.Models;
using Microsoft.EntityFrameworkCore;
using StudentAPI.DTOs;

namespace StudentAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        
    }
}
