using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace ARPG.Shared;

public partial class StateMachine : Node
{
    private IState? _currentState;

    public void ChangeState(IState newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

    public override void _Process(float delta)
    {
        _currentState?.Update(delta);
    }
}
