using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRunState : PlayerGroundState
{
    public PlayerRunState(PlayerStateMachine _stateMachine) : base(_stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateMachine.MovementSpeedModifier = stateMachine.Player.Data.GroundData.RunSpeedModifier + stateMachine.Player.Data.Stats.GetPhysicalValue(0.5f, 1f, 0.1f) * 0.0015f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void PhhysicsUpdate()
    {
        base.PhhysicsUpdate();

        if (!stateMachine.Player.Stamina.Consume(10 * Time.fixedDeltaTime))
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }

    protected override void OnRunStarted(InputAction.CallbackContext context)
    {
        base.OnRunStarted(context);

        stateMachine.ChangeState(stateMachine.WalkState);
    }
}