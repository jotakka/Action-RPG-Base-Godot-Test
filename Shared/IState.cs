namespace ARPG.Shared
{
    public interface IState
    {
        void Enter();
        void Exit();
        void Update(double delta);
    }
}
