using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;
    public bool idle = true;

    float horizontalMove = 0f;
    float verticalMove = 0f;

	// Update is called once per frame
	void Update () 
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;

        if((horizontalMove == 0f) && (verticalMove == 0f))
        {
            idle = true;
        }

        animator.SetBool("IsIdle", idle);
        animator.SetFloat("HorSpeed", Mathf.Abs(horizontalMove));
        animator.SetFloat("VerSpeed", verticalMove);

	}

	private void FixedUpdate()
	{
        controller.MoveHorizontal(horizontalMove * Time.fixedDeltaTime);
        controller.MoveVertical(verticalMove * Time.fixedDeltaTime);
	}
}
