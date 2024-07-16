using ARPG.Player;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            [PlayerInputAction.Attack] = new PlayerAttackState(player),
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
        _currentState.Exit();
        _currentState = _stateTransitions[newState];
        _currentState.Enter();
    }
}

