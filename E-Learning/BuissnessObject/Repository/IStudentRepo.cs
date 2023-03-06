using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public interface IStudentRepo
    {
        public List<Student> GetStudents();
        public Student GetStudentByID(String StudentID);
        public Student CreateStudent(Student student);
        public void UpdateStudent(Student student);
        public void DeleteStudent(String StudentID);
    }
}
