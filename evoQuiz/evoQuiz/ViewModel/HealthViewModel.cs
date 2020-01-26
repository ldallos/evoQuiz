using evoQuiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace evoQuiz.ViewModel
{
    public class HealthViewModel: WindowViewModel
    {
        private Player _myPlayer;

        public Player myPlayer
        {
            get { return _myPlayer; }
            set { _myPlayer = value; OnPropertyChanged("HealthImage"); }
        }
        public BitmapImage HealthImage
        {
            get
            {
                switch (myPlayer.Health)
                {
                    case 0:
                        return new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/HP/HP0.png", UriKind.RelativeOrAbsolute));
                    case 1:
                        return new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/HP/HP1.png", UriKind.RelativeOrAbsolute));
                    case 2:
                        return new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/HP/HP2.png", UriKind.RelativeOrAbsolute));
                    case 3:
                        return new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/HP/HP3.png", UriKind.RelativeOrAbsolute));
                    case 4:
                        return new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/HP/HP4.png", UriKind.RelativeOrAbsolute));
                    case 5:
                        return new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/HP/HP5.png", UriKind.RelativeOrAbsolute));
                    case 6:
                        return new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/HP/HP6.png", UriKind.RelativeOrAbsolute));
                    case 7:
                        return new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/HP/HP7.png", UriKind.RelativeOrAbsolute));
                    case 8:
                        return new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/HP/HP8.png", UriKind.RelativeOrAbsolute));
                    case 9:
                        return new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/HP/HP9.png", UriKind.RelativeOrAbsolute));
                    case 10:
                        return new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/HP/HP10.png", UriKind.RelativeOrAbsolute));
                    default:
                        break;
                }
                return null;
            }
        }
        public HealthViewModel(Player player)
        {
            myPlayer = player;
        }
    }
}
