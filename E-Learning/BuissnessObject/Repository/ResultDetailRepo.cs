using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public class ResultDetailRepo : IResultDetailRepo
    {
        public List<ResultDetail> GetResultDetails() => ResultDetailDAO.GetAllResultDetails();
        public ResultDetail GetResultDetailByID(String ResultID, String QuestionID) => ResultDetailDAO.GetResultDetailById(ResultID, QuestionID);
        public ResultDetail CreateResultDetail(ResultDetail ResultDetail) => ResultDetailDAO.CreateResultDetail(ResultDetail);
        public void UpdateResultDetail(ResultDetail ResultDetail) => ResultDetailDAO.UpdateResultDetail(ResultDetail);
        public void DeleteResultDetail(String ResultID, String QuestionID) => ResultDetailDAO.DeleteResultDetail(ResultID, QuestionID);
    }
}
