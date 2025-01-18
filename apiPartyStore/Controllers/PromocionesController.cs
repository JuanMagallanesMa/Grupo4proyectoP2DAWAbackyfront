using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Contexts;
using Data.Models;

namespace apiPartyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocionesController : ControllerBase
    {
        private readonly PartyContext _context;

        public PromocionesController(PartyContext context)
        {
            _context = context;
        }

        // GET: api/Promociones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Promociones>>> GetPromotions()
        {
            return await _context.Promotions.ToListAsync();
        }

        // GET: api/Promociones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Promociones>> GetPromociones(int id)
        {
            var promociones = await _context.Promotions.FindAsync(id);

            if (promociones == null)
            {
                return NotFound();
            }

            return promociones;
        }

        // PUT: api/Promociones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPromociones(int id, Promociones promociones)
        {
            if (id != promociones.Id)
            {
                return BadRequest();
            }

            _context.Entry(promociones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromocionesExists(id))
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

        // POST: api/Promociones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Promociones>> PostPromociones(Promociones promociones)
        {
            _context.Promotions.Add(promociones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPromociones", new { id = promociones.Id }, promociones);
        }

        // DELETE: api/Promociones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromociones(int id)
        {
            var promociones = await _context.Promotions.FindAsync(id);
            if (promociones == null)
            {
                return NotFound();
            }

            _context.Promotions.Remove(promociones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PromocionesExists(int id)
        {
            return _context.Promotions.Any(e => e.Id == id);
        }
    }
}
