using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMakerTest : MonoBehaviour 
{
    public GameObject canvas;

	// Use this for initialization
	void Start () 
    {
        GameObject newCanvas = Instantiate(canvas) as GameObject;
    }
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
