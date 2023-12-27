using Microsoft.EntityFrameworkCore;
using WalksAPI.Models.Domain;

namespace WalksAPI.Data
{
    public class TrWalksDbContext : DbContext
    {
        public TrWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {
                        
        }
        public DbSet<Difficulty> Difficulties { get; set; }

    }
}
