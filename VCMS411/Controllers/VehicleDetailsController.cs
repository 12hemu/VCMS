using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VCMS411.Models;

namespace VCMS411.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleDetailsController : ControllerBase
    {
        private readonly VCMS_81411Context _context;

        public VehicleDetailsController(VCMS_81411Context context)
        {
            _context = context;
        }

        // GET: api/VehicleDetails
        [HttpGet]
        public IEnumerable<VehicleDetails> GetVehicleDetails()
        {
            return _context.VehicleDetails;
        }

        // GET: api/VehicleDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicleDetails = await _context.VehicleDetails.FindAsync(id);

            if (vehicleDetails == null)
            {
                return NotFound();
            }

            return Ok(vehicleDetails);
        }

        // PUT: api/VehicleDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleDetails([FromRoute] int id, [FromBody] VehicleDetails vehicleDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicleDetails.VehicleId)
            {
                return BadRequest();
            }

            _context.Entry(vehicleDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleDetailsExists(id))
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

        // POST: api/VehicleDetails
        [HttpPost]
        public async Task<IActionResult> PostVehicleDetails([FromBody] VehicleDetails vehicleDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.VehicleDetails.Add(vehicleDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicleDetails", new { id = vehicleDetails.VehicleId }, vehicleDetails);
        }

        // DELETE: api/VehicleDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicleDetails = await _context.VehicleDetails.FindAsync(id);
            if (vehicleDetails == null)
            {
                return NotFound();
            }

            _context.VehicleDetails.Remove(vehicleDetails);
            await _context.SaveChangesAsync();

            return Ok(vehicleDetails);
        }

        private bool VehicleDetailsExists(int id)
        {
            return _context.VehicleDetails.Any(e => e.VehicleId == id);
        }
    }
}