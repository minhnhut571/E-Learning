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
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepo CourseRepo = new CourseRepo();

        public CoursesController()
        {
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return CourseRepo.GetCourses();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(string id)
        {
            var Course = CourseRepo.GetCourseByID(id);

            if (Course == null)
            {
                return NotFound();
            }

            return Course;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(string id, Course Course)
        {
            if (id != Course.CourseId)
            {
                return BadRequest();
            }

            try
            {
                CourseRepo.UpdateCourse(Course);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
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

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course Course)
        {
            try
            {
                CourseRepo.CreateCourse(Course);
            }
            catch (DbUpdateException)
            {
                if (CourseExists(Course.CourseId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCourse", new { id = Course.CourseId }, Course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(string id)
        {
            var Course = CourseRepo.GetCourseByID(id);
            if (Course == null)
            {
                return NotFound();
            }

            CourseRepo.DeleteCourse(id);

            return NoContent();
        }

        private bool CourseExists(string id)
        {
            return CourseRepo.GetCourses().Any(e => e.CourseId == id);
        }
    }
}
