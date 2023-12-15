public abstract class BaseState
{
    //instance of enemy class
    //instance of statemachine class

    public Enemy enemy;
    public StateMachine stateMachine;
    public abstract void Enter();
    public abstract void Perform();
    public abstract void Exit();
}
