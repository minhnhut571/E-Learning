using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public class SubjectRepo : ISubjectRepo
    {
        public List<Subject> GetSubjects() => SubjectDAO.GetAllSubjects();
        public Subject GetSubjectByID(String SubjectID) => SubjectDAO.GetSubjectById(SubjectID);
        public Subject CreateSubject(Subject Subject) => SubjectDAO.CreateSubject(Subject);
        public void UpdateSubject(Subject Subject) => SubjectDAO.UpdateSubject(Subject);
        public void DeleteSubject(String SubjectID) => SubjectDAO.DeleteSubject(SubjectID);
    }
}
