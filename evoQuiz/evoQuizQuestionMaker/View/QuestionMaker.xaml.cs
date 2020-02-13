using evoQuizQuestionMaker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using evoQuizQuestionMaker.Model;   //a betöltéshez 

namespace evoQuizQuestionMaker.View
{
    /// <summary>
    /// Interaction logic for QuestionMaker.xaml
    /// </summary>
    public partial class QuestionMaker : Page
    {
        List<string> tempbadanswers;
        QuestionCreator question;
        List<string> questionstrings;
        public QuestionMaker()
        {
            InitializeComponent();
            tempbadanswers = new List<string>();

            questionstrings = QuestionCreator.getQuestions();
            Questions.ItemsSource = questionstrings;

        }

        #region Buttons

        /// <summary>
        /// rossz válaszok listáját feltöltő gomb
        /// </summary>
        private void Add_BadAnswer(object sender, RoutedEventArgs e)
        {
            tempbadanswers.Add(Bad_Answer.Text);
            Bad_Answer_List.ItemsSource = tempbadanswers;
            Bad_Answer_List.Items.Refresh();
            Bad_Answer.Clear();
        }

        /// <summary>
        /// a kiválasztott rossz választ törli a listából
        /// </summary>
        private void Del_BadAnswer(object sender, RoutedEventArgs e)
        {
            tempbadanswers.Remove(Bad_Answer_List.SelectedItem.ToString());
            Bad_Answer_List.ItemsSource = tempbadanswers;
            Bad_Answer_List.Items.Refresh();
        }

        /// <summary>
        /// a kvízkérdés paramétereinek megadása után ezzel a gombbal mented el az xml fájlba
        /// </summary>
        private void Create_Question(object sender, RoutedEventArgs e)
        {
            QuestionCreator.SerializeQuestion(Question.Text, tempbadanswers, Good_Answer.Text);
            
            //frissíti a létező kérdések listáját
            questionstrings = QuestionCreator.getQuestions();
            Questions.ItemsSource = questionstrings;
            Questions.Items.Refresh();
            
            Message.Content = "A kérdés '" + Question.Text + "' sikeresen elmentve!";

            //ablakok ürítése
            tempbadanswers.Clear();
            Bad_Answer_List.ItemsSource = tempbadanswers;
            Bad_Answer_List.Items.Refresh();

            Question.Clear();
            Good_Answer.Clear();
            Bad_Answer.Clear();
        }

        #endregion

        /// <summary>
        /// betölti a megváltoztatandó kérdés paramétereit, majd törli a régi kérdést
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            Load_Click(sender, e);
            DeleteQuestion_Click(sender, e);
        }

        /// <summary>
        /// betölti a kiválasztott kérdés paramétereit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Load_Click(object sender, RoutedEventArgs e)
        {

            List<QuizQuestion> myquestions = QuestionCreator.DeserializeQuestion();
            QuizQuestion myquestion = myquestions.Find(x => x.myQuestion == Questions.SelectedItem.ToString());

            Question.Text = myquestion.myQuestion;
            Good_Answer.Text = myquestion.myRightAnswer;

            tempbadanswers = myquestion.myWrongAnswers;
            Bad_Answer_List.ItemsSource = tempbadanswers;
            Bad_Answer_List.Items.Refresh();
        }

        /// <summary>
        /// kitörli a kiválasztott kérdést
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteQuestion_Click(object sender, RoutedEventArgs e)
        {
            QuestionCreator.DeleteQuestion(Questions.SelectedItem.ToString());

            //frissíti a létező kérdések listáját
            questionstrings = QuestionCreator.getQuestions();
            Questions.ItemsSource = questionstrings;
            Questions.Items.Refresh();
        }

    }
}
