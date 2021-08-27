using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.DTO;
using test.Models;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testDetailsController : ControllerBase
    {
        private readonly testDetailContext _context;

        public testDetailsController(testDetailContext context)
        {
            _context = context;
        }

        // GET: api/testDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<testDetail>>> GetAll()
        {
            return await _context.testDetails.ToListAsync();
        }


        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<testDetail>> GetHotelById(int id)
        {
            var testDetail = await _context.testDetails.FindAsync(id);

            if (testDetail == null)
            {
                return NotFound();
            }

            return testDetail;
        }


        // PUT: api/testDetails/5

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, testDetail testDetail)
        {
            if (id != testDetail.HotelId)
            {
                return BadRequest();
            }

            _context.Entry(testDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!testDetailExists(id))
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

        // POST: api/testDetails
        [HttpPost]
        public async Task<ActionResult<testDetail>> Post(testDetail testDetail)
        {
            _context.testDetails.Add(testDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAll", new { id = testDetail.HotelId }, testDetail);
        }

        // DELETE: api/testDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var testDetail = await _context.testDetails.FindAsync(id);
            if (testDetail == null)
            {
                return NotFound();
            }

            _context.testDetails.Remove(testDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool testDetailExists(int id)
        {
            return _context.testDetails.Any(e => e.HotelId == id);
        }

    }
}
