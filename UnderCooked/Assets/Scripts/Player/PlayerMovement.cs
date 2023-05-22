using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float rotateSpeed;

    private Vector3 moveDir;

    private bool isWalking;

    public bool IsWalking => isWalking;

    [SerializeField]
    private GameInput gameInput;
    private Vector3 lastInteractDir;

    [SerializeField]
    private LayerMask countersLayerMask;

    private void Start()
    {
        gameInput.OnInteract += HandleInteraction;
    }
    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        moveDir = gameInput.GetMovementVectorNormalized();
        // bool canMove = Physics.CapsuleCast(transform.position, transform.position+Vector3.up*2f,0.7f,moveDir);
        isWalking = moveDir != Vector3.zero;
        transform.position += moveDir * movementSpeed * Time.deltaTime;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        
        if (moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }
    }

    private void OnDestroy()
    {
        gameInput.OnInteract -= HandleInteraction;
    }

    private void HandleInteraction()
    {
        float interactDistance = 5f;

        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, countersLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                clearCounter.Interact();
            }
        }
        else
        {
            Debug.Log("null");
        }
    }
}
