using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aspBattleArena.Data;
using aspBattleArena.Models;
using aspBattleArena.Views.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace aspBattleArena.Controllers
{
    public class BossController : Controller
    {
        private readonly AppDbContext _context;
        
        public BossController(AppDbContext context)
        {
            _context = context;
            
        }
        
        // GET: Boss
        public async Task<IActionResult> Index()
        {
              return _context.Bosses != null ? 
                          View(await _context.Bosses.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Bosses'  is null.");
        }
        
        // GET: Boss/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            // if (id == null || _context.Bosses == null)
            // {
            //     return NotFound();
            // }
            //
            var @boss = await _context.Bosses.FirstAsync(m => m.BossId == id);
            // if (@boss == null)
            // {
            //     return NotFound();
            // }

            return View(@boss );
        }
        
       
        // GET: Boss/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Boss/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       
        public IActionResult Create([FromForm] BossViewModel bossViewModel)
        {
            try
            {
                
                    _context.Bosses.Add(new Boss()
                    {
                      FirstName  = bossViewModel.FirstName,
                      LastName = bossViewModel.LastName,
                      Age=bossViewModel.Age,
                      Nationality = bossViewModel.Nationality,
                       OrganizationName = bossViewModel.Organization,
                      // Organizations = _context.Organizations.FirstOrDefault(c=> c.Name ==bossViewModel.Organization),
                      // Ogranizations = new List<Organization>(){ _context.Organizations.FirstOrDefault()}
                       //Organizations = new List<Organization>(){_context.Organizations.FirstOrDefault(c=> c.Name ==bossViewModel.Organization)}
                    });
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                
            }
            catch (DataException /*dex*/)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again.");
            } 
            return View();
        }
        
        // GET: Boss/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bosses == null)
            {
                return NotFound();
            }
            var boss = await _context.Bosses.FindAsync(id);
            if (boss == null)
            {
                return NotFound();
            }
            return View(boss);
        }

        // POST: Boss/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public IActionResult Edit(int id, [FromForm] Boss bossViewModel)
        {
            
                    _context.Bosses.FirstOrDefault(b => b.BossId == id).FirstName = bossViewModel.FirstName;
                    _context.Bosses.FirstOrDefault(b => b.BossId == id).LastName = bossViewModel.LastName;
                    _context.Bosses.FirstOrDefault(b => b.BossId == id).Age = bossViewModel.Age;
                    _context.Bosses.FirstOrDefault(b => b.BossId == id).Nationality = bossViewModel.Nationality;
                    _context.Bosses.FirstOrDefault(b => b.BossId == id).OrganizationName = bossViewModel.OrganizationName;

                    
                     _context.SaveChanges();
                
                return RedirectToAction(nameof(Index));
            
        }
        
        // GET: Boss/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bosses == null)
            {
                return NotFound();
            }

            var boss = await _context.Bosses
                .FirstOrDefaultAsync(m => m.BossId == id);
            if (boss == null)
            {
                return NotFound();
            }

            return View(boss);
        }

        // POST: Boss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bosses == null)
            {
                return Problem("Entity set 'AppDbContext.Bosses'  is null.");
            }
            var boss = await _context.Bosses.FindAsync(id);
            if (boss != null)
            {
                _context.Bosses.Remove(boss);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BossExists(int id)
        {
          return (_context.Bosses?.Any(e => e.BossId == id)).GetValueOrDefault();
        }
    }
}
