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

        if(!Menu.inMenuMode)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;

            animator.SetFloat("HorSpeed", Mathf.Abs(horizontalMove));
            animator.SetFloat("VerSpeed", verticalMove);

        }
        else
        {
            animator.SetFloat("HorSpeed", 0f);
            animator.SetFloat("VerSpeed", 0f);
            horizontalMove = 0;
            verticalMove = 0;
        }

	}

	private void FixedUpdate()
	{
        
            controller.MoveHorizontal(horizontalMove * Time.fixedDeltaTime);
            controller.MoveVertical(verticalMove * Time.fixedDeltaTime);
	}
}
