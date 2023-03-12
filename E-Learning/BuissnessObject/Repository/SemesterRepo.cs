using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public class SemesterRepo : ISemesterRepo
    {
        public List<Semester> GetSemesters() => SemesterDAO.GetAllSemesters();
        public Semester GetSemesterByID(String SemesterID) => SemesterDAO.GetSemesterById(SemesterID);
        public Semester CreateSemester(Semester Semester) => SemesterDAO.CreateSemester(Semester);
        public void UpdateSemester(Semester Semester) => SemesterDAO.UpdateSemester(Semester);
        public void DeleteSemester(String SemesterID) => SemesterDAO.DeleteSemester(SemesterID);
    }
}
