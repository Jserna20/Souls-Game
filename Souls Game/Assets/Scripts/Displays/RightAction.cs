using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightAction : MonoBehaviour
{
    public Player YourAction;
    // Use this for initialization
    void Awake()
    {
        YourAction.SetStats();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.tag == "Human")
        {
            Text gt = this.GetComponent<Text>();
            gt.text = PlayerStats.RightName;
        }
        else if (this.tag == "Enemy")
        {
            Text gt = this.GetComponent<Text>();
            gt.text = YourAction.GetRightName();
        }
    }
}

