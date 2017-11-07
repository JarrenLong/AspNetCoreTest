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
  public class MediaVotesController : Controller
  {
    private readonly ApplicationDbContext _context;

    public MediaVotesController(ApplicationDbContext context)
    {
      _context = context;
    }

    [Authorize(Roles = "User")]
    // GET: MediaVotes
    public async Task<IActionResult> Index()
    {
      return View(await _context.MediaVotes.ToListAsync());
    }

    [Authorize(Roles = "User")]
    // GET: MediaVotes/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var mediaVote = await _context.MediaVotes
          .SingleOrDefaultAsync(m => m.ID == id);
      if (mediaVote == null)
      {
        return NotFound();
      }

      return View(mediaVote);
    }

    [Authorize(Roles = "User")]
    // GET: MediaVotes/Create
    public IActionResult Create()
    {
      return View();
    }

    [Authorize(Roles = "User")]
    // POST: MediaVotes/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ID")] MediaVote mediaVote)
    {
      if (ModelState.IsValid)
      {
        _context.Add(mediaVote);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(mediaVote);
    }

    [Authorize(Roles = "User")]
    // GET: MediaVotes/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var mediaVote = await _context.MediaVotes.SingleOrDefaultAsync(m => m.ID == id);
      if (mediaVote == null)
      {
        return NotFound();
      }
      return View(mediaVote);
    }

    [Authorize(Roles = "User")]
    // POST: MediaVotes/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ID")] MediaVote mediaVote)
    {
      if (id != mediaVote.ID)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(mediaVote);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!MediaVoteExists(mediaVote.ID))
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
      return View(mediaVote);
    }

    [Authorize(Roles = "Admin")]
    // GET: MediaVotes/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var mediaVote = await _context.MediaVotes
          .SingleOrDefaultAsync(m => m.ID == id);
      if (mediaVote == null)
      {
        return NotFound();
      }

      return View(mediaVote);
    }

    [Authorize(Roles = "Admin")]
    // POST: MediaVotes/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var mediaVote = await _context.MediaVotes.SingleOrDefaultAsync(m => m.ID == id);
      _context.MediaVotes.Remove(mediaVote);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool MediaVoteExists(int id)
    {
      return _context.MediaVotes.Any(e => e.ID == id);
    }
  }
}
