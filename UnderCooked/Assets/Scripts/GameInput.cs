using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    public event Action OnInteract;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Interact.performed += Interact_performed;
    }
    private void Interact_performed(InputAction.CallbackContext obj)
    {
        OnInteract?.Invoke();
    }
    public Vector3 GetMovementVectorNormalized()
    {
        Vector3 inputVector = playerInputActions.Player.Move.ReadValue<Vector3>();
        
        return inputVector.normalized;
    }
}
