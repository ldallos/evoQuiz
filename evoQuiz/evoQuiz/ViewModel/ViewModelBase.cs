using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuiz.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public void Update()
        {
            Actions = ActionsToAdd.Except(ActionsToStop).ToList();
            foreach (var action in Actions)
            {
                action();
            }
        }
        protected List<Action> Actions = new List<Action>();
        protected List<Action> ActionsToStop = new List<Action>();
        protected List<Action> ActionsToAdd = new List<Action>();
    }
}
