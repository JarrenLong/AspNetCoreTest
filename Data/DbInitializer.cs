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
      var adminRole = new ApplicationRole() { Name = "Admin", Description = "Application admins", CreatedDate = DateTime.Now };
      roleMgr.CreateAsync(adminRole);
      context.Roles.Add(adminRole);
      context.SaveChanges();

      var userRole = new ApplicationRole() { Name = "User", Description = "Regular users", CreatedDate = DateTime.Now };
      roleMgr.CreateAsync(userRole);
      context.Roles.Add(userRole);
      context.SaveChanges();

      // Create default "Admin" user with password "Password123!"
      var admin = new ApplicationUser() { CanLogin = true, UserName = "Admin", Email = "admin@example.com" };
      userMgr.CreateAsync(admin, "Password123!");
      context.Users.Add(admin);
      context.SaveChanges();

      userMgr.AddToRoleAsync(admin, adminRole.Name);
      userMgr.AddToRoleAsync(admin, userRole.Name);
      context.UserRoles.Add(new IdentityUserRole<string>() { UserId = admin.Id, RoleId = adminRole.Id });
      context.UserRoles.Add(new IdentityUserRole<string>() { UserId = admin.Id, RoleId = userRole.Id });
      context.SaveChanges();
    }
  }
}
