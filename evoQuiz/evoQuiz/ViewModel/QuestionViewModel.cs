using evoQuiz.Model;
using evoQuiz.Model.Items;
using evoQuiz.Model.Quiz;
using evoQuizQuestionMaker;
using evoQuizQuestionMaker.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;


namespace evoQuiz.ViewModel
{
    public class QuestionViewModel : WindowViewModel
    {
        Random r = new Random();
        private Thickness myOffset;
        public Thickness Offset
        {
            get { return myOffset; }
            set { myOffset = value; OnPropertyChanged("Offset"); }
        }

        private double myFade;
        public double Fade
        {
            get { return myFade; }
            set { myFade = value; OnPropertyChanged("Fade"); }
        }

        private double myMonsterFade;
        public double MonsterFade
        {
            get { return myMonsterFade; }
            set { myMonsterFade = value; OnPropertyChanged("MonsterFade"); }
        }


        private BitmapImage myMonsterSkin;
        public BitmapImage MonsterSkin
        {
            get { return myMonsterSkin; }
            set { myMonsterSkin = value; OnPropertyChanged("MonsterSkin"); }
        }

        public double ControlHeight { get; set; }    
        public double ControlWidth { get; set; }
        public EnemyViewModel EnemyVM { get; set; }
        public HealthViewModel EnemyHealthViewModel { get; set; }
        public Player MyPlayer { get; set; }
        public MainViewModel Parent { get; set; }
        public InventoryViewModel myInventoryViewModel { get; set; }

        private bool myQuestionControlVisible;
        public bool QuestionControlVisible
        {
            get { return myQuestionControlVisible; }
            set { myQuestionControlVisible = value; OnPropertyChanged("QuestionControlVisible"); }
        }

        public Queue<QuizQuestion> Questions { get; set; } = new Queue<QuizQuestion>();
        public ObservableCollection<AnswerViewModel> Answers { get; set; } = new ObservableCollection<AnswerViewModel>();

        private QuizQuestion myCurrentQuestion;
        public QuizQuestion CurrentQuestion
        {
            get { return myCurrentQuestion; }
            set { myCurrentQuestion = value; OnPropertyChanged("QuestionText"); OnPropertyChanged("Answer1Text"); OnPropertyChanged("Answer2Text"); OnPropertyChanged("Answer3Text"); OnPropertyChanged("Answer4Text"); }
        }
        public string QuestionText { get { return CurrentQuestion.myQuestion; } }

        public QuestionViewModel(Player player)
        {
            MyPlayer = player;
            QuestionControlVisible = false;
            CurrentQuestion = new QuizQuestion();
            GetQuestions();

            myInventoryViewModel = new InventoryViewModel(MyPlayer, this);         
        }

        private void GetQuestions()
        {


            Questions.Enqueue(new QuizQuestion() { myQuestion ="q1", myRightAnswer = "a1", myWrongAnswers = {"a2", "a3", "a4"} });
            Questions.Enqueue(new QuizQuestion() { myQuestion = "q2", myRightAnswer = "a1", myWrongAnswers = { "a2", "a3", "a4" } });
            Questions.Enqueue(new QuizQuestion() { myQuestion = "q3", myRightAnswer = "a1", myWrongAnswers = { "a2", "a3", "a4" } });
            Questions.Enqueue(new QuizQuestion() { myQuestion = "q4", myRightAnswer = "a1", myWrongAnswers = { "a2", "a3", "a4" } });
            Questions.Enqueue(new QuizQuestion() { myQuestion = "q5", myRightAnswer = "a1", myWrongAnswers = { "a2", "a3", "a4" } });
            Questions.Enqueue(new QuizQuestion() { myQuestion = "q6", myRightAnswer = "a1", myWrongAnswers = { "a2", "a3", "a4" } });
            Questions.Enqueue(new QuizQuestion() { myQuestion = "q7", myRightAnswer = "a1", myWrongAnswers = { "a2", "a3", "a4" } });
            Questions.Enqueue(new QuizQuestion() { myQuestion = "q8", myRightAnswer = "a1", myWrongAnswers = { "a2", "a3", "a4" } });
        }


        public void StartQuiz(EnemyViewModel enemy)
        {
            EnemyVM = enemy;
            MonsterSkin = EnemyVM.Skin;
            EnemyHealthViewModel = new HealthViewModel(enemy.myEnemy);
            GetCurrentQuestion();
            OpenWindow();
        }

        private void GetCurrentQuestion()
        {
            CurrentQuestion = Questions.Dequeue();

            List<int[]> Positions = new List<int[]>() { new int[] { 0, 0 }, new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 1, 1 } };
            Positions = ShuffleList(Positions);
            Queue<int[]> PosQueue = new Queue<int[]>();
            foreach (var pos in Positions)
            {
                PosQueue.Enqueue(pos);
            }

            Answers.Add(new AnswerViewModel(CurrentQuestion.myRightAnswer, PosQueue.Dequeue(), this));

            foreach (var answer in CurrentQuestion.myWrongAnswers)
            {
                Answers.Add(new AnswerViewModel(answer, PosQueue.Dequeue(), this));
            }
        }

        private List<E> ShuffleList<E>(List<E> inputList)
        {
            List<E> randomList = new List<E>();

            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count);
                randomList.Add(inputList[randomIndex]); 
                inputList.RemoveAt(randomIndex); 
            }

            return randomList; 
        }

        public void Quiz(string answer)
        {
            if (answer == CurrentQuestion.myRightAnswer)
            {
                EnemyVM.myEnemy.Health -= MyPlayer.Damage*10;
                EnemyHealthViewModel.Update();
                EnemyVM.myEnemy.Ability(MyPlayer);
                if (EnemyVM.myEnemy.Health<=0)
                {
                    EndQuiz();
                    return;
                }

            }
            else
            {
                MyPlayer.Health -= EnemyVM.myEnemy.Damage;
                Parent.myHealthViewModel.Update();

                if (MyPlayer.Health==0)
                {
                    Parent.GameOver();
                }
            }

            GetCurrentQuestion();
        }


        private void EndQuiz()
        {
            QuestionControlVisible = false;
            MyPlayer.Gold += EnemyVM.myEnemy.Gold;
            Parent.GridItems.Remove(EnemyVM);
        }

        private void OpenWindow()
        {
            QuestionControlVisible = true;
            Offset = new Thickness(0, ControlHeight*0.4, 0,0);
            Fade = 0;
            Actions.Add(FadeIn);
        }

        private void SlideUp()
        {
            double x = Offset.Top;
            x--;
            Offset = new Thickness(0, x, 0, 0);
            if (Offset.Top <=0)
            {
                Offset = new Thickness(0, 0, 0, 0);
                ActionsToStop.Add(SlideUp);
                Actions.Add(MonsterFadeIn);

                myInventoryViewModel.Open();
            }
        }

        private void FadeIn()
        {
            Fade += 0.001;
            if (Fade >=1)
            {
                Fade = 1;
                ActionsToStop.Add(FadeIn);
                Actions.Add(SlideUp);
            }
        }

        private void MonsterFadeIn()
        {
            MonsterFade += 0.003;
            if (MonsterFade >= 1)
            {
                MonsterFade = 1;
                ActionsToStop.Add(MonsterFadeIn);
            }
        }

        public override void ItemUsed(ItemInventoryViewModel itemVM)
        {
            if (itemVM.MyItem is Potion)
            {
                MyPlayer.Health += 2;
                Parent.myHealthViewModel.Update();
                DeleteItem(itemVM);
                return;
            }

            if (itemVM.MyItem is Sword)
            {
                for (int i = 0; i < 2; i++)
                {
                    int index = r.Next(myCurrentQuestion.myWrongAnswers.Count - 1);
                    Answers.Remove(Answers.Single(x => x.AnswerText == myCurrentQuestion.myWrongAnswers[index]));
                    CurrentQuestion.myWrongAnswers.RemoveAt(index);
                }
                DeleteItem(itemVM);
                return;
            }


            void DeleteItem(ItemInventoryViewModel itemToDelete)
            {
                MyPlayer.Inventory.Remove(itemToDelete.MyItem);
                int x = itemToDelete.PosX;
                int y = itemToDelete.PosY;
                myInventoryViewModel.Items.Remove(itemToDelete);
                myInventoryViewModel.Items.Add(new ItemInventoryViewModel(null, myInventoryViewModel) { PosX = x, PosY = y });
            }
        }
    }
}
