using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsDisplay : MonoBehaviour 
{
    public Player YourStats;

	// Use this for initialization
	void Awake () 
    {
        YourStats.SetStats();
	}
	
	// Update is called once per frame
	void Update () 
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "Attk: \t\t\t" + YourStats.GetAttk() +
            " Def: \t\t\t\t" + YourStats.GetDef() +
            " MagAttk: \t\t" + YourStats.GetMagicAttk() + 
            " MagDef \t\t" + YourStats.GetMagicDef();
	}
}
