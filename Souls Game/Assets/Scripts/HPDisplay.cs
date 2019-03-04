using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPDisplay : MonoBehaviour
{
    public Player YourHP;

    // Use this for initialization
    void Awake()
    {
        YourHP.SetStats();
    }

    // Update is called once per frame
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "HP: " + YourHP.GetHP() + " / " + YourHP.GetMaxHP();
    }
}
