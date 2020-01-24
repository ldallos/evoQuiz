using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuiz.Model.Quiz
{
    public class Question
    {
        public Answer[] Answers { get; set; } = new Answer[4];
        public string QuestionText { get; set; }
        public Question()
        {

        }

    }
}
