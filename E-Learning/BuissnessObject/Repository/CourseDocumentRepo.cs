using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public class CourseDocumentRepo : ICourseDocumentRepo
    {
        public List<CourseDocument> GetCourseDocuments() => CourseDocumentDAO.GetAllCourseDocuments();
        public CourseDocument GetCourseDocumentByID(String CourseID) => CourseDocumentDAO.GetCourseDocumentById(CourseID);
        public CourseDocument CreateCourseDocument(CourseDocument CourseDocument) => CourseDocumentDAO.CreateCourseDocument(CourseDocument);
        public void UpdateCourseDocument(CourseDocument CourseDocument) => CourseDocumentDAO.UpdateCourseDocument(CourseDocument);
        public void DeleteCourseDocument(String CourseID) => CourseDocumentDAO.DeleteCourseDocument(CourseID);
    }
}
