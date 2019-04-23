using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using vaskeApp.Models;
using System.Configuration;

namespace vaskeApp.Controllers
{
    [Route("api/vask")]
    [ApiController]
    public class VaskController : ControllerBase
    {
        private readonly VaskContext _context;

        public VaskController(VaskContext context)
        {
            _context = context;
        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Vask>> GetVask()
        {
            return _context.vaskOversikt.ToList();

        }
        //public async Task<ActionResult<Vask>> Get()
        //{
        //    return await _context.vaskOversikt.ToListAsync();
        //}

        // GET api/vask/spesifik vaskID
        [HttpGet("{id}")]
        public async Task<ActionResult<Vask>> GetVask(long id)
        {
            //return "value";
            return await _context.vaskOversikt.FindAsync(id);
            
        }

        // POST api/vask  
        [HttpPost]
        public async Task<ActionResult<Vask>>PostVask(Vask vask)
        {
            _context.vaskOversikt.Add(vask);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVask), new { id = vask.vaskID }, vask);
        
        }

        // PUT api/vask/ id på vask du vil endre
        [HttpPut("{id}")]
        public async Task<ActionResult<Vask>>UpdateVask(long id, Vask vask)
         {
             var exists = await _context.vaskOversikt.AnyAsync(v => v.vaskID == id);
             if (!exists)
                {
                  return NotFound();
                }

            _context.vaskOversikt.Update(vask);

            await _context.SaveChangesAsync();

            return Ok();

         }

        // DELETE api/vask/ id på vask som skal slettes
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var valgtVask = await _context.vaskOversikt.FindAsync(id);

            _context.vaskOversikt.Remove(valgtVask);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
