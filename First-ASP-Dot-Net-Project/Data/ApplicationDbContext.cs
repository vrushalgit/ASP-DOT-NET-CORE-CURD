
using Microsoft.EntityFrameworkCore;
using First_ASP_Dot_Net_Project.Models;

namespace First_ASP_Dot_Net_Project.Data
{
    public class ApplicationDbContext:DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        // DbSet is used to create table
        public DbSet<Category> Categories { get; set; }
    }
}
