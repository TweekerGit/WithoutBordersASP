using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WithoutBorders.Data.Entities;

namespace WithoutBorders.Data.SqlServer
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> contextOptions) : base(contextOptions) { }
        
        public DbSet<Year> Years { get; set; }
        public DbSet<Camp> Camps { get; set; }
    }
}