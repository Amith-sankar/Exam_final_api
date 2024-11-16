using DemoApp.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { 
        
        } 

        public DbSet<DemoTable1> Demo_Table_Login { get; set; }
        public DbSet<Student> students { get; set; }


    }
}
