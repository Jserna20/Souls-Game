using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPDisplay : MonoBehaviour
{
    public Player YourHP;
    public float hpofPlayer;
    public float maxHPofPlayer;

    // Use this for initialization
    void Awake()
    {
        if (PlayerPrefs.HasKey("YourHP"))
        {
            hpofPlayer = PlayerPrefs.GetFloat("HP");
            maxHPofPlayer = PlayerPrefs.GetFloat("MaxHP");
        }
        else
        {
            YourHP.SetStats();
            hpofPlayer = YourHP.GetHP();
            maxHPofPlayer = YourHP.GetMaxHP();
            PlayerPrefs.SetFloat("HP", hpofPlayer);
            PlayerPrefs.SetFloat("MaxHP", maxHPofPlayer);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "HP: " + YourHP.GetHP() + " / " + YourHP.GetMaxHP();
    }
}