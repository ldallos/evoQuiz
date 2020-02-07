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

namespace evoQuizQuestionMaker.View
{
    /// <summary>
    /// Interaction logic for QuestionMaker.xaml
    /// </summary>
    public partial class QuestionMaker : Page
    {
        List<string> tempbadanswers;
        QuestionCreator question;
        public QuestionMaker()
        {
            InitializeComponent();
            tempbadanswers = new List<string>();

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
            question = new QuestionCreator();
            question.SerializeQuestion(Question.Text, tempbadanswers, Good_Answer.Text);
            
        }

        #endregion

    }
}
