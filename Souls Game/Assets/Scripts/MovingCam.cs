using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCam : MonoBehaviour 
{
    
    private Vector3 offset;

    void Start()
    {
        if(PlayerStats.CamPos == Vector3.zero)
        {
            offset = transform.position - PlayerStats.PlayerPos;
        }
        else
        {
            transform.position = PlayerStats.CamPos;
            offset = transform.position - PlayerStats.PlayerPos;
        }

    }

    void LateUpdate()
    {
        transform.position = PlayerStats.PlayerPos + offset;
        PlayerStats.CamPos = transform.position;
    }
}
