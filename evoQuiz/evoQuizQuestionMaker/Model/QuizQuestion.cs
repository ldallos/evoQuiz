using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuizQuestionMaker.Model
{
    public class QuizQuestion
    {
        public string myQuestionTopic { get; set; }
        public string myQuestion { get; set; }
        public List<string> myWrongAnswers { get; set; } = new List<string>();
        public string myRightAnswer { get; set; }
        public int myDifficulty { get; set; }

        public QuizQuestion(string questionTopic, string question, List<string> wrongAnswers, string rightAnswer, int difficulty)
        {
            myQuestionTopic = questionTopic;          //kérdés témaköre (pl: matematika, fizika, irodalom, történelem...)
            myQuestion = question;                    //a megválaszolandó kérdés
            myWrongAnswers = wrongAnswers;      //a kérdéshez tartozó rossz válaszok listája (min 3mat érdemes rakni mindegyikhez)
            myRightAnswer = rightAnswer;              //a helyes válasz
            myDifficulty = difficulty;                   //a kérdés nehézségi szintje
        }

        /// <summary>
        /// paraméter nélküli konstruktor a szérializáláshoz
        /// </summary>
        public QuizQuestion() { }


    }
}
