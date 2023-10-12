using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerBaseState
{
    public PlayerAirState(PlayerStateMachine _stateMachine) : base(_stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void PhhysicsUpdate()
    {
        base.PhhysicsUpdate();

        stateMachine.Player.Stamina.Regenerate(2 * Time.fixedDeltaTime);
    }
}
