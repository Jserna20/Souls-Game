using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelAndExp : MonoBehaviour {
    

    // Use this for initialization
    void Awake()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "Lvl: " + PlayerStats.LVL + "\t\tExp: " + PlayerStats.EXP + " / " + PlayerStats.MaxEXP;
    }
}
