using System.Collections;
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
    public static string nameOfItemCollected;
    private AudioSource source;
    public AudioClip owTheme;

    float horizontalMove = 0f;
    float verticalMove = 0f;
    public int randomNum = 0;
    public int numForBattle = 5;
    public int whatItem;
    bool loaded = false;

    public string[] itemNames = new string[5];
    public string[] itemDescriptions = new string[5];



	private void Awake()
	{
        FillArrays();
        source = GetComponent<AudioSource>();

        if(PlayerStats.PlayerPos != Vector3.zero)
        {
            transform.position = PlayerStats.PlayerPos;
        }

        if(!PlayerStats.Alive)
        {
            PlayerStats.Alive = true;
            PlayerStats.InBattle = false;
            PlayerStats.RestoreHP();
            PlayerStats.RestoreStats();
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

    void FillArrays()
    {
        for (int i = 0; i < itemNames.Length; i++)
        {
            switch (i)
            {
                case 0:
                    itemNames[i] = PlayerStats.Name0;
                    itemDescriptions[i] = PlayerStats.Description0; 
                    break;
                case 1:
                    itemNames[i] = PlayerStats.Name1;
                    itemDescriptions[i] = PlayerStats.Description1; 
                    break;
                case 2:
                    itemNames[i] = PlayerStats.Name2;
                    itemDescriptions[i] = PlayerStats.Description2; 
                    break;
                case 3:
                    itemNames[i] = PlayerStats.Name3;
                    itemDescriptions[i] = PlayerStats.Description3; 
                    break;
                case 4:
                    itemNames[i] = PlayerStats.Name4;
                    itemDescriptions[i] = PlayerStats.Description4;
                    break;
            }
        }
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

        if(other.gameObject.CompareTag("ItemOrb"))
        {
            whatItem = Random.Range(0, 4);
            other.gameObject.SetActive(false);
            switch (whatItem)
            {
                case 0:
                    nameOfItemCollected = PlayerStats.Name0;
                    PlayerStats.Slot0Counter++;
                    break;
                case 1:
                    nameOfItemCollected = PlayerStats.Name1;
                    PlayerStats.Slot1Counter++;
                    break;
                case 2:
                    nameOfItemCollected = PlayerStats.Name2;
                    PlayerStats.Slot2Counter++;
                    break;
                case 3:
                    nameOfItemCollected = PlayerStats.Name3;
                    PlayerStats.Slot3Counter++;
                    break;
                case 4:
                    nameOfItemCollected = PlayerStats.Name4;
                    PlayerStats.Slot4Counter++;
                    break;
            }
            //nameOfItemCollected = itemNames[whatItem];
            ItemNotification.notifyMe = true;
        }

        if(other.gameObject.CompareTag("BossTrigger"))
        {
            PlayerStats.InBossBattle = true;
            BeginBattle();
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
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
        loaded = true;
    }
}
