using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prueba_fernando_gomez.Models;

namespace prueba_fernando_gomez.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbPacientesController : ControllerBase
    {
        private readonly prueba_fernando_gomezContext _context;

        public TbPacientesController(prueba_fernando_gomezContext context)
        {
            _context = context;
        }

        // GET: api/TbPacientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbPaciente>>> GetTbPacientes()
        {
          if (_context.TbPacientes == null)
          {
              return NotFound();
          }
            return await _context.TbPacientes.ToListAsync();
        }

        // GET: api/TbPacientes/
        [HttpGet("{id}")]
        public async Task<ActionResult<TbPaciente>> GetTbPaciente(int id)
        {
          if (_context.TbPacientes == null)
          {
              return NotFound();
          }
            var tbPaciente = await _context.TbPacientes.FindAsync(id);

            if (tbPaciente == null)
            {
                return NotFound();
            }

            return tbPaciente;
        }

        // PUT: api/TbPacientes/
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbPaciente(int id,[FromBody] TbPaciente tbPaciente)
        {
            if (id != tbPaciente.IdPacientes)
            {
                return BadRequest();
            }

            _context.Entry(tbPaciente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbPacienteExists(id))
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

        // POST: api/TbPacientes
        [HttpPost]
        public async Task<ActionResult<TbPaciente>> PostTbPaciente(TbPaciente tbPaciente)
        {
          if (_context.TbPacientes == null)
          {
              return Problem("Entity set 'prueba_fernando_gomezContext.TbPacientes'  is null.");
          }
            _context.TbPacientes.Add(tbPaciente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbPaciente", new { id = tbPaciente.IdPacientes }, tbPaciente);
        }

        // DELETE: api/TbPacientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbPaciente(int id)
        {
            if (_context.TbPacientes == null)
            {
                return NotFound();
            }
            var tbPaciente = await _context.TbPacientes.FindAsync(id);
            if (tbPaciente == null)
            {
                return NotFound();
            }

            _context.TbPacientes.Remove(tbPaciente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbPacienteExists(int id)
        {
            return (_context.TbPacientes?.Any(e => e.IdPacientes == id)).GetValueOrDefault();
        }
    }
}
