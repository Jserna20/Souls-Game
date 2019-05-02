﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnotherSub : MonoBehaviour
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
        itemAndAmount.text = PlayerStats.Name3 + " x" + PlayerStats.Slot3Counter;
    }
}