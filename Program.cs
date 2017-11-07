using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MnkyTv.Data;
using MnkyTv.Models.IdentityModels;

namespace MnkyTv
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var host = BuildWebHost(args);

      using (var scope = host.Services.CreateScope())
      {
        var services = scope.ServiceProvider;
        try
        {
          var context = services.GetRequiredService<ApplicationDbContext>();
          var userMgr = services.GetRequiredService<UserManager<ApplicationUser>>();
          var roleMgr = services.GetRequiredService<RoleManager<ApplicationRole>>();
          DbInitializer.Initialize(context, userMgr, roleMgr);
        }
        catch { }
      }

      host.Run();
    }

    public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();
  }
}
