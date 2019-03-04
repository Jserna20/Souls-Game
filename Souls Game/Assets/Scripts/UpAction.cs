using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpAction : MonoBehaviour
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
        Text gt = this.GetComponent<Text>();
        gt.text = YourAction.GetUpName();
    }
}

