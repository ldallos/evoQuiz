using evoQuiz.Model;
using evoQuiz.Model.Enemies;
using System;
using System.Linq;
using System.Windows.Media.Imaging;

namespace evoQuiz.ViewModel
{
    public class EnemyViewModel : TileViewModel
    {
        public Enemy myEnemy { get; set; }
        public override int PosX { get { return myEnemy.PositionX; } set { myEnemy.PositionX = value; OnPropertyChanged("PosX"); } }
        public override int PosY { get { return myEnemy.PositionY; } set { myEnemy.PositionY = value; OnPropertyChanged("PosY"); } }
        public override int PosZ { get { return myEnemy.PositionZ; } set { myEnemy.PositionZ = value; OnPropertyChanged("PosZ"); } }
        public override int Size { get { return Parent.MapScale; } set { } }
        private Random random = new Random();
        public override BitmapImage Skin
        {
            get
            {
                if (myEnemy is Skeleton)
                {
                    return new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/skeleton.png", UriKind.RelativeOrAbsolute));
                }
                if (myEnemy is Thief)
                {
                    return new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/thief.png", UriKind.RelativeOrAbsolute));
                }
                if (myEnemy is Hydra)
                {
                    return new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/hydra.png", UriKind.RelativeOrAbsolute));
                }
                else return null;
            }
        }
        public MainViewModel Parent { get; set; }
        public EnemyViewModel(Enemy enemy, MainViewModel parent)
        {
            myEnemy = enemy;
            Parent = parent;
            if (!(myEnemy is Hydra))
            {
                Actions.Add(EnemyMovement);
            }

            Actions.Add(CheckPlayer);
        }


        public enum Directions { Up, Down, Left, Right };
        public void Move(Directions dir)
        {
            if (Parent.myQuestionViewModel.QuestionControlVisible)
            {
                return;
            }


            switch (dir)
            {
                case Directions.Up:
                    if (CheckWallCollision(myEnemy.PositionX, myEnemy.PositionY - 1))
                    {
                        PosY--;
                    }
                    else return;
                    break;
                case Directions.Down:
                    if (CheckWallCollision(myEnemy.PositionX, myEnemy.PositionY + 1))
                    {
                        PosY++;
                    }
                    else return;
                    break;
                case Directions.Left:
                    if (CheckWallCollision(myEnemy.PositionX - 1, myEnemy.PositionY))
                    {
                        PosX--;
                    }
                    else return;
                    break;
                case Directions.Right:
                    if (CheckWallCollision(myEnemy.PositionX + 1, myEnemy.PositionY))
                    {
                        PosX++;
                    }
                    else return;
                    break;
                default:
                    break;
            }
        }

        private bool CheckWallCollision(int newX, int newY)
        {
            return !Parent.myMap.TileElements.Where(x => x is Wall).Any(x => x.PositionX == newX && x.PositionY == newY);
        }


        private Directions GetRandomDirection()
        {
            Array directions = Enum.GetValues(typeof(Directions));
            Directions RandomDirection = (Directions)directions.GetValue(random.Next(directions.Length));
            return RandomDirection;
        }

        private void EnemyMovement()
        {
            if (Parent.IterationNumber % 500 == 0)
            {
                Move(GetRandomDirection());
            }
        }

        private void CheckPlayer()
        {
            if (Parent.myQuestionViewModel.QuestionControlVisible)
            {
                return;
            }

            double dist = Math.Sqrt(Math.Pow(PosX - Parent.myPlayerViewModel.PosX, 2) + Math.Pow(PosY - Parent.myPlayerViewModel.PosY, 2));

            if (dist < 2)
            {
                Parent.myQuestionViewModel.StartQuiz(this);
            }

            return;
        }

        public void Die()
        {
            if (myEnemy.Health <=0)
            {
                Parent.GridItems.Remove(this);
                Actions.Clear();
            }
        }
    }
}
