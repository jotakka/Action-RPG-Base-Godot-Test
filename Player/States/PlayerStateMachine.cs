using ARPG.Player;
using ARPG.Shared;
using System.Collections.Generic;

public partial class PlayerStateMachine
{
    private readonly Dictionary<PlayerInputAction, PlayerStateBase> _stateTransitions;
    private PlayerStateBase _currentState;
    public PlayerStateMachine(PlayerNode player)
    {
        _stateTransitions = new()
        {
            [PlayerInputAction.Idle] = new PlayerIdleState(player),
            [PlayerInputAction.Walk] = new PlayerWalkState(player),
            [PlayerInputAction.Attack] = new PlayerAttackState(player, StatePriority.HIGHEST),
            [PlayerInputAction.Hurt] = new PlayerHurtState(player),
        };
        _currentState = _stateTransitions[PlayerInputAction.Idle];
    }

    public void Update(double delta)
    {
        _currentState.Update(delta);
    }

    public void ChangeState(PlayerInputAction newState)
    {
        var nextState = _stateTransitions[newState];
        if (AllowInterruption(nextState))
        {
            _currentState.Exit();
            _currentState = _stateTransitions[newState];
            _currentState.Enter();
        }
    }

    private bool AllowInterruption(PlayerStateBase nextState)
    {
        return _currentState.AllowInterruption is true
            || nextState.Priority.HasHigherPriorityThan(_currentState.Priority);
    }
}