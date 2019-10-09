using Microsoft.EntityFrameworkCore;
using Softline.Model.Entity;

namespace Softline.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Request> Requests { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }
    }
}
