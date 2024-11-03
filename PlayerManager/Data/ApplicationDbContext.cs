using Microsoft.EntityFrameworkCore;
using PlayerManager.Models.Entities;

namespace PlayerManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Player> players { get; set; }
    }
}
