using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public class SubjectItemRepo : ISubjectItemRepo
    {
        public List<SubjectItem> GetSubjectItems() => SubjectItemDAO.GetAllSubjectItems();
        public SubjectItem GetSubjectItemByID(String SubjectID, String StudentID) => SubjectItemDAO.GetSubjectItemById(SubjectID, StudentID);
        public SubjectItem CreateSubjectItem(SubjectItem SubjectItem) => SubjectItemDAO.CreateSubjectItem(SubjectItem);
        public void UpdateSubjectItem(SubjectItem SubjectItem) => SubjectItemDAO.UpdateSubjectItem(SubjectItem);
        public void DeleteSubjectItem(String SubjectID, String StudentID) => SubjectItemDAO.DeleteSubjectItem(SubjectID, StudentID);
    }
}
