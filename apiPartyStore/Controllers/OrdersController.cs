﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Contexts;
using Data.Models;
using Microsoft.AspNetCore.Cors;

namespace apiPartyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class OrdersController : ControllerBase
    {
        private readonly PartyContext _context;

        public OrdersController(PartyContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders
                .Where(od => od.isActive)
                .ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // api/Orders/desactive/5
        [HttpPut("desactive/{id}")]
        public async Task<IActionResult> DesactiveOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound("Order no encontrada para eliminar");
            }

            order.isActive = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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
        //buscar con usuario o id de orden
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Order>>> SearchOrders(string? userName, int? idOrder )
        {
            var ordersQuery = _context.Orders
                .Where(o => o.isActive)
                .AsQueryable();


            if (!string.IsNullOrEmpty(userName))
            {
                ordersQuery = ordersQuery.Where(o => o.Name.Contains(userName));
            }

            if (idOrder > 0)
            {
                ordersQuery = ordersQuery.Where(o => o.Id==idOrder);
            }

            var orders = await ordersQuery.ToListAsync();
            if (!orders.Any())
            {
                return NotFound("No se encontraron Ordenes con esos criterios");
            }
            return Ok(orders);
        }




        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
