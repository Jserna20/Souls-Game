using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInOW : MonoBehaviour 
{
    static private MovementInOW S;

    [Header("Set In Inspector")]
    public float movementSpeed = 0.5f;
    public GameObject playerInOWPF;
    public GameObject worldCam;
    public Menu menuHalos;

    [Header("Set Dynamically")]
    public GameObject playerInOW;
    public Vector3 playerSpot;
    public Vector3 playerRotation;
    public Vector3 worldCamPos;
    public Quaternion flip;
    public bool movingMode;
    public bool facingRightSide;

	// Use this for initialization
	void Awake () 
    {
        playerInOW = Instantiate(playerInOWPF) as GameObject;
        playerSpot = Vector3.zero;
        playerRotation = Vector3.zero;
        worldCamPos = new Vector3(0, 0, -10);
        facingRightSide = true;
        flip = playerInOW.transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(movingMode)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                playerSpot += (Vector3.down * movementSpeed);
                worldCamPos += (Vector3.down * movementSpeed);
                playerInOW.transform.position = playerSpot;
                worldCam.transform.position = worldCamPos;
                MatchHalosWithCam(Vector3.down * movementSpeed);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                playerSpot += (Vector3.up * movementSpeed);
                worldCamPos += (Vector3.up * movementSpeed);
                playerInOW.transform.position = playerSpot;
                worldCam.transform.position = worldCamPos;
                MatchHalosWithCam(Vector3.up * movementSpeed);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
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
