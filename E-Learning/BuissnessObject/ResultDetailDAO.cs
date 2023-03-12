using DataAccess.ErrorMessage;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject
{
    public class ResultDetailDAO
    {
        public static List<ResultDetail> GetAllResultDetails()
        {
            using (var db = new ECourseDBContext())
            {
                return db.ResultDetails.ToList();
            }
        }

        public static ResultDetail GetResultDetailById(String ResultID, String QuestionID)
        {
            using (var db = new ECourseDBContext())
            {
                return db.ResultDetails.FirstOrDefault(s => s.ResultId == ResultID 
                && s.QuestionId == QuestionID);
            }
        }

        public static ResultDetail CreateResultDetail(ResultDetail ResultDetail)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetResultDetailById(ResultDetail.ResultId,ResultDetail.QuestionId) != null)
                    {
                        throw new Exception(ErrorMessage.ResultDetailError.RESULT_DETAIL_EXITED);
                    }
                    db.ResultDetails.Add(ResultDetail);
                    db.SaveChangesAsync();
                    return ResultDetail;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
        }

        public static void UpdateResultDetail(ResultDetail ResultDetail)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetResultDetailById(ResultDetail.ResultId, ResultDetail.QuestionId) == null)
                    {
                        throw new Exception(ErrorMessage.ResultDetailError.RESULT_DETAIL_IS_NOT_EXITED);
                    }
                    db.ResultDetails.Update(ResultDetail);
                    db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static void DeleteResultDetail(String ResultID, String QuestionID)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetResultDetailById(ResultID, QuestionID) == null)
                    {
                        throw new Exception(ErrorMessage.ResultDetailError.RESULT_DETAIL_IS_NOT_EXITED);
                    }
                    ResultDetail ResultDetail = GetResultDetailById(ResultID, QuestionID);
                    db.ResultDetails.Remove(ResultDetail);
                    db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
