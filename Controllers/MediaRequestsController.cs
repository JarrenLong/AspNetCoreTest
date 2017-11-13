using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MnkyTv.Data;
using MnkyTv.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MnkyTv.Controllers
{
  [Authorize]
  public class MediaRequestsController : Controller
  {
    private readonly ApplicationDbContext _context;

    public MediaRequestsController(ApplicationDbContext context)
    {
      _context = context;
    }

    //[Authorize(Roles = "User")]
    // GET: MediaRequests
    public async Task<IActionResult> Index()
    {
      return View(await _context.MediaRequests.ToListAsync());
    }

    //[Authorize(Roles = "User")]
    // GET: MediaRequests/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var mediaRequest = await _context.MediaRequests
          .SingleOrDefaultAsync(m => m.ID == id);
      if (mediaRequest == null)
      {
        return NotFound();
      }

      return View(mediaRequest);
    }

    //[Authorize(Roles = "User")]
    // GET: MediaRequests/Create
    public IActionResult Create()
    {
      return View();
    }

    //[Authorize(Roles = "User")]
    // POST: MediaRequests/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ID,CreatedOn,MediaType,Name,Year,Complete,CompletedOn")] MediaRequest mediaRequest)
    {
      if (ModelState.IsValid)
      {
        _context.Add(mediaRequest);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(mediaRequest);
    }

    //[Authorize(Roles = "Admin")]
    // GET: MediaRequests/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var mediaRequest = await _context.MediaRequests.SingleOrDefaultAsync(m => m.ID == id);
      if (mediaRequest == null)
      {
        return NotFound();
      }
      return View(mediaRequest);
    }

    //[Authorize(Roles = "Admin")]
    // POST: MediaRequests/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ID,CreatedOn,MediaType,Name,Year,Complete,CompletedOn")] MediaRequest mediaRequest)
    {
      if (id != mediaRequest.ID)
        return NotFound();

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(mediaRequest);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!MediaRequestExists(mediaRequest.ID))
            return NotFound();
          else
            throw;
        }
        return RedirectToAction(nameof(Index));
      }
      return View(mediaRequest);
    }

    //[Authorize(Roles = "Admin")]
    // GET: MediaRequests/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var mediaRequest = await _context.MediaRequests
          .SingleOrDefaultAsync(m => m.ID == id);
      if (mediaRequest == null)
      {
        return NotFound();
      }

      return View(mediaRequest);
    }

    //[Authorize(Roles = "Admin")]
    // POST: MediaRequests/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var mediaRequest = await _context.MediaRequests.SingleOrDefaultAsync(m => m.ID == id);
      _context.MediaRequests.Remove(mediaRequest);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool MediaRequestExists(int id)
    {
      return _context.MediaRequests.Any(e => e.ID == id);
    }
  }
}
