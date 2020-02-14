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
            set { _myCharacter = value; OnPropertyChanged("HealthImage");}
        }

        private BitmapImage _myHealthImage;
        public BitmapImage HealthImage
        {
            get { return _myHealthImage; }
            set { _myHealthImage = value; OnPropertyChanged("HealthImage"); }
        }

        private double myHitOpacity;
        public double HitOverlayOpacity
        {
            get { return myHitOpacity; }
            set { myHitOpacity = value; OnPropertyChanged("HitOverlayOpacity"); }
        }

        private double myHealOpacity;
        public double HealOverlayOpacity
        {
            get { return myHealOpacity; }
            set { myHealOpacity = value; OnPropertyChanged("HealOverlayOpacity"); }
        }

        public HealthViewModel(Character character)
        {
            HitOverlayOpacity = 0;
            HealOverlayOpacity = 0;
            myCharacter = character;
            Actions.Add(UpdateHealth);
        }
        public HealthViewModel()
        {
            Actions.Add(UpdateHealth);
        }

        int TempHealth;
        private void UpdateHealth()
        {
            if (myCharacter is null)
            {
                return;
            }
            if (myCharacter.Health == TempHealth)
            {
                return;
            }

            if (myCharacter.Health < TempHealth)
            {
                Hit();
            }

            if (myCharacter.Health > TempHealth)
            {
                Heal();
            }

            TempHealth = myCharacter.Health;

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

        private void Hit()
        {
            Actions.Add(Show);

            void Show()
            {
                HitOverlayOpacity += 0.005;

                if (HitOverlayOpacity >= 1)
                {
                    HitOverlayOpacity = 1;
                    ActionsToStop.Add(Show);
                    Actions.Add(Hide);
                }
            }

            void Hide()
            {
                HitOverlayOpacity -= 0.005;

                if (HitOverlayOpacity <= 0)
                {
                    HitOverlayOpacity = 0;
                    ActionsToStop.Add(Hide);     
                }
            }
            
        }

        private void Heal()
        {
            Actions.Add(Show);

            void Show()
            {
                HealOverlayOpacity += 0.005;

                if (HealOverlayOpacity >= 1)
                {
                    HealOverlayOpacity = 1;
                    ActionsToStop.Add(Show);
                    Actions.Add(Hide);
                }
            }

            void Hide()
            {
                HealOverlayOpacity -= 0.005;

                if (HealOverlayOpacity <= 0)
                {
                    HealOverlayOpacity = 0;
                    ActionsToStop.Add(Hide);
                }
            }

        }
    }
}
