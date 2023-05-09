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
    public class ClaimDetailsController : ControllerBase
    {
        private readonly VCMS_81411Context _context;

        public ClaimDetailsController(VCMS_81411Context context)
        {
            _context = context;
        }

        // GET: api/ClaimDetails
        [HttpGet]
        public IEnumerable<ClaimDetails> GetClaimDetails()
        {
            return _context.ClaimDetails;
        }

        // GET: api/ClaimDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClaimDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var claimDetails = await _context.ClaimDetails.FindAsync(id);

            if (claimDetails == null)
            {
                return NotFound();
            }

            return Ok(claimDetails);
        }

        // PUT: api/ClaimDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClaimDetails([FromRoute] int id, [FromBody] ClaimDetails claimDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != claimDetails.ClaimId)
            {
                return BadRequest();
            }

            _context.Entry(claimDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClaimDetailsExists(id))
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

        // POST: api/ClaimDetails
        [HttpPost]
        public async Task<IActionResult> PostClaimDetails([FromBody] ClaimDetails claimDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ClaimDetails.Add(claimDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClaimDetails", new { id = claimDetails.ClaimId }, claimDetails);
        }

        // DELETE: api/ClaimDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClaimDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var claimDetails = await _context.ClaimDetails.FindAsync(id);
            if (claimDetails == null)
            {
                return NotFound();
            }

            _context.ClaimDetails.Remove(claimDetails);
            await _context.SaveChangesAsync();

            return Ok(claimDetails);
        }

        private bool ClaimDetailsExists(int id)
        {
            return _context.ClaimDetails.Any(e => e.ClaimId == id);
        }
    }
}