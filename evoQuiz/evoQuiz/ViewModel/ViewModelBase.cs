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
            Actions = Actions.Except(ActionsToStop).ToList();
            ActionsToStop.Clear();
            for (int i = 0; i < Actions.Count; i++)
            {
                Actions[i]();
            }

            foreach (var child in ChildViews)
            {
                child.Update();
            }
        }
        protected List<Action> Actions = new List<Action>();
        protected List<Action> ActionsToStop = new List<Action>();

        protected List<ViewModelBase> ChildViews { get; set; } = new List<ViewModelBase>();
    }
}
