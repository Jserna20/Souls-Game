using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour 
{
    public CharacterController2D controller;
    public Animator animator;
    public int scene;
    public float transDelay = 2f;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    float verticalMove = 0f;
    public int randomNum;
    public int numForBattle = 5;
    bool loaded = false;

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

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("BattleTrigger"))
        {
            DelayedBattle(transDelay);
        }
        /*randomNum = Random.Range(0, 11);
        if(randomNum == numForBattle)
        {
           
        }*/
    }

    void DelayedBattle(float delay)
    {
        Invoke("BeginBattle", delay);
    }

    void BeginBattle()
    {
        PlayerStats.InBattle = true;
        Menu.inBattle = true;
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        loaded = true;
    }
}
