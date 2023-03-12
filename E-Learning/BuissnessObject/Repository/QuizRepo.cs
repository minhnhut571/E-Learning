using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public class QuizRepo : IQuizRepo
    {
        public List<Quiz> GetQuizs() => QuizDAO.GetAllQuizs();
        public Quiz GetQuizByID(String QuizID) => QuizDAO.GetQuizById(QuizID);
        public Quiz CreateQuiz(Quiz Quiz) => QuizDAO.CreateQuiz(Quiz);
        public void UpdateQuiz(Quiz Quiz) => QuizDAO.UpdateQuiz(Quiz);
        public void DeleteQuiz(String QuizID) => QuizDAO.DeleteQuiz(QuizID);
    }
}
