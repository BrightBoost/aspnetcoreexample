using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstAPI.Models;

namespace MyFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductProfilesController : ControllerBase
    {
        private readonly VoorbeeldApiContext _context;

        public ProductProfilesController(VoorbeeldApiContext context)
        {
            _context = context;
        }

        // GET: api/ProductProfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductProfile>>> GetProductProfiles()
        {
          if (_context.ProductProfiles == null)
          {
              return NotFound();
          }
            return await _context.ProductProfiles.ToListAsync();
        }

        // GET: api/ProductProfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductProfile>> GetProductProfile(int id)
        {
          if (_context.ProductProfiles == null)
          {
              return NotFound();
          }
            var productProfile = await _context.ProductProfiles.FindAsync(id);

            if (productProfile == null)
            {
                return NotFound();
            }

            return productProfile;
        }

        // PUT: api/ProductProfiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductProfile(int id, ProductProfile productProfile)
        {
            if (id != productProfile.Id)
            {
                return BadRequest();
            }

            _context.Entry(productProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductProfileExists(id))
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

        // POST: api/ProductProfiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductProfile>> PostProductProfile(ProductProfile productProfile)
        {
          if (_context.ProductProfiles == null)
          {
              return Problem("Entity set 'VoorbeeldApiContext.ProductProfiles'  is null.");
          }
            _context.ProductProfiles.Add(productProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductProfile", new { id = productProfile.Id }, productProfile);
        }

        // DELETE: api/ProductProfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductProfile(int id)
        {
            if (_context.ProductProfiles == null)
            {
                return NotFound();
            }
            var productProfile = await _context.ProductProfiles.FindAsync(id);
            if (productProfile == null)
            {
                return NotFound();
            }

            _context.ProductProfiles.Remove(productProfile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductProfileExists(int id)
        {
            return (_context.ProductProfiles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
