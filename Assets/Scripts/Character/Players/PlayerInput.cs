using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerInputActions InputActions { get; private set; }
    public PlayerInputActions.PlayerActions PlayerActions { get; private set; }
    public PlayerInputActions.DeveloperActions DeveloperActions { get; private set; }

    private void Awake()
    {
        InputActions = new PlayerInputActions();

        PlayerActions = InputActions.Player;
        DeveloperActions = InputActions.Developer;
    }

    public void OnEnable()
    {
        PlayerActions.Enable();
    }

    public void OnDisable()
    {
        PlayerActions.Disable();
    }
}