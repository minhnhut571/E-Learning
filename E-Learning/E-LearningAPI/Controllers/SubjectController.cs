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
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectRepo SubjectRepo = new SubjectRepo();

        public SubjectsController()
        {
        }

        // GET: api/Subjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetSubjects()
        {
            return SubjectRepo.GetSubjects();
        }

        // GET: api/Subjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubject(string id)
        {
            var Subject = SubjectRepo.GetSubjectByID(id);

            if (Subject == null)
            {
                return NotFound();
            }

            return Subject;
        }

        // PUT: api/Subjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubject(string id, Subject Subject)
        {
            if (id != Subject.SubjectId)
            {
                return BadRequest();
            }

            try
            {
                SubjectRepo.UpdateSubject(Subject);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectExists(id))
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

        // POST: api/Subjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Subject>> PostSubject(Subject Subject)
        {
            try
            {
                return Ok(SubjectRepo.CreateSubject(Subject));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // DELETE: api/Subjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(string id)
        {
            var Subject = SubjectRepo.GetSubjectByID(id);
            if (Subject == null)
            {
                return NotFound();
            }

            SubjectRepo.DeleteSubject(id);

            return NoContent();
        }

        private bool SubjectExists(string id)
        {
            return SubjectRepo.GetSubjects().Any(e => e.SubjectId == id);
        }
    }
}
