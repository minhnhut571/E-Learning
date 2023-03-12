using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public class StudentSemesterSemesterRepo : IStudentSemesterRepo
    {
        public List<StudentSemester> GetStudentSemesters() => StudentSemesterDAO.GetAllStudentSemesters();
        public StudentSemester GetStudentSemesterByID(String StudentSemesterID) => StudentSemesterDAO.GetStudentSemesterById(StudentSemesterID);
        public StudentSemester CreateStudentSemester(StudentSemester StudentSemester) => StudentSemesterDAO.CreateStudentSemester(StudentSemester);
        public void UpdateStudentSemester(StudentSemester StudentSemester) => StudentSemesterDAO.UpdateStudentSemester(StudentSemester);
        public void DeleteStudentSemester(String StudentSemesterID) => StudentSemesterDAO.DeleteStudentSemester(StudentSemesterID);
    }
}
