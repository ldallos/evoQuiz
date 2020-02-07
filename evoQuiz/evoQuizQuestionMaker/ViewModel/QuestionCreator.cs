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
            //TODO: több kérdés feltöltése


            File.WriteAllText(MainPath + "question.xml", "");

            QuizQuestion myQuizQuestion = new QuizQuestion("ToDo", question, badanswers, goodanswer, 1);

            var mySerializer = new XmlSerializer(typeof(QuizQuestion));

            using (var writer = XmlWriter.Create(MainPath + "question.xml"))
            {
                mySerializer.Serialize(writer, myQuizQuestion);
            }
        }
    }
}