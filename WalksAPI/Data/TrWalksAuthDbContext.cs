using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WalksAPI.Data
{
    public class TrWalksAuthDbContext : IdentityDbContext
    {
        public TrWalksAuthDbContext(DbContextOptions<TrWalksAuthDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var readerRoleId = "a407b6b8-98dd-4ee8-ba2c-ef0b0f7ccf5b";
            var emirRoleId = "9261d1f8-2302-48f5-9ef4-15571fc74b34";
            var roles = new List<IdentityRole>
            {
              new IdentityRole
              {
                Id = readerRoleId,
                ConcurrencyStamp = readerRoleId,
                Name = "Reader",
                NormalizedName = "Reader".ToUpper(),
              },

              new IdentityRole
              {
                  Id = emirRoleId,
                  ConcurrencyStamp = emirRoleId,
                  Name = "Emir",
                  NormalizedName = "Emir".ToUpper()
              }

            };
            builder.Entity<IdentityRole>().HasData(roles);
          

        }
    }
}
