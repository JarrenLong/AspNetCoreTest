using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MnkyTv.Models.IdentityModels;
using System.Linq;
using System.Threading.Tasks;

namespace MnkyTv.Controllers
{
  public class ApplicationRolesController : Controller
  {
    private readonly RoleManager<ApplicationRole> roleManager;

    public ApplicationRolesController(RoleManager<ApplicationRole> roleManager)
    {
      this.roleManager = roleManager;
    }

    // GET: ApplicationRoles
    public async Task<IActionResult> Index()
    {
      return View(await roleManager.Roles.ToListAsync());
    }

    // GET: ApplicationRoles/Details/5
    public async Task<IActionResult> Details(string id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var applicationRole = await roleManager.Roles.SingleOrDefaultAsync(m => m.Id == id);
      if (applicationRole == null)
      {
        return NotFound();
      }

      return View(applicationRole);
    }

    // GET: ApplicationRoles/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: ApplicationRoles/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Description,Id,Name")] ApplicationRole applicationRole)
    {
      if (ModelState.IsValid)
      {
        applicationRole.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
        var roleRuslt = await roleManager.CreateAsync(applicationRole);
        if (roleRuslt.Succeeded)
          return RedirectToAction(nameof(Index));
      }
      return View(applicationRole);
    }

    // GET: ApplicationRoles/Edit/5
    public async Task<IActionResult> Edit(string id)
    {
      if (id == null)
        return NotFound();

      var applicationRole = await roleManager.FindByIdAsync(id);
      if (applicationRole == null)
        return NotFound();

      return View(applicationRole);
    }

    // POST: ApplicationRoles/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, [Bind("Description,Id,Name")] ApplicationRole applicationRole)
    {
      if (id != applicationRole.Id)
        return NotFound();

      if (ModelState.IsValid)
      {
        try
        {
          applicationRole.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
          var roleRuslt = await roleManager.UpdateAsync(applicationRole);
          if (roleRuslt.Succeeded)
            return RedirectToAction(nameof(Index));
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!ApplicationRoleExists(applicationRole.Id))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index));
      }
      return View(applicationRole);
    }

    // GET: ApplicationRoles/Delete/5
    public async Task<IActionResult> Delete(string id)
    {
      if (id == null)
        return NotFound();

      var applicationRole = await roleManager.FindByIdAsync(id);
      if (applicationRole == null)
        return NotFound();

      return View(applicationRole);
    }

    // POST: ApplicationRoles/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
      var applicationRole = await roleManager.FindByIdAsync(id);
      var roleRuslt = roleManager.DeleteAsync(applicationRole).Result;
      if (roleRuslt.Succeeded)
        return RedirectToAction(nameof(Index));
      return View();
    }

    private bool ApplicationRoleExists(string id)
    {
      return roleManager.Roles.Any(m => m.Id == id);
    }
  }
}
