using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Results : MonoBehaviour
{
    public Player Choser1;
    public Player Choser2;
    public BattleTurns TurnB4;
    public string turnText;

    // Use this for initialization
    void Awake()
    {
        Choser1.SetStats();
        Choser1.SetStats();
        turnText = "";
    }

    // Update is called once per frame
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "Results of Turn " + (TurnB4.GetTurnNumber() - 1) + " : " + turnText;
    }

    public void NewTurnText(string newText)
    {
        turnText = newText;
    }

}
