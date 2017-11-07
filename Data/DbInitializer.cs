using Microsoft.AspNetCore.Identity;
using MnkyTv.Models.IdentityModels;
using System;
using System.Linq;

namespace MnkyTv.Data
{
  public static class DbInitializer
  {
    public static void Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userMgr, RoleManager<ApplicationRole> roleMgr)
    {
      context.Database.EnsureCreated();

      if (context.Users.Any())
        return; // Already seeded, bail out

      // Create the "Admin" and "User" roles
      var role = new ApplicationRole() { Name = "Admin", Description = "Application admins", CreatedDate = DateTime.Now };
      context.Roles.Add(role);
      context.SaveChanges();
      var adminId = context.Roles.FirstOrDefault()?.Id;

      role = new ApplicationRole() { Name = "User", Description = "Regular users", CreatedDate = DateTime.Now };
      context.Roles.Add(role);
      context.SaveChanges();

      // Create default "Admin" user with password "Password123!"
      var admin = new ApplicationUser() { CanLogin = true, UserName = "Admin", Email = "admin@example.com" };
      userMgr.CreateAsync(admin, "Password123!");

      context.Users.Add(admin);
      context.SaveChanges();
    }
  }
}
