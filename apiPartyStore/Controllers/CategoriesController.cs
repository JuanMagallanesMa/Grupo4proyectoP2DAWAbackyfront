using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Contexts;
using Data.Models;

namespace ApiPartyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly PartyContext _context;

        public CategoriesController(PartyContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _context.Categories
                .Where(c => c.Estado) 
                .ToListAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/Categories/deactivate/5
        [HttpPut("deactivate/{id}")]
        public async Task<IActionResult> DeactivateCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound("Categoría no encontrada para desactivar.");
            }

            // Desactivación lógica
            category.Estado = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // GET: api/Categories/search
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Category>>> SearchCategories(string? nombre, bool? estado)
        {
            var categoriesQuery = _context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(nombre))
            {
                categoriesQuery = categoriesQuery.Where(c => c.Nombre.Contains(nombre));
            }

            if (estado.HasValue)
            {
                categoriesQuery = categoriesQuery.Where(c => c.Estado == estado.Value);
            }

            var categories = await categoriesQuery.ToListAsync();

            if (!categories.Any())
            {
                return NotFound("No se encontraron categorías con los criterios especificados.");
            }

            return Ok(categories);
        }

        // GET: api/Categories/names
        [HttpGet("names")]
        public async Task<ActionResult<IEnumerable<object>>> GetCategoryNames()
        {
            return await _context.Categories
                .Where(c => c.Estado) // Solo categorías activas
                .Select(c => new
                {
                    c.Id,
                    c.Nombre
                })
                .ToListAsync();
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }




    }
}
