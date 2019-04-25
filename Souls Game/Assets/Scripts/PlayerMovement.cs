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

    public string name1 = "Adam Apple";
    public string name2 = "Milk";
    public string name3 = "Cloak";
    public string name4 = "Tome of Offense";
    public string name5 = "Tome of Defense";

    public string description1 = "Heals 2 HP.";
    public string description2 = "Temporarily increases Attack by 1.";
    public string description3 = "Temporarily increases Defense by 1.";
    public string description4 = "Temporarily increases Magic Attk by 1.";
    public string description5 = "Temporarily increases Magic Def by 1.";

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
                    itemNames[i] = name1;
                    itemDescriptions[i] = description1; 
                    break;
                case 1:
                    itemNames[i] = name1;
                    itemDescriptions[i] = description1; 
                    break;
                case 2:
                    itemNames[i] = name1;
                    itemDescriptions[i] = description1; 
                    break;
                case 3:
                    itemNames[i] = name1;
                    itemDescriptions[i] = description1; 
                    break;
                case 4:
                    itemNames[i] = name1;
                    itemDescriptions[i] = description1;
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
                    nameOfItemCollected = name1;
                    break;
                case 1:
                    nameOfItemCollected = name2;
                    break;
                case 2:
                    nameOfItemCollected = name3;
                    break;
                case 3:
                    nameOfItemCollected = name4;
                    break;
                case 4:
                    nameOfItemCollected = name5;
                    break;
            }
            //nameOfItemCollected = itemNames[whatItem];
            ItemNotification.notifyMe = true;
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
