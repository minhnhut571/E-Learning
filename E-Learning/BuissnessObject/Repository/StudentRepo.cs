using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace BuissnessObject.Repository
{
	public class StudentRepo : IStudentRepo
	{
		public List<Student> GetStudents() => StudentDAO.GetAllStudents();
		public Student GetStudentByID(String StudentID) => StudentDAO.GetStudentById(StudentID);
		public Student CreateStudent(Student student) => StudentDAO.CreateStudent(student);
		public void UpdateStudent(Student student) => StudentDAO.UpdateSutdent(student);
		public void DeleteStudent(String StudentID) => StudentDAO.DeleteStudent(StudentID);
	}
}
