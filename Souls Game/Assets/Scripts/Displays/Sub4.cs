using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sub4 : MonoBehaviour
{
    Text itemAndAmount;
    // Use this for initialization
    void Awake()
    {
        itemAndAmount = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        itemAndAmount.text = PlayerStats.Name4 + " x" + PlayerStats.Slot4Counter;
    }
}
