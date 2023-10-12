using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBaseState : IState
{
    protected PlayerStateMachine stateMachine;
    private bool IsCommand;
    private float timer_attack;

    public PlayerBaseState(PlayerStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }

    public virtual void Enter()
    {
        AddInputActionsCallbacks();
    }

    public virtual void Exit()
    {
        ReMovementInputActionsCallbacks();
    }

    public virtual void HandleInput()
    {
        ReadMovementInput();
    }

    public virtual void PhhysicsUpdate()
    {
    }

    public virtual void Update()
    {
        Move();
        timer_attack += Time.deltaTime;
    }

    protected virtual void AddInputActionsCallbacks()
    {
        PlayerInput input = stateMachine.Player.Input;

        input.PlayerActions.Movement.canceled += OnMovementCanceled;
        input.PlayerActions.Run.started += OnRunStarted;
        input.PlayerActions.Jump.started += OnJumpStarted;
        input.PlayerActions.LeftClick.performed += OnLeftClickPerformed;
        input.DeveloperActions.Command.started += OnCommandStarted;
    }

    protected virtual void ReMovementInputActionsCallbacks()
    {
        PlayerInput input = stateMachine.Player.Input;

        input.PlayerActions.Movement.canceled -= OnMovementCanceled;
        input.PlayerActions.Run.started -= OnRunStarted;
        input.PlayerActions.Jump.started -= OnJumpStarted;
        input.PlayerActions.LeftClick.performed -= OnLeftClickPerformed;
        input.DeveloperActions.Command.started -= OnCommandStarted;
    }

    protected virtual void ReadMovementInput()
    {
        stateMachine.MovementInput = stateMachine.Player.Input.PlayerActions.Movement.ReadValue<Vector2>();
    }

    protected virtual void OnMovementCanceled(InputAction.CallbackContext context)
    {

    }

    protected virtual void OnRunStarted(InputAction.CallbackContext context)
    {

    }

    protected virtual void OnJumpStarted(InputAction.CallbackContext context)
    {

    }

    protected virtual void OnCommandStarted(InputAction.CallbackContext context)
    {
        if (IsCommand)
        {
            stateMachine.Player.Input.OnDisable();
        }
        else
        {
            stateMachine.Player.Input.OnEnable();
        }
        Debug.Log("Command Active");
    }

    protected virtual void OnLeftClickPerformed(InputAction.CallbackContext context)
    {

        if (timer_attack > 1f)
        {
            timer_attack = 0;
            stateMachine.Player.Attack();
        }
    }

    private void Move()
    {
        Vector3 movementDirection = GetMovementDiretion();

        Rotate(movementDirection);

        Move(movementDirection);
    }

    private Vector3 GetMovementDiretion()
    {
        return Vector3.forward * stateMachine.MovementInput.x + Vector3.left * stateMachine.MovementInput.y;
    }

    private float GetMovementSpeed()
    {
        float MovementSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;

        return MovementSpeed;
    }


    private void Rotate(Vector3 movementDirection)
    {
        if (movementDirection != Vector3.zero)
        {
            Transform playerTransform = stateMachine.Player.transform;
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            stateMachine.Player.transform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, stateMachine.RotationDumping);
        }

    }

    private void Move(Vector3 movementDirection)
    {
        float MovementSpeed = GetMovementSpeed();

        stateMachine.Player.Controller.Move((MovementSpeed * movementDirection) + stateMachine.Player.ForceReceiver.Movement * Time.deltaTime);
    }
}
