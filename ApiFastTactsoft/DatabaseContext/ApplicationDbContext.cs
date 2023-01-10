using ApiFastTactsoft.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiFastTactsoft.DatabaseContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }

        //add-migration CreateStudentTable -o Data/Migrations
        public DbSet<Student> students { get; set; }
         public DbSet<Customer> customer { get; set; }
    }
}
