using Microsoft.EntityFrameworkCore;

namespace WebAppClase08.EF
{
    public class MiDBContext : DbContext
    {
        public MiDBContext(DbContextOptions<MiDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
