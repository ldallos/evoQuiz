using System;
using evoQuiz.ViewModel;
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
using System.Windows.Media.Animation;
using System.Media;
using System.Diagnostics;

namespace evoQuiz
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {

        public MainMenu()
        {
            InitializeComponent();

            SoundsViewModel.StartMenuMusic();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CreditsButton_Click(object sender, RoutedEventArgs e)
        {
            Credits page = new Credits();
            this.NavigationService.Navigate(page);
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            SoundsViewModel.StopMenuMusic();

            Game page = new Game();
            page.DataContext = new MainViewModel(this.ActualHeight, this.ActualWidth);
            //page.Show();
            this.NavigationService.Navigate(page);
        }

        private void QuestionEditorButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(@"D:\evoQuiz\evoQuiz\evoQuizQuestionMaker\bin\Release\evoQuizQuestionMaker.exe");
        }

        private void MapEditorButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(@"D:\evoQuiz\evoQuiz\evoQuizMapMaker\bin\Release\evoQuizMapMaker.exe");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation fadeInAnimation = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(2));
            MainGrid.BeginAnimation(Image.OpacityProperty, fadeInAnimation);
        }
    }
}
