using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sub1 : MonoBehaviour 
{
    Text itemAndAmount;
	// Use this for initialization
	void Awake () 
    {
        itemAndAmount = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        itemAndAmount.text = PlayerStats.Name1 + " x" + PlayerStats.Slot1Counter;
	}
}
