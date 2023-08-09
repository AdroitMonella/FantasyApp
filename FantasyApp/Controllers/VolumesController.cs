using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FantasyApp.Data;
using FantasyApp.Models;

namespace FantasyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolumesController : ControllerBase
    {
        private readonly FantasyAppContext _context;

        public VolumesController(FantasyAppContext context)
        {
            _context = context;
        }

        // GET: api/Volumes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Volume>>> GetVolume()
        {
          if (_context.Volume == null)
          {
              return NotFound();
          }
            return await _context.Volume.ToListAsync();
        }

        // GET: api/Volumes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Volume>> GetVolume(Guid id)
        {
          if (_context.Volume == null)
          {
              return NotFound();
          }
            var volume = await _context.Volume.FindAsync(id);

            if (volume == null)
            {
                return NotFound();
            }

            return volume;
        }

        // PUT: api/Volumes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVolume(Guid id, Volume volume)
        {
            if (id != volume.VolumeId)
            {
                return BadRequest();
            }

            _context.Entry(volume).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolumeExists(id))
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

        // POST: api/Volumes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Volume>> PostVolume(Volume volume)
        {
          if (_context.Volume == null)
          {
              return Problem("Entity set 'FantasyAppContext.Volume'  is null.");
          }
            _context.Volume.Add(volume);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVolume", new { id = volume.VolumeId }, volume);
        }

        // DELETE: api/Volumes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVolume(Guid id)
        {
            if (_context.Volume == null)
            {
                return NotFound();
            }
            var volume = await _context.Volume.FindAsync(id);
            if (volume == null)
            {
                return NotFound();
            }

            _context.Volume.Remove(volume);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VolumeExists(Guid id)
        {
            return (_context.Volume?.Any(e => e.VolumeId == id)).GetValueOrDefault();
        }
    }
}
