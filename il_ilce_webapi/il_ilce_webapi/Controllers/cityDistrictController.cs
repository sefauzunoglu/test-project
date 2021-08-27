using il_ilce_webapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace il_ilce_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class cityDistrictController : ControllerBase
    {
        private readonly cityDistrictDetailContext _context;

        public cityDistrictController(cityDistrictDetailContext context)
        {
            _context = context;
        }

        // GET: api/cityDistrict
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cityDistrict>>> GetAll()
        {
            return await _context.cityDistricts.ToListAsync();
        }


        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<cityDistrict>> GetCityById(int id)
        {
            var cityDistrictDetail = await _context.cityDistricts.FindAsync(id);

            if (cityDistrictDetail == null)
            {
                return NotFound();
            }

            return cityDistrictDetail;
        }

        // POST: api/cityDistrict
        [HttpPost]
        public async Task<ActionResult<cityDistrict>> Post(cityDistrict cityDistrictDetail)
        {
            _context.cityDistricts.Add(cityDistrictDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettestDetail", new { id = cityDistrictDetail.CityId }, cityDistrictDetail);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, cityDistrict cityDistrictDetail)
        {
            if (id != cityDistrictDetail.CityId)
            {
                return BadRequest();
            }

            _context.Entry(cityDistrictDetail).State = EntityState.Modified;

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

        // DELETE: api/cityDistrict/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var testDetail = await _context.cityDistricts.FindAsync(id);
            if (testDetail == null)
            {
                return NotFound();
            }

            _context.cityDistricts.Remove(testDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool testDetailExists(int id)
        {
            return _context.cityDistricts.Any(e => e.CityId == id);
        }
    }
}
