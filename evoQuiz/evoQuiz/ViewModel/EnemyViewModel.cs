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
    public class EnemyViewModel: TileViewModel
    {
        public Enemy myEnemy { get; set; }
        public override int PosX { get { return myEnemy.PositionX; } set { myEnemy.PositionX = value; OnPropertyChanged("PosX"); } }
        public override int PosY { get { return myEnemy.PositionY; } set { myEnemy.PositionY = value; OnPropertyChanged("PosY"); } }
        public override int PosZ { get { return myEnemy.PositionZ; } set { myEnemy.PositionZ = value; OnPropertyChanged("PosZ"); } }
        public override int Size { get { return Parent.MapScale; } set { } }
        public override BitmapImage Skin
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
    }
}
