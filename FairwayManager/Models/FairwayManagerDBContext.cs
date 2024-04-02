using Microsoft.EntityFrameworkCore;

namespace FairwayManager.Models
{
    public class FairwayManagerDBContext : DbContext
    {
        public FairwayManagerDBContext(DbContextOptions<FairwayManagerDBContext> options)
            : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Booking> Bookings { get; set; }

    }
}
