using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public interface IResultDetailRepo
    {
        public List<ResultDetail> GetResultDetails();
        public ResultDetail GetResultDetailByID(String ResultID, String QuestionID);
        public ResultDetail CreateResultDetail(ResultDetail ResultDetail);
        public void UpdateResultDetail(ResultDetail ResultDetail);
        public void DeleteResultDetail(String ResultID, String QuestionID);
    }
}
