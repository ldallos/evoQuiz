using evoQuizQuestionMaker;
using evoQuizQuestionMaker.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace evoQuizQuestionMaker.ViewModel
{
    /// <summary>
    /// VievModel a kérdések példányosítására, a kérdések mentése módosításe itt történik
    /// </summary>
    public class QuestionCreator
    {
        //a relatív útvonal
        private static string MainPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\..\\Questions\\"));


        /// <summary>
        /// egy új kérdés lementése
        /// </summary>
        /// <param name="question">a megválaszolandó kérdés</param>
        /// <param name="badanswers">rossz válaszok listája</param>
        /// <param name="goodanswer">a helyes válasz</param>
        public static void SerializeQuestion(string question, List<string> badanswers, string goodanswer)
        {
            List<QuizQuestion> newQuestions = new List<QuizQuestion>(); //a friss kérdéslista
            //az régi kérdések betöltése (ha vannak)
            if (File.Exists(MainPath + "question.xml"))
                newQuestions = DeserializeQuestion(); 
            //az új kérdés létrehozása
            QuizQuestion myQuizQuestion = new QuizQuestion("ToDo", question, badanswers, goodanswer, 1);
            //az új kérdés listába felvétele
            newQuestions.Add(myQuizQuestion);

            //a kérdések elmentése
            SerializeQuestionList(newQuestions);
        }

        /// <summary>
        /// kérdéslista lementése
        /// </summary>
        /// <param name="questions"></param>
        public static void SerializeQuestionList(List<QuizQuestion> questions)
        {
            //a kérdések elmentése
            File.WriteAllText(MainPath + "question.xml", "");
            var mySerializer = new XmlSerializer(typeof(List<QuizQuestion>));
            using (var writer = XmlWriter.Create(MainPath + "question.xml"))
            {
                mySerializer.Serialize(writer, questions);
            }
        }

        /// <summary>
        /// a mentett listából kitörli az adott kérdést
        /// </summary>
        /// <param name="questionToDelete">törlendő kérdés</param>
        public static void DeleteQuestion(QuizQuestion questionToDelete)
        {
            List<QuizQuestion> questions = new List<QuizQuestion>();
            questions = DeserializeQuestion();
            questions.Remove(questionToDelete);
            SerializeQuestionList(questions);

        }
        public static void DeleteQuestion(string questionToDelete)
        {
            List<QuizQuestion> questions = new List<QuizQuestion>();
            questions = DeserializeQuestion();
            questions.Remove(questions.Find(x=>x.myQuestion == questionToDelete));
            SerializeQuestionList(questions);

        }

        /// <summary>
        /// az elmentett kérdések listáját betölti
        /// </summary>
        /// <returns></returns>
        public static List<string> getQuestions()
        {
            List<QuizQuestion> myquestions = DeserializeQuestion();
            List<string> questionstoget = new List<string>();
            foreach (QuizQuestion question in myquestions)
            {
                questionstoget.Add(question.myQuestion);
            }
            return questionstoget;
        }

        /// <summary>
        /// kérdéseknek fájlból való beolvasása 
        /// </summary>
        /// <returns>a kérdések listája</returns>
        public static List<QuizQuestion> DeserializeQuestion()
        {
            //a betöltött kérdések listája
            List<QuizQuestion> questions;

            string xmlInputData = File.ReadAllText(MainPath + "question.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(List<QuizQuestion>));
            using (StringReader reader = new StringReader(xmlInputData))
            {
                questions = (List<QuizQuestion>)serializer.Deserialize(reader);
            }

            return questions;
        }
    }
}