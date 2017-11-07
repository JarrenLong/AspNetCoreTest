using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MnkyTv.Models;
using MnkyTv.Models.IdentityModels;

namespace MnkyTv.Data
{
  public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
    }

    public DbSet<MediaRequest> MediaRequests { get; set; }
    public DbSet<MediaVote> MediaVotes { get; set; }
    //public DbSet<ApplicationRole> ApplicationRole { get; set; }
  }
}
