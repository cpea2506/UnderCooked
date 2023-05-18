using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string Is_Walking = "IsWalking";
    private Animator animator;

    [SerializeField]
    private PlayerMovement playerMovement;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool(Is_Walking,playerMovement.IsWalking);
    }
}
