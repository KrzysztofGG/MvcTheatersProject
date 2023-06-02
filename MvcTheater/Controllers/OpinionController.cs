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
    public class OpinionController : Controller
    {
        private readonly MvcActorContext _context;

        public OpinionController(MvcActorContext context)
        {
            _context = context;
        }

        // GET: Opinion
        public async Task<IActionResult> Index()
        {
            
            foreach(var o in _context.Opinion.ToList()){
                Console.WriteLine(o.Show==null);
            }
            return _context.Opinion != null ? 
                          View(await _context.Opinion.Include(o => o.Show).ToListAsync()) :
                          Problem("Entity set 'MvcActorContext.Opinion'  is null.");
        }

        // GET: Opinion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Opinion == null)
            {
                return NotFound();
            }

            var opinion = await _context.Opinion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opinion == null)
            {
                return NotFound();
            }

            return View(opinion);
        }

        // GET: Opinion/Create
        public IActionResult Create()
        {
            ViewBag.ShowList=_context.Show.ToList();
            return View();
        }

        // POST: Opinion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IsPositive,OpinionText")] Opinion opinion, IFormCollection form)
        {
            
            String showId=form["Show"];
            Console.WriteLine(showId);
            Console.WriteLine("wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww");
            Show show=_context.Show.Where(s=>s.Id==int.Parse(showId)).First();
            Console.WriteLine(show.ShowName+" Tworzenie -----------------------");
            if (ModelState.IsValid)
            {
                opinion.Show=show;
                _context.Add(opinion);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(opinion);
        }

        // GET: Opinion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Opinion == null)
            {
                return NotFound();
            }

            var opinion = await _context.Opinion.FindAsync(id);
            if (opinion == null)
            {
                return NotFound();
            }
            return View(opinion);
        }

        // POST: Opinion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IsPositive,OpinionText")] Opinion opinion)
        {
            if (id != opinion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opinion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpinionExists(opinion.Id))
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
            return View(opinion);
        }

        // GET: Opinion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Opinion == null)
            {
                return NotFound();
            }

            var opinion = await _context.Opinion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opinion == null)
            {
                return NotFound();
            }

            return View(opinion);
        }

        // POST: Opinion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Opinion == null)
            {
                return Problem("Entity set 'MvcActorContext.Opinion'  is null.");
            }
            var opinion = await _context.Opinion.FindAsync(id);
            if (opinion != null)
            {
                _context.Opinion.Remove(opinion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpinionExists(int id)
        {
          return (_context.Opinion?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
