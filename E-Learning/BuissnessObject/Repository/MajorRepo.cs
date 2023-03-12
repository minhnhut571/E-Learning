using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public class MajorRepo : IMajorRepo
    {
        public List<Major> GetMajors() => MajorDAO.GetAllMajors();
        public Major GetMajorByID(String MajorID) => MajorDAO.GetMajorById(MajorID);
        public Major CreateMajor(Major Major) => MajorDAO.CreateMajor(Major);
        public void UpdateMajor(Major Major) => MajorDAO.UpdateMajor(Major);
        public void DeleteMajor(String MajorID) => MajorDAO.DeleteMajor(MajorID);
    }
}
