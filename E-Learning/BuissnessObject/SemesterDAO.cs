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
    public class SemesterDAO
    {
        public static List<Semester> GetAllSemesters()
        {
            using (var db = new ECourseDBContext())
            {
                return db.Semesters.ToList();
            }
        }

        public static Semester GetSemesterById(String SemesterID)
        {
            using (var db = new ECourseDBContext())
            {
                return db.Semesters.FirstOrDefault(s => s.SemesterId == SemesterID);
            }
        }

        public static Semester CreateSemester(Semester Semester)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetSemesterById(Semester.SemesterId) != null)
                    {
                        throw new Exception(ErrorMessage.SemesterError.SEMESTER_EXITED);
                    }
                    db.Semesters.Add(Semester);
                    db.SaveChangesAsync();
                    return Semester;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
        }

        public static void UpdateSemester(Semester Semester)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetSemesterById(Semester.SemesterId) == null)
                    {
                        throw new Exception(ErrorMessage.SemesterError.SEMESTER_IS_NOT_EXITED);
                    }
                    db.Semesters.Update(Semester);
                    db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static void DeleteSemester(String SemesterID)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetSemesterById(SemesterID) == null)
                    {
                        throw new Exception(ErrorMessage.SemesterError.SEMESTER_IS_NOT_EXITED);
                    }
                    Semester Semester = GetSemesterById(SemesterID);
                    db.Semesters.Remove(Semester);
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
