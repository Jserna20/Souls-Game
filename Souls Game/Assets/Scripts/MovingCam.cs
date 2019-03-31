using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCam : MonoBehaviour 
{

    public GameObject playerInWorld;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - playerInWorld.transform.position;
    }

    void LateUpdate()
    {
        transform.position = playerInWorld.transform.position + offset;
    }
}
