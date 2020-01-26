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
            Game page = new Game();
            page.DataContext = new MainViewModel();
            //page.Show();
            this.NavigationService.Navigate(page);
        }

        private void OptionsButton_Click(object sender, RoutedEventArgs e)
        {
            Options page = new Options();
            this.NavigationService.Navigate(page);
        }

        private void EditorButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation fadeInAnimation = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(2));
            MainGrid.BeginAnimation(Image.OpacityProperty, fadeInAnimation);
        }
    }
}
