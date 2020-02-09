using evoQuizQuestionMaker.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace evoQuizQuestionMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenQuestionPage(object sender, RoutedEventArgs e)
        {
            Main.Content = new QuestionMaker();
        }

        private void OpenTopicPage(object sender, RoutedEventArgs e)
        {
            Main.Content = new TopicHandler();
        }
    }
}
