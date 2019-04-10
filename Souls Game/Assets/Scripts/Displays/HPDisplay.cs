using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPDisplay : MonoBehaviour
{
    public Player YourHP;

    void Awake()
    {
        if (this.tag == "Enemy")
        {
            YourHP.SetStats();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(this.tag == "Human")
        {
            Text gt = this.GetComponent<Text>();
            gt.text = "HP: " + PlayerStats.HP + " / " + PlayerStats.MaxHP;
        }
        else if(this.tag == "Enemy")
        {
            Text gt = this.GetComponent<Text>();
            gt.text = "HP: " + YourHP.GetHP() + " / " + YourHP.GetMaxHP();
        }
    }
}