using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    [SerializeField] private Animator animator;

    [SerializeField] private float runSpeed = 40f;

    float horizontalMove = 0f;

    private void Update() 
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    private void FixedUpdate()
    {
        //Move our character here.
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
    }
}
