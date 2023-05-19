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

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        moveDir = gameInput.GetMovementVectorNormalized();
        isWalking = moveDir != Vector3.zero;
        transform.position += moveDir * movementSpeed * Time.deltaTime;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }
}
