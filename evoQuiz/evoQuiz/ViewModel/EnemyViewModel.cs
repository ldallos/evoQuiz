using evoQuiz.Model;
using evoQuiz.Model.Enemies;
using evoQuiz.Model.Quiz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace evoQuiz.ViewModel
{
    public class EnemyViewModel: IViewModel
    {
        public Enemy myEnemy { get; set; }
        public int PosX { get { return myEnemy.PositionX; } set { myEnemy.PositionX = value; OnPropertyChanged("PosX"); } }
        public int PosY { get { return myEnemy.PositionY; } set { myEnemy.PositionY = value; OnPropertyChanged("PosY"); } }
        public int PosZ { get { return myEnemy.PositionZ; } set { myEnemy.PositionZ = value; OnPropertyChanged("PosZ"); } }
        public int Size { get { return Parent.MapScale; } }
        public BitmapImage Skin
        {
            get
            {
                if (myEnemy is Skeleton)
                {
                    return new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/skeleton.png", UriKind.RelativeOrAbsolute));
                }
                else return null;
            }
        }
        public MainViewModel Parent { get; set; }
        public EnemyViewModel(Enemy enemy, MainViewModel parent)
        {
            myEnemy = enemy;
            Parent = parent;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
