using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public Vector3 GetMovementVectorNormalized()
    {
        Vector3 inputVector = new Vector3(0,0,0);
        
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            inputVector.z = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputVector.z = -1;
        }

        return inputVector = inputVector.normalized;
    }
}
