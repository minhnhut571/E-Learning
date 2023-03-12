using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public interface ICourseDocumentRepo
    {
        public List<CourseDocument> GetCourseDocuments();
        public CourseDocument GetCourseDocumentByID(String CourseID);
        public CourseDocument CreateCourseDocument(CourseDocument CourseDocument);
        public void UpdateCourseDocument(CourseDocument CourseDocument);
        public void DeleteCourseDocument(String CourseID);
    }
}
