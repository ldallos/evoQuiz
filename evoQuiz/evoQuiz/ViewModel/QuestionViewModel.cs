using evoQuiz.Model.Quiz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuiz.ViewModel
{
    public class QuestionViewModel : WindowViewModel
    {
        public Question MyQuestion { get; set; }
        public string QuestionText { get { return MyQuestion.QuestionText; } }
        public string Answer1Text { get { return MyQuestion.Answers[0].AnswerText; } }
        public string Answer2Text { get { return MyQuestion.Answers[1].AnswerText; } }
        public string Answer3Text { get { return MyQuestion.Answers[2].AnswerText; } }
        public string Answer4Text { get { return MyQuestion.Answers[3].AnswerText; } }

        public QuestionViewModel(Question question)
        {
            MyQuestion = question;
        }
    }
}
