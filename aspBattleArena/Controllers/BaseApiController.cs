using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aspBattleArena.Data;
using aspBattleArena.Models;

namespace aspBattleArena.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BaseApiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/BaseApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Base>>> GetBases()
        {
          if (_context.Bases == null)
          {
              return NotFound();
          }
            return await _context.Bases.ToListAsync();
        }

        // GET: api/BaseApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Base>> GetBase(int id)
        {
          if (_context.Bases == null)
          {
              return NotFound();
          }
            var @base = await _context.Bases.FindAsync(id);

            if (@base == null)
            {
                return NotFound();
            }

            return @base;
        }

        // PUT: api/BaseApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBase(int id, Base @base)
        {
            if (id != @base.BaseID)
            {
                return BadRequest();
            }

            _context.Entry(@base).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BaseApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Base>> PostBase(Base @base)
        {
          if (_context.Bases == null)
          {
              return Problem("Entity set 'AppDbContext.Bases'  is null.");
          }
            _context.Bases.Add(@base);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBase", new { id = @base.BaseID }, @base);
        }

        // DELETE: api/BaseApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBase(int id)
        {
            if (_context.Bases == null)
            {
                return NotFound();
            }
            var @base = await _context.Bases.FindAsync(id);
            if (@base == null)
            {
                return NotFound();
            }

            _context.Bases.Remove(@base);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BaseExists(int id)
        {
            return (_context.Bases?.Any(e => e.BaseID == id)).GetValueOrDefault();
        }
    }
}
