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
    public class QuizQuestionDAO
    {
        public static List<QuizQuestion> GetAllQuizQuestions()
        {
            using (var db = new ECourseDBContext())
            {
                return db.QuizQuestions.ToList();
            }
        }

        public static QuizQuestion GetQuizQuestionById(String QuizQuestionID)
        {
            using (var db = new ECourseDBContext())
            {
                return db.QuizQuestions.FirstOrDefault(s => s.QuestionId == QuizQuestionID);
            }
        }

        public static QuizQuestion CreateQuizQuestion(QuizQuestion QuizQuestion)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetQuizQuestionById(QuizQuestion.QuestionId) != null)
                    {
                        throw new Exception(ErrorMessage.QuizQuestionError.QUIZ_QUESTION_EXITED);
                    }
                    db.QuizQuestions.Add(QuizQuestion);
                    db.SaveChangesAsync();
                    return QuizQuestion;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
        }

        public static void UpdateQuizQuestion(QuizQuestion QuizQuestion)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetQuizQuestionById(QuizQuestion.QuestionId) == null)
                    {
                        throw new Exception(ErrorMessage.QuizQuestionError.QUIZ_QUESTION_IS_NOT_EXITED);
                    }
                    db.QuizQuestions.Update(QuizQuestion);
                    db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static void DeleteQuizQuestion(String QuizQuestionID)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetQuizQuestionById(QuizQuestionID) == null)
                    {
                        throw new Exception(ErrorMessage.QuizQuestionError.QUIZ_QUESTION_IS_NOT_EXITED);
                    }
                    QuizQuestion QuizQuestion = GetQuizQuestionById(QuizQuestionID);
                    db.QuizQuestions.Remove(QuizQuestion);
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
