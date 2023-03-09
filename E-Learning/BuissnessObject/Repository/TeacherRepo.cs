using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public class TeacherRepo : ITeacherRepo
    {
        public List<Teacher> GetTeachers() => TeacherDAO.GetAllTeachers();
        public Teacher GetTeacherByID(String TeacherID) => TeacherDAO.GetTeacherById(TeacherID);
        public Teacher CreateTeacher(Teacher teacher) => TeacherDAO.CreateTeacher(teacher);
        public void UpdateTeacher(Teacher teacher) => TeacherDAO.UpdateTeacher(teacher);
        public void DeleteTeacher(String TeacherID) => TeacherDAO.DeleteTeacher(TeacherID);
    }
}
