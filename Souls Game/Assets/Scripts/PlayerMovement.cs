﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour 
{
    public CharacterController2D controller;
    public Animator animator;
    public int scene;
    public float transDelay = 0.5f;
    public float runSpeed = 40f;

    private AudioSource source;
    public AudioClip owTheme;

    float horizontalMove = 0f;
    float verticalMove = 0f;
    public int randomNum = 0;
    public int numForBattle = 5;
    bool loaded = false;

	private void Awake()
	{
        source = GetComponent<AudioSource>();

        if(PlayerStats.PlayerPos != Vector3.zero)
        {
            transform.position = PlayerStats.PlayerPos;
        }

        source.PlayOneShot(owTheme, 1f);
	}

	// Update is called once per frame
	void Update () 
    {
        if (!source.isPlaying && !PlayerStats.InBattle)
        {
            source.PlayOneShot(owTheme, 1f);
        }

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

        if(Input.GetKeyDown(KeyCode.Space))
        {
            BeginBattle();
        }

        PlayerStats.PlayerPos = transform.position;

	}

	private void FixedUpdate()
	{
        
            controller.MoveHorizontal(horizontalMove * Time.fixedDeltaTime);
            controller.MoveVertical(verticalMove * Time.fixedDeltaTime);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BattleTrigger"))
        {
            
            if ((horizontalMove != 0f || verticalMove != 0f))
            {
                randomNum = Random.Range(0, 11);
            }

            
            if (randomNum == numForBattle)
            {
                BeginBattle();
            }
        }
    }

    void DelayedBattle(float delay)
    {
        Invoke("BeginBattle", delay);
    }

    void BeginBattle()
    {
        horizontalMove = 0;
        verticalMove = 0;
        controller.MoveHorizontal(horizontalMove * Time.fixedDeltaTime);
        controller.MoveVertical(verticalMove * Time.fixedDeltaTime);
        PlayerStats.InBattle = true;
        source.Stop();
        Menu.inBattle = true;
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        loaded = true;
    }
}
