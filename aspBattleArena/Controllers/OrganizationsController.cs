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
    
    public class OrganizationsController : Controller
    {
        private readonly AppDbContext _context;

        public OrganizationsController(AppDbContext context)
        {
            _context = context;
        }
        
        // GET: Organizations
        public async Task<IActionResult> Index()
        {
              return _context.Organizations != null ? 
                          View(await _context.Organizations.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Organizations'  is null.");
        }
        
        // GET: Organizations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
           
            var @organization = await _context.Organizations
                .FirstOrDefaultAsync(m => m.OgranizationId == id);
           

            return View(@organization);
        }
        
        // GET: Organizations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Organizations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public  IActionResult Create([FromForm] OrganizationViewModel organization)
        {
            try
            {
                _context.Organizations.Add(new Organization()
                {
                    Name = organization.Name,
                    CountryOfOrigin = organization.CountryOfOrigin,
                    Boss = _context.Bosses.FirstOrDefault(b=>b.BossId==organization.BossID),
                    NameOfBoss = _context.Bosses.FirstOrDefault(b=>b.BossId==organization.BossID).FirstName+" "+_context.Bosses.FirstOrDefault(b=>b.BossId==organization.BossID).LastName,
                });
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (DataException /*dex*/)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again.");
            } 
            return View(organization);
        }
        
        // GET: Organizations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Organizations == null)
            {
                return NotFound();
            }
            var @organization =  _context.Organizations.Include(b=>b.Boss).FirstOrDefault(or=>or.OgranizationId ==id);
            if (@organization == null)
            {
                return NotFound();
            }
            return View(@organization);
        }

        // POST: Organizations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult Edit(int id, [FromForm] Organization organization)
        {

            
            _context.Organizations.FirstOrDefault(o => o.OgranizationId == id).Name = organization.Name;
            _context.Organizations.FirstOrDefault(o => o.OgranizationId == id).CountryOfOrigin =
                organization.CountryOfOrigin;
            _context.Organizations.FirstOrDefault(o => o.OgranizationId == id).Boss =
                _context.Bosses.FirstOrDefault(o => o.BossId == organization.Boss.BossId);
            
            _context.Organizations.FirstOrDefault(o => o.OgranizationId == id).NameOfBoss =
                _context.Organizations.FirstOrDefault(o => o.OgranizationId == id).Boss.FirstName + " " +
                _context.Organizations.FirstOrDefault(o => o.OgranizationId == id).Boss.LastName;
                    
                     _context.SaveChanges();
                
                return RedirectToAction(nameof(Index));
            
        }
        
        // GET: Organizations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Organizations == null)
            {
                return NotFound();
            }

            var organization = await _context.Organizations
                .FirstOrDefaultAsync(m => m.OgranizationId == id);
            if (organization == null)
            {
                return NotFound();
            }

            return View(organization);
        }

        // POST: Organizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Organizations == null)
            {
                return Problem("Entity set 'AppDbContext.Organizations'  is null.");
            }
            var organization = await _context.Organizations.FindAsync(id);
            if (organization != null)
            {
                _context.Organizations.Remove(organization);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizationExists(int id)
        {
          return (_context.Organizations?.Any(e => e.OgranizationId == id)).GetValueOrDefault();
        }
    }
}
