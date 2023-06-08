using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcActor.Data;
using MvcTheater.Models;

namespace MvcTheater.Controllers
{
    public class ShowController : Controller
    {
        private readonly MvcActorContext _context;

        public ShowController(MvcActorContext context)
        {
            _context = context;
        }

        // GET: Show
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "Name" : "";
            ViewBag.DateSortParam = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.PriceSortParam = sortOrder == "Price" ? "price_desc" : "Price";
            var shows = from s in _context.Show
                        select s;
            
            switch(sortOrder){
                case "Name":
                    shows = shows.OrderBy(s => s.ShowName);
                    break;
                case "Date":
                    shows = shows.OrderBy(s => s.ShowDate);
                    break;
                case "date_desc":
                    shows = shows.OrderByDescending(s => s.ShowDate);
                    break;
                case "Price":
                    shows = shows.OrderBy(s => (int)s.ShowPrice);
                    break;
                case "price_desc":
                    shows = shows.OrderByDescending(s => (int)s.ShowPrice);
                    break;
                default:
                    shows = shows.OrderBy(s => s.ShowName);
                    break;
            }
            return View(await shows.ToListAsync());
            //   return _context.Show != null ? 
            //               View(await _context.Show.ToListAsync()) :
            //               Problem("Entity set 'MvcActorContext.Show'  is null.");
        }

        // GET: Show/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Show == null)
            {
                return NotFound();
            }

            var show = await _context.Show
                .FirstOrDefaultAsync(m => m.Id == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // GET: Show/Create
        public IActionResult Create()
        {
            ViewBag.TeamList=_context.Team.ToList();
            return View();
        }

        // POST: Show/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ShowName,ShowDate,ShowTime,ShowPrice,ShowType")] Show show,IFormCollection form)
        {
            String teamId=form["Team"];
            Team team=_context.Team.Where(t=>t.Id==int.Parse(teamId)).First();
            if (ModelState.IsValid)
            {
                show.Team=team;
                _context.Add(show);
                _context.SaveChanges();
                
                return RedirectToAction(nameof(Index));
            }
            return View(show);
        }

        // GET: Show/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Show == null)
            {
                return NotFound();
            }

            var show = await _context.Show.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }
            return View(show);
        }

        // POST: Show/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ShowName,ShowDate,ShowTime,ShowPrice,ShowType")] Show show)
        {
            if (id != show.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(show);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowExists(show.Id))
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
            return View(show);
        }

        // GET: Show/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Show == null)
            {
                return NotFound();
            }

            var show = await _context.Show
                .FirstOrDefaultAsync(m => m.Id == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // POST: Show/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Show == null)
            {
                return Problem("Entity set 'MvcActorContext.Show'  is null.");
            }
            var show = await _context.Show.FindAsync(id);
            if (show != null)
            {
                _context.Show.Remove(show);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowExists(int id)
        {
          return (_context.Show?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
