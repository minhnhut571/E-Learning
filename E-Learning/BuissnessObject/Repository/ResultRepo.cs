using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public class ResultRepo : IResultRepo
    {
        public List<Result> GetResults() => ResultDAO.GetAllResults();
        public Result GetResultByID(String ResultID) => ResultDAO.GetResultById(ResultID);
        public Result CreateResult(Result Result) => ResultDAO.CreateResult(Result);
        public void UpdateResult(Result Result) => ResultDAO.UpdateResult(Result);
        public void DeleteResult(String ResultID) => ResultDAO.DeleteResult(ResultID);
    }
}
