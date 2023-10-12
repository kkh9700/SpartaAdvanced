using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalkState : PlayerGroundState
{
    public PlayerWalkState(PlayerStateMachine _stateMachine) : base(_stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateMachine.MovementSpeedModifier = stateMachine.Player.Data.GroundData.WalkSpeedModifier + stateMachine.Player.Data.Stats.GetPhysicalValue(0.5f, 1f, 0.1f) * 0.001f;
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

    protected override void OnRunStarted(InputAction.CallbackContext context)
    {
        base.OnRunStarted(context);

        stateMachine.ChangeState(stateMachine.RunState);
    }
}