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
    public class StudentDAO
    {
        public static List<Student> GetAllStudents()
        {
            using(var db = new ECourseDBContext())
            {
                return db.Students.ToList();
            }
        }

        public static Student GetStudentById(String StudentID)
        {
            using (var db = new ECourseDBContext())
            {
                return db.Students.FirstOrDefault(s => s.StudentId == StudentID && s.Status == true);
            }
        }

        public static Student CreateStudent(Student student)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if(GetStudentById(student.StudentId) != null)
                    {
                        throw new Exception(ErrorMessage.StudentError.STUDENT_EXITED);
                    }
                    db.Students.Add(student);
                    db.SaveChangesAsync();
                    return student;
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                
            }
        }

        public static void UpdateSutdent(Student student)
        {
            using(var db = new ECourseDBContext())
            {
                try
                {
                    if(GetStudentById(student.StudentId) == null)
                    {
                        throw new Exception(ErrorMessage.StudentError.STUDENT_IS_NOT_EXITED);
                    }
                    db.Students.Update(student);
                    db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static void DeleteStudent(String StudentID)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetStudentById(StudentID) == null)
                    {
                        throw new Exception(ErrorMessage.StudentError.STUDENT_IS_NOT_EXITED);
                    }
                    Student student = GetStudentById(StudentID);
                    db.Students.Remove(student);
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
