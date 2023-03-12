using DataAccess.ErrorMessage;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject
{
    public class CourseDAO
    {
        public static List<Course> GetAllCourses()
        {
            using (var db = new ECourseDBContext())
            {
                return db.Courses.ToList();
            }
        }

        public static Course GetCourseById(String CourseID)
        {
            using (var db = new ECourseDBContext())
            {
                return db.Courses.FirstOrDefault(s => s.CourseId == CourseID);
            }
        }

        public static Course CreateCourse(Course Course)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetCourseById(Course.CourseId) != null)
                    {
                        throw new Exception(ErrorMessage.CourseError.COURSE_EXITED);
                    }
                    db.Courses.Add(Course);
                    db.SaveChangesAsync();
                    return Course;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
        }

        public static void UpdateCourse(Course Course)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetCourseById(Course.CourseId) == null)
                    {
                        throw new Exception(ErrorMessage.CourseError.COURSE_IS_NOT_EXITED);
                    }
                    db.Courses.Update(Course);
                    db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static void DeleteCourse(String CourseID)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetCourseById(CourseID) == null)
                    {
                        throw new Exception(ErrorMessage.CourseError.COURSE_IS_NOT_EXITED);
                    }
                    Course Course = GetCourseById(CourseID);
                    db.Courses.Remove(Course);
                    db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
