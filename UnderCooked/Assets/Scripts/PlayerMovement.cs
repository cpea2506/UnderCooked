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

    void Start()
    {

    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        moveDir = new Vector3(0,0,0);

        if (Input.GetKey(KeyCode.D))
        {
            moveDir.x = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveDir.x = -1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveDir.z = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveDir.z = -1;
        }

        moveDir = moveDir.normalized;

        transform.position += moveDir * movementSpeed * Time.deltaTime;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime*rotateSpeed);
    }
}
