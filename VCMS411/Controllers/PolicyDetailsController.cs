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
    public class PolicyDetailsController : ControllerBase
    {
        private readonly VCMS_81411Context _context;

        public PolicyDetailsController(VCMS_81411Context context)
        {
            _context = context;
        }

        // GET: api/PolicyDetails
        [HttpGet]
        public IEnumerable<PolicyDetails> GetPolicyDetails()
        {
            return _context.PolicyDetails;
        }

        // GET: api/PolicyDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPolicyDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var policyDetails = await _context.PolicyDetails.FindAsync(id);

            if (policyDetails == null)
            {
                return NotFound();
            }

            return Ok(policyDetails);
        }

        // PUT: api/PolicyDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolicyDetails([FromRoute] int id, [FromBody] PolicyDetails policyDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != policyDetails.PolicyId)
            {
                return BadRequest();
            }

            _context.Entry(policyDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolicyDetailsExists(id))
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

        // POST: api/PolicyDetails
        [HttpPost]
        public async Task<IActionResult> PostPolicyDetails([FromBody] PolicyDetails policyDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PolicyDetails.Add(policyDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPolicyDetails", new { id = policyDetails.PolicyId }, policyDetails);
        }

        // DELETE: api/PolicyDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicyDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var policyDetails = await _context.PolicyDetails.FindAsync(id);
            if (policyDetails == null)
            {
                return NotFound();
            }

            _context.PolicyDetails.Remove(policyDetails);
            await _context.SaveChangesAsync();

            return Ok(policyDetails);
        }

        private bool PolicyDetailsExists(int id)
        {
            return _context.PolicyDetails.Any(e => e.PolicyId == id);
        }
    }
}