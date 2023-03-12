using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using BuissnessObject.Repository;

namespace E_LearningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajorsController : ControllerBase
    {
        private readonly IMajorRepo MajorRepo = new MajorRepo();

        public MajorsController()
        {
        }

        // GET: api/Majors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Major>>> GetMajors()
        {
            return MajorRepo.GetMajors();
        }

        // GET: api/Majors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Major>> GetMajor(string id)
        {
            var Major = MajorRepo.GetMajorByID(id);

            if (Major == null)
            {
                return NotFound();
            }

            return Major;
        }

        // PUT: api/Majors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMajor(string id, Major Major)
        {
            if (id != Major.MajorId)
            {
                return BadRequest();
            }

            try
            {
                MajorRepo.UpdateMajor(Major);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MajorExists(id))
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

        // POST: api/Majors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Major>> PostMajor(Major Major)
        {
            try
            {
                MajorRepo.CreateMajor(Major);
            }
            catch (DbUpdateException)
            {
                if (MajorExists(Major.MajorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMajor", new { id = Major.MajorId }, Major);
        }

        // DELETE: api/Majors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMajor(string id)
        {
            var Major = MajorRepo.GetMajorByID(id);
            if (Major == null)
            {
                return NotFound();
            }

            MajorRepo.DeleteMajor(id);

            return NoContent();
        }

        private bool MajorExists(string id)
        {
            return MajorRepo.GetMajors().Any(e => e.MajorId == id);
        }
    }
}
