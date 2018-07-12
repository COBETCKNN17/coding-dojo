using Microsoft.EntityFrameworkCore;
 
namespace Project.Models
{
    public class ProjectContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public YourContext(DbContextOptions<YourContext> options) : base(options) { }
    }
}