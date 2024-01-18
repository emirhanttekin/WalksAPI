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
            var writerRoleId = "3d2e64e6-759c-4163-9e98-ee58bfeb0235";
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
                  Id = writerRoleId,
                  ConcurrencyStamp = writerRoleId,
                  Name = "Writer",
                  NormalizedName = "Writer".ToUpper()
              }

            };
            builder.Entity<IdentityRole>().HasData(roles);
          

        }
    }
}
