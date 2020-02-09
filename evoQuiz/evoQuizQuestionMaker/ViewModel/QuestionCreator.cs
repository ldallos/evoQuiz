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
    class QuestionCreator
    {
        //a relatív útvonal
        private string MainPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\..\\Questions\\"));


        /// <summary>
        /// a kérdés lementése
        /// </summary>
        /// <param name="question">a megválaszolandó kérdés</param>
        /// <param name="badanswers">rossz válaszok listája</param>
        /// <param name="goodanswer">a helyes válasz</param>
        public void SerializeQuestion(string question, List<string> badanswers, string goodanswer)
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
            File.WriteAllText(MainPath + "question.xml", "");
            var mySerializer = new XmlSerializer(typeof(List<QuizQuestion>));
            using (var writer = XmlWriter.Create(MainPath + "question.xml"))
            {
                mySerializer.Serialize(writer, newQuestions);
            }
        }

        /// <summary>
        /// kérdéseknek fájlból való beolvasása 
        /// </summary>
        /// <returns>a kérdések listája</returns>
        public List<QuizQuestion> DeserializeQuestion()
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