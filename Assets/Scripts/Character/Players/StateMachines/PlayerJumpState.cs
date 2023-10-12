using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAirState
{
    public PlayerJumpState(PlayerStateMachine _stateMachine) : base(_stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateMachine.JumpForce = stateMachine.Player.Data.AirData.JumpForce + stateMachine.Player.Data.Stats.GetPhysicalValue(1, .5f, .1f) * .01f;

        stateMachine.Player.ForceReceiver.Jump(stateMachine.JumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void PhhysicsUpdate()
    {
        base.PhhysicsUpdate();

        if (stateMachine.Player.Controller.velocity.y <= 0)
        {
            stateMachine.ChangeState(stateMachine.FallState);
            return;
        }
    }
}