using Microsoft.EntityFrameworkCore;

namespace First_ASP_Dot_Net_Project.Data
{
    public class ApplicationDbContext:DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
    }
}
