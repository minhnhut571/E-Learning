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
    public class ResultDAO
    {
        public static List<Result> GetAllResults()
        {
            using (var db = new ECourseDBContext())
            {
                return db.Results.ToList();
            }
        }

        public static Result GetResultById(String ResultID)
        {
            using (var db = new ECourseDBContext())
            {
                return db.Results.FirstOrDefault(s => s.ResultId == ResultID);
            }
        }

        public static Result CreateResult(Result Result)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetResultById(Result.ResultId) != null)
                    {
                        throw new Exception(ErrorMessage.ResultError.RESULT_EXITED);
                    }
                    db.Results.Add(Result);
                    db.SaveChangesAsync();
                    return Result;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
        }

        public static void UpdateResult(Result Result)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetResultById(Result.ResultId) == null)
                    {
                        throw new Exception(ErrorMessage.ResultError.RESULT_IS_NOT_EXITED);
                    }
                    db.Results.Update(Result);
                    db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static void DeleteResult(String ResultID)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetResultById(ResultID) == null)
                    {
                        throw new Exception(ErrorMessage.ResultError.RESULT_IS_NOT_EXITED);
                    }
                    Result Result = GetResultById(ResultID);
                    db.Results.Remove(Result);
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
