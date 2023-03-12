using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public interface ICourseRepo
    {
        public List<Course> GetCourses();
        public Course GetCourseByID(String CourseID);
        public Course CreateCourse(Course Course);
        public void UpdateCourse(Course Course);
        public void DeleteCourse(String CourseID);
    }
}
