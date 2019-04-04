using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementInOW : MonoBehaviour 
{

    [Header("Set In Inspector")]
    public float movementSpeed = 0.5f;
    public GameObject playerInOWPF;
    public GameObject worldCam;
    public Menu menuHalos;
    public Player statsOfPlayer;
    public int stepcounter;
    public PlayerPrefManager StorageOW;

    [Header("Set Dynamically")]
    public GameObject playerInOW;
    public Vector3 playerSpot;
    public Vector3 playerRotation;
    public Vector3 worldCamPos;
    public Quaternion flip;
    public bool movingMode;
    public bool facingRightSide;
    public int stepsUntilFight;

	// Use this for initialization
	void Awake () 
    {
        playerInOW = Instantiate(playerInOWPF) as GameObject;
        playerSpot = Vector3.zero;
        playerRotation = Vector3.zero;
        worldCamPos = new Vector3(0, 0, -10);
        facingRightSide = true;
        flip = playerInOW.transform.localRotation;
        if(PlayerPrefs.HasKey("HP"))
        {
            StorageOW.GetAllStats();
        }
        else
        {
            statsOfPlayer.SetStats();
        }
        stepcounter = 0;
        stepsUntilFight = Random.Range(1, 11);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(movingMode)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                stepcounter++;
                playerSpot += (Vector3.down * movementSpeed);
                worldCamPos += (Vector3.down * movementSpeed);
                playerInOW.transform.position = playerSpot;
                worldCam.transform.position = worldCamPos;
                MatchHalosWithCam(Vector3.down * movementSpeed);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                stepcounter++;
                playerSpot += (Vector3.up * movementSpeed);
                worldCamPos += (Vector3.up * movementSpeed);
                playerInOW.transform.position = playerSpot;
                worldCam.transform.position = worldCamPos;
                MatchHalosWithCam(Vector3.up * movementSpeed);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                stepcounter++;
                if (!facingRightSide)
                {
                    facingRightSide = true;
                    flip.y -= 180;
                    playerInOW.transform.rotation = flip;
                }
                playerSpot += (Vector3.right * movementSpeed);
                worldCamPos += (Vector3.right * movementSpeed);
                playerInOW.transform.position = playerSpot;
                worldCam.transform.position = worldCamPos;
                MatchHalosWithCam(Vector3.right * movementSpeed);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                stepcounter++;
                if (facingRightSide)
                {
                    facingRightSide = false;
                    flip.y += 180;
                    playerInOW.transform.rotation = flip;

                }
                playerSpot += (Vector3.left * movementSpeed);
                worldCamPos += (Vector3.left * movementSpeed);
                playerInOW.transform.position = playerSpot;
                worldCam.transform.position = worldCamPos;
                MatchHalosWithCam(Vector3.left * movementSpeed);
            }
        }
    
	}

	private void LateUpdate()
	{
        if(stepcounter == stepsUntilFight)
        {
            SceneManager.LoadScene("TestBattle");
        }
	}

	public void SetMovingMode(bool cond)
    {
        movingMode = cond;
    }

    public bool GetMovingMode()
    {
        return movingMode;
    }

    public void MatchHalosWithCam(Vector3 newLocation)
    {
        menuHalos.mapHalo.transform.position += newLocation;
        menuHalos.actionHalo.transform.position += newLocation;
        menuHalos.itemsHalo.transform.position += newLocation;
        menuHalos.weaponsHalo.transform.position += newLocation;
        menuHalos.shieldHalo.transform.position += newLocation;
        menuHalos.statsHalo.transform.position += newLocation;
    }
}
