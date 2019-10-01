using System;

namespace airport_simulator_2019.Engine
{
    public class GameObject : IEquatable<GameObject>
    {
        private static int _counter = 0;
        public string Id { get; }

        protected Game Game { get; private set; }

        public GameObject()
        {
            Game = Game.GetInstance();
            Game.RegisterObject(this);

            Id = $"{GetType().Name}{_counter}";
            _counter++;
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

        public virtual void OnSecond()
        { }

        public virtual void OnDayBegin()
        { }
    }
}
