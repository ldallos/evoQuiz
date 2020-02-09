using evoQuiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace evoQuiz.ViewModel
{
    public class HealthViewModel: ViewModelBase
    {
        private Character _myCharacter;

        public Character myCharacter
        {
            get { return _myCharacter; }
            set { _myCharacter = value; OnPropertyChanged("HealthImage"); }
        }

        private BitmapImage _myHealthImage;

        public BitmapImage HealthImage
        {
            get { return _myHealthImage; }
            set { _myHealthImage = value; OnPropertyChanged("HealthImage"); }
        }

        public HealthViewModel(Character character)
        {
            myCharacter = character;
            Update();
        }

        public void Update()
        {
            switch (myCharacter.Health)
            {
                case 0:
                    HealthImage= new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/HP/HP0.png", UriKind.RelativeOrAbsolute));
                    break;
                case 1:
                    HealthImage= new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/HP/HP1.png", UriKind.RelativeOrAbsolute));
                    break;
                case 2:
                    HealthImage = new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/HP/HP2.png", UriKind.RelativeOrAbsolute));
                    break;
                case 3:
                    HealthImage = new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/HP/HP3.png", UriKind.RelativeOrAbsolute));
                    break;
                case 4:
                    HealthImage = new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/HP/HP4.png", UriKind.RelativeOrAbsolute));
                    break;
                case 5:
                    HealthImage = new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/HP/HP5.png", UriKind.RelativeOrAbsolute));
                    break;
                case 6:
                    HealthImage = new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/HP/HP6.png", UriKind.RelativeOrAbsolute));
                    break;
                case 7:
                    HealthImage = new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/HP/HP7.png", UriKind.RelativeOrAbsolute));
                    break;
                case 8:
                    HealthImage = new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/HP/HP8.png", UriKind.RelativeOrAbsolute));
                    break;
                case 9:
                    HealthImage = new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/HP/HP9.png", UriKind.RelativeOrAbsolute));
                    break;
                case 10:
                    HealthImage = new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/HP/HP10.png", UriKind.RelativeOrAbsolute));
                    break;
                default:
                    break;
            }
        }
    }
}
