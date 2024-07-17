namespace ARPG.Shared
{
    public interface IState
    {
        public StatePriority Priority { get; }
        void Enter();
        void Exit();
        void Update(double delta);
    }
}
