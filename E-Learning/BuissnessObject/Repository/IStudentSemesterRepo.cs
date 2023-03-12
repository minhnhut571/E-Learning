using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public interface IStudentSemesterRepo
    {
        public List<StudentSemester> GetStudentSemesters();
        public StudentSemester GetStudentSemesterByID(String StudentSemesterID);
        public StudentSemester CreateStudentSemester(StudentSemester StudentSemester);
        public void UpdateStudentSemester(StudentSemester StudentSemester);
        public void DeleteStudentSemester(String StudentSemesterID);
    }
}
