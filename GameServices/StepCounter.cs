using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TableGame.GameServices
{
    internal partial class StepCounter : ObservableObject, ISubject
    {
        [ObservableProperty]
        private int current;

        [ObservableProperty]
        private int total;

        private List<IObserver> observers = new();

        public delegate void GameOver();
        public event GameOver GameEnded;

        public StepCounter(int total)
        {
            current = 0;
            this.total = total;
        }

        [JsonConstructor]
        public StepCounter(int current, int total)
        {
            Current = current;
            Total = total;
        }

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var o in observers)
            {
                o.Update(this);
            }
        }

        public void NextStep()
        {
            Current++;
            if (Current == Total)
            {
                // end game
            }
            if (Current % 2 == 0)
            {
                Notify();
            }
            
        }
    }
}
