using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    float verticalMove = 0f;

	// Update is called once per frame
	void Update () 
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;

        if(!Menu.inMenuMode)
        {
            animator.SetFloat("HorSpeed", Mathf.Abs(horizontalMove));
            animator.SetFloat("VerSpeed", verticalMove);
        }

	}

	private void FixedUpdate()
	{
        if(!Menu.inMenuMode)
        {
            controller.MoveHorizontal(horizontalMove * Time.fixedDeltaTime);
            controller.MoveVertical(verticalMove * Time.fixedDeltaTime);
        }
	}
}
