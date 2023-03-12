using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public class QuizOptionRepo : IQuizOptionRepo
    {
        public List<QuizOption> GetQuizOptions() => QuizOptionDAO.GetAllQuizOptions();
        public QuizOption GetQuizOptionByID(String QuizOptionID) => QuizOptionDAO.GetQuizOptionById(QuizOptionID);
        public QuizOption CreateQuizOption(QuizOption QuizOption) => QuizOptionDAO.CreateQuizOption(QuizOption);
        public void UpdateQuizOption(QuizOption QuizOption) => QuizOptionDAO.UpdateQuizOption(QuizOption);
        public void DeleteQuizOption(String QuizOptionID) => QuizOptionDAO.DeleteQuizOption(QuizOptionID);
    }
}
