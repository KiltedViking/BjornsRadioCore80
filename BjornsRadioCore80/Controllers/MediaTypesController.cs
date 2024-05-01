using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BjornsRadioCore80.Data;
using BjornsRadioCore80.Models;

namespace BjornsRadioCore80.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaTypesController : ControllerBase
    {
        private readonly BjornsRadioDbContext _context;

        public MediaTypesController(BjornsRadioDbContext context)
        {
            _context = context;
        }

        // GET: api/MediaTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MediaType>>> GetMediaTypes()
        {
            return await _context.MediaTypes.ToListAsync();
        }

        // GET: api/MediaTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MediaType>> GetMediaType(int id)
        {
            var mediaType = await _context.MediaTypes.FindAsync(id);

            if (mediaType == null)
            {
                return NotFound();
            }

            return mediaType;
        }

        // PUT: api/MediaTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMediaType(int id, MediaType mediaType)
        {
            if (id != mediaType.Id)
            {
                return BadRequest();
            }

            _context.Entry(mediaType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediaTypeExists(id))
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

        // POST: api/MediaTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MediaType>> PostMediaType(MediaType mediaType)
        {
            _context.MediaTypes.Add(mediaType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMediaType", new { id = mediaType.Id }, mediaType);
        }

        // DELETE: api/MediaTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMediaType(int id)
        {
            var mediaType = await _context.MediaTypes.FindAsync(id);
            if (mediaType == null)
            {
                return NotFound();
            }

            _context.MediaTypes.Remove(mediaType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MediaTypeExists(int id)
        {
            return _context.MediaTypes.Any(e => e.Id == id);
        }
    }
}
