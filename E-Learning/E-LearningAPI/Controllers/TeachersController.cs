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
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepo TeacherRepo = new TeacherRepo();

        public TeachersController()
        {
        }

        // GET: api/Teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        {
            return TeacherRepo.GetTeachers();
        }

        // GET: api/Teachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(string id)
        {
            var Teacher = TeacherRepo.GetTeacherByID(id);

            if (Teacher == null)
            {
                return NotFound();
            }

            return Teacher;
        }

        // PUT: api/Teachers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher(string id, Teacher Teacher)
        {
            if (id != Teacher.TeacherId)
            {
                return BadRequest();
            }

            try
            {
                TeacherRepo.UpdateTeacher(Teacher);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(id))
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

        // POST: api/Teachers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Teacher>> PostTeacher(Teacher Teacher)
        {
            try
            {
                TeacherRepo.CreateTeacher(Teacher);
            }
            catch (DbUpdateException)
            {
                if (TeacherExists(Teacher.TeacherId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTeacher", new { id = Teacher.TeacherId }, Teacher);
        }

        // DELETE: api/Teachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(string id)
        {
            var Teacher = TeacherRepo.GetTeacherByID(id);
            if (Teacher == null)
            {
                return NotFound();
            }

            TeacherRepo.DeleteTeacher(id);

            return NoContent();
        }

        private bool TeacherExists(string id)
        {
            return TeacherRepo.GetTeachers().Any(e => e.TeacherId == id);
        }
    }
}
