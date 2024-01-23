using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aspBattleArena.Data;
using aspBattleArena.Models;
using Microsoft.AspNetCore.Authorization;

namespace aspBattleArena.Controllers
{
    public class MembersController : Controller
    {
        private readonly AppDbContext _context;

        public MembersController(AppDbContext context)
        {
            _context = context;
        }
        
        // GET: Members
        public async Task<IActionResult> Index()
        {
              return _context.GangMembers != null ? 
                          View(await _context.GangMembers.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.GangMembers'  is null.");
        }
        
        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GangMembers == null)
            {
                return NotFound();
            }

            var gangMember = await _context.GangMembers.Include(gm=>gm.Organization).FirstOrDefaultAsync(m => m.MemberId == id);
            if (gangMember == null)
            {
                return NotFound();
            }

            return View(gangMember);
        }
        
        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        public IActionResult Create([FromForm] GangMember gangMember)
        {
            
                var rnd = new Random();
                var newMember = new GangMember()
                {
                    LastName = gangMember.LastName,
                    FirstName = gangMember.FirstName,
                    Intelligence = rnd.Next(1,10),
                    Endurance = rnd.Next(1,10),
                    Luck = rnd.Next(1, 10),
                    Strength = rnd.Next(1,10),
                    Nationality = gangMember.Nationality,
                };
                if (_context.Organizations.Any(or=>or.Name==gangMember.Organization.Name))
                {
                    newMember.Organization = _context.Organizations.FirstOrDefault(or => or.Name == gangMember.Organization.Name);
                     _context.Organizations.First(or=>or.Name == gangMember.Organization.Name).Members.Add(newMember);
                    _context.GangMembers.Add(newMember);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _context.GangMembers.Add(newMember);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));

                }
                // return View(gangMember);
        }
        
        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GangMembers == null)
            {
                return NotFound();
            }

            var gangMember =  _context.GangMembers.Include(gm=>gm.Organization).FirstOrDefault(gm=>gm.MemberId==id);
            if (gangMember == null)
            {
                return NotFound();
            }
            return View(gangMember);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public IActionResult Edit(int id, [FromForm] GangMember gangMember)
        {
            if (_context.Organizations.Any(or=>or.Name==gangMember.Organization.Name))
                    {
                        _context.GangMembers.First(gm => gm.MemberId == id).FirstName = gangMember.FirstName;
                        _context.GangMembers.First(gm => gm.MemberId == id).LastName = gangMember.LastName;
                        _context.GangMembers.First(gm => gm.MemberId == id).Nationality = gangMember.Nationality;
                        
                        _context.GangMembers.First(gm => gm.MemberId == id).Organization = _context.Organizations.FirstOrDefault(or=>or.Name==gangMember.Organization.Name);

                        if (_context.Organizations.First(gm => gm.Name == gangMember.Organization.Name).Members.Any(gm=>gm.MemberId==gangMember.MemberId))
                        {
                             _context.SaveChanges();
                        }
                        else
                        {
                            _context.Organizations.First(gm => gm.Name == gangMember.Organization.Name).Members.Add(_context.GangMembers.First(gm => gm.MemberId == id));
                             _context.SaveChanges();
                        }
                    }
                    else
                    {
                        return RedirectToAction(nameof(Index));
                    }
            return RedirectToAction(nameof(Index));
        }
        
        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GangMembers == null)
            {
                return NotFound();
            }

            var gangMember = await _context.GangMembers.FirstOrDefaultAsync(m => m.MemberId == id);
            if (gangMember == null)
            {
                return NotFound();
            }

            return View(gangMember);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GangMembers == null)
            {
                return Problem("Entity set 'AppDbContext.GangMembers'  is null.");
            }
            var gangMember =  _context.GangMembers.Include(gm=>gm.Organization).FirstOrDefault(gm=>gm.MemberId ==id);
            if (gangMember != null)
            {
                if (_context.Organizations.First(gm => gm.Name == gangMember.Organization.Name).Members.Any(gm=>gm.MemberId==gangMember.MemberId))
                {
                    _context.Organizations.First(gm => gm.Name == gangMember.Organization.Name).Members.Remove(_context.GangMembers.First(gm => gm.MemberId == id));
                    _context.GangMembers.Remove(gangMember);
                    
                }
                else
                {
                    _context.GangMembers.Remove(gangMember);
                }
               
            }
            
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool GangMemberExists(int id)
        {
          return (_context.GangMembers?.Any(e => e.MemberId == id)).GetValueOrDefault();
        }
    }
}
