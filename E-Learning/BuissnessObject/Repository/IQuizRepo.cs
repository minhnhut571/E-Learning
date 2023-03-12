﻿using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject.Repository
{
    public interface IQuizRepo
    {
        public List<Quiz> GetQuizs();
        public Quiz GetQuizByID(String QuizID);
        public Quiz CreateQuiz(Quiz quiz);
        public void UpdateQuiz(Quiz quiz);
        public void DeleteQuiz(String QuizID);
    }
}
