using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInOW : MonoBehaviour 
{
    static private MovementInOW S;

    [Header("Set In Inspector")]
    public float movementSpeed = 0.5f;
    public GameObject playerInOWPF;

    [Header("Set Dynamically")]
    public GameObject playerInOW;
    public Vector3 playerSpot;
    public Vector3 playerRotation;
    public Quaternion flip;
    public bool movingMode;
    public bool facingRightSide;

	// Use this for initialization
	void Awake () 
    {
        playerInOW = Instantiate(playerInOWPF) as GameObject;
        playerSpot = Vector3.zero;
        playerRotation = Vector3.zero;
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
                playerSpot = playerSpot + (Vector3.down * movementSpeed);
                playerInOW.transform.position = playerSpot;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                playerSpot = playerSpot + (Vector3.up * movementSpeed);
                playerInOW.transform.position = playerSpot;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (!facingRightSide)
                {
                    facingRightSide = true;
                    flip.y -= 180;
                    playerInOW.transform.rotation = flip;
                }
                playerSpot = playerSpot + (Vector3.right * movementSpeed);
                playerInOW.transform.position = playerSpot;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (facingRightSide)
                {
                    facingRightSide = false;
                    flip.y += 180;
                    playerInOW.transform.rotation = flip;

                }
                playerSpot = playerSpot + (Vector3.left * movementSpeed);
                playerInOW.transform.position = playerSpot;

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
}
