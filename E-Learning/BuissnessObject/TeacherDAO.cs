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
    public class TeacherDAO
    {
        public static List<Teacher> GetAllTeachers()
        {
            using(var db = new ECourseDBContext())
            {
                return db.Teachers.ToList();
            }
        }

        public static Teacher GetTeacherById(String TeacherID)
        {
            using (var db = new ECourseDBContext())
            {
                return db.Teachers.FirstOrDefault(s => s.TeacherId == TeacherID && s.Status == true);
            }
        }

        public static Teacher CreateTeacher(Teacher teacher)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if(GetTeacherById(teacher.TeacherId) != null)
                    {
                        throw new Exception(ErrorMessage.TeacherError.TEACHER_EXITED);
                    }
                    db.Teachers.Add(teacher);
                    db.SaveChangesAsync();
                    return teacher;
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                
            }
        }

        public static void UpdateTeacher(Teacher teacher)
        {
            using(var db = new ECourseDBContext())
            {
                try
                {
                    if(GetTeacherById(teacher.TeacherId) == null)
                    {
                        throw new Exception(ErrorMessage.TeacherError.TEACHER_IS_NOT_EXITED);
                    }
                    db.Teachers.Update(teacher);
                    db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static void DeleteTeacher(String TeacherID)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetTeacherById(TeacherID) == null)
                    {
                        throw new Exception(ErrorMessage.TeacherError.TEACHER_IS_NOT_EXITED);
                    }
                    Teacher teacher = GetTeacherById(TeacherID);
                    db.Teachers.Remove(teacher);
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
