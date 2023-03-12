using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public class CourseRepo : ICourseRepo
    {
        public List<Course> GetCourses() => CourseDAO.GetAllCourses();
        public Course GetCourseByID(String CourseID) => CourseDAO.GetCourseById(CourseID);
        public Course CreateCourse(Course Course) => CourseDAO.CreateCourse(Course);
        public void UpdateCourse(Course Course) => CourseDAO.UpdateCourse(Course);
        public void DeleteCourse(String CourseID) => CourseDAO.DeleteCourse(CourseID);
    }
}
