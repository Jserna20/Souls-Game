using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleTurns : MonoBehaviour
{
    public int turnNumber;

    // Use this for initialization
    void Awake()
    {
        turnNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "Battle Turn: " + turnNumber;
    }

    public void IncreaseTurn()
    {
            ++turnNumber;
    }

    public int GetTurnNumber()
    {
        return turnNumber;
    }

}
