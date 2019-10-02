using System;
using System.ComponentModel;

namespace airport_simulator_2019.Engine
{
    public class GameObject : IEquatable<GameObject>, INotifyPropertyChanged
    {
        private static int _counter = 0;
        public string Id { get; }

        protected Game Game { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public GameObject()
        {
            Game = Game.GetInstance();
            Game.RegisterObject(this);

            Id = $"{GetType().Name}{_counter}";
            _counter++;
        }

        public void RaisePropertyChanged()
        {
            PropertyChanged(this, new PropertyChangedEventArgs(string.Empty));
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as GameObject);
        }
        public bool Equals(GameObject obj)
        {
            return obj != null && obj.Id == Id;
        }

        public virtual void OnMinute()
        { }

        public virtual void OnDayBegin()
        { }
    }
}
