using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelAndExp : MonoBehaviour {

    public Player YourLvlExp;

    // Use this for initialization
    void Awake()
    {
        YourLvlExp.SetStats();
    }

    // Update is called once per frame
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "Lvl: " + YourLvlExp.GetLvl() + "\tExp: " + YourLvlExp.GetExp() + " / " + YourLvlExp.GetMaxEXP();
    }
}
