using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgricultureAPI_Arminder.Data;
using AgricultureAPI_Arminder.Models;

namespace AgricultureAPI_Arminder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgriculturesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AgriculturesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Agricultures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agriculture>>> GetMyProperty()
        {
            return await _context.MyProperty.ToListAsync();
        }

        // GET: api/Agricultures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Agriculture>> GetAgriculture(int id)
        {
            var agriculture = await _context.MyProperty.FindAsync(id);

            if (agriculture == null)
            {
                return NotFound();
            }

            return agriculture;
        }

        // PUT: api/Agricultures/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgriculture(int id, Agriculture agriculture)
        {
            if (id != agriculture.ID)
            {
                agriculture.ID=id;
            }

            _context.Entry(agriculture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgricultureExists(id))
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

        // POST: api/Agricultures
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Agriculture>> PostAgriculture(Agriculture agriculture)
        {
            _context.MyProperty.Add(agriculture);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgriculture", new { id = agriculture.ID }, agriculture);
        }

        // DELETE: api/Agricultures/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Agriculture>> DeleteAgriculture(int id)
        {
            var agriculture = await _context.MyProperty.FindAsync(id);
            if (agriculture == null)
            {
                return NotFound();
            }

            _context.MyProperty.Remove(agriculture);
            await _context.SaveChangesAsync();

            return agriculture;
        }

        private bool AgricultureExists(int id)
        {
            return _context.MyProperty.Any(e => e.ID == id);
        }
    }
}
