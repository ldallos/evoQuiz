using evoQuiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuizQuestionMaker.Model
{
    class QuestionTopic
    {
        /// <summary>
        /// A szörnyek a típusukkal megegyező kérdések közül fognak válogatni
        /// </summary>
        public QuestionTopic()
        {
            string myType;
            List<QuizQuestion> myQuestions;
        }

        #region GetSet
        public string myType { get; set; }
        public List<QuizQuestion> myQuestions { get; set; }

        #endregion

        /// <summary>
        /// hozzáadja a témakör kérdéslistához az aktuális kérdést
        /// </summary>
        /// <param name="question">a kérdés</param>
        public void addQuizQuestion(QuizQuestion question)
        {
            myQuestions.Add(question);
        }

        //TODO: removefromquestions?
    }
}
