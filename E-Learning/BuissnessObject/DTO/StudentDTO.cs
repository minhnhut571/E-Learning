using System;

namespace BuissnessObject.DTO
{
	public class StudentDTO
	{
		public string StudentId { get; set; }
		public string StudentName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
		public DateTime DateOfBirth { get; set; }
		public bool Status { get; set; }
		public DateTime CreateDate { get; set; }
	}
}
