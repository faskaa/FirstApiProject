using FirstApp_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstApp_API.DAL
{
    public class AcademyDBContext : DbContext
    {
        public AcademyDBContext(DbContextOptions<AcademyDBContext> options):base(options)
        {
            
        }


        public DbSet<Group> Groups { get; set; }
    }
}
