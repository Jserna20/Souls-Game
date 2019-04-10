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
        
        if (this.tag == "Enemy")
        {
            YourStats.SetStats();
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (this.tag == "Human")
        {
            Text gt = this.GetComponent<Text>();
            gt.text = "Attk:\t\t\t" + PlayerStats.Attk +
                "\nDef:\t\t\t" + PlayerStats.Def +
                "\nMagAttk:\t" + PlayerStats.MagicAttk +
                "\nMagDef:\t" + PlayerStats.MagicDef; 
        }
        else if (this.tag == "Enemy")
        {
            Text gt = this.GetComponent<Text>();
            gt.text = "Attk:\t\t\t" + YourStats.GetAttk() +
                "\nDef:\t\t\t" + YourStats.GetDef() +
                "\nMagAttk:\t" + YourStats.GetMagicAttk() +
                "\nMagDef:\t" + YourStats.GetMagicDef();
        }

	}
}
