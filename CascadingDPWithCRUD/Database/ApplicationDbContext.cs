using Microsoft.EntityFrameworkCore;

namespace CascadingDPWithCRUD.Database
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

    }
}
