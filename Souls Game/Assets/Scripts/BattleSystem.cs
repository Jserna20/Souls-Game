using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour 
{
    [Header("Set in Inspector")]
    public GameObject p1Prefab;
    public GameObject p2Prefab;

    [Header("Set Dynamically")]
    public bool alive;
    public bool turnOfP1;
    public bool turnOfP2;
    public bool p1Chose;
    public bool p2Chose;
    //public string magicAction;
    public string actionWords1; //Player will what their moves are later on
    public string actionWords2;
    public char letter1;
    public char letter2;
    public string results;
    public string victory;

    public GameObject player1;
    public GameObject player2;


	// Use this for initialization
	void Awake() 
    {
        print("Battle Start!");
        player1 = Instantiate(p1Prefab) as GameObject;
        player2 = Instantiate(p2Prefab) as GameObject;
        alive = true;
        turnOfP1 = true;
        turnOfP2 = false;
        p1Chose = false;
        p2Chose = false;
        letter1 = 'x';
        letter2 = 'x';
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (alive)
        {
            while (!(p1Chose && p2Chose))
            {
                ChoosingActions();
            }
                
            
            if(p1Chose && p2Chose)
            {
                if(turnOfP1)
                {
                    if(actionWords1.Equals("magic attk"))
                    {
                        switch (letter2)
                        {
                            case 'i':
                                results = "P2 blocked P1's magic attk. Battle Continues";
                                break;

                            case 'j':
                                results = "P2 was hit P1 wins";
                                //make a conditional statement here to check if health drops below 0
                                break;

                            case 'k':
                                results = "P2 was hit P1 wins";
                                break;

                            case 'l':
                                results = "P2 was hit P1 wins";
                                break;
                        }
                    }

                    if(actionWords1.Equals("basic attk"))
                    {
                        switch (letter2)
                        {
                            case 'i':
                                results = "P2 was hit P1 wins";
                                break;

                            case 'j':
                                results = "P2 blocked P1's basic attk. Battle Continues";
                                break;

                            case 'k':
                                results = "P2 was hit P1 wins";
                                break;

                            case 'l':
                                results = "P2 was hit P1 wins";
                                break;
                        }
                    }

                    if(actionWords1.Equals("Skill Locked!"))
                    {
                        switch (letter2)
                        {
                            case 'i':
                                results = "Nothing happened. Battle Continues";
                                break;

                            case 'j':
                                results = "Nothing happened. Battle Continues";
                                break;

                            case 'k':
                                results = "P2 was hit P1 wins";
                                break;

                            case 'l':
                                results = "Nothing happened. Battle Continues";
                                break;
                        }
                    }

                    if(actionWords1.Equals("Combo Attk"))
                    {
                        switch (letter2)
                        {
                            case 'i':
                                results = "P2 was hit P1 wins";
                                break;

                            case 'j':
                                results = "P2 was hit P1 wins";
                                break;

                            case 'k':
                                results = "P2 was hit P1 wins";
                                break;

                            case 'l':
                                results = "P1 was hit P2 wins";
                                break;
                        }
                    }
                }

                if (turnOfP2)
                {
                    if (actionWords2.Equals("magic attk"))
                    {
                        switch (letter1)
                        {
                            case 'w':
                                results = "P1 blocked P2's magic attk. Battle Continues";
                                break;

                            case 'a':
                                results = "P1 was hit P2 wins";
                                //make a conditional statement here to check if health drops below 0
                                break;

                            case 's':
                                results = "P1 was hit P2 wins";
                                break;

                            case 'd':
                                results = "P1 was hit P2 wins";
                                break;
                        }
                    }

                    if (actionWords2.Equals("basic attk"))
                    {
                        switch (letter1)
                        {
                            case 'w':
                                results = "P1 was hit P2 wins";
                                break;

                            case 'a':
                                results = "P1 blocked P2's basic attk. Battle Continues";
                                break;

                            case 's':
                                results = "P1 was hit P2 wins";
                                break;

                            case 'd':
                                results = "P1 was hit P2 wins";
                                break;
                        }
                    }

                    if (actionWords2.Equals("Skill Locked!"))
                    {
                        switch (letter1)
                        {
                            case 'w':
                                results = "Nothing happened. Battle Continues";
                                break;

                            case 'a':
                                results = "Nothing happened. Battle Continues";
                                break;

                            case 's':
                                results = "P2 was hit P1 wins";
                                break;

                            case 'd':
                                results = "Nothing happened. Battle Continues";
                                break;
                        }
                    }

                    if (actionWords2.Equals("Combo Attk"))
                    {
                        switch (letter1)
                        {
                            case 'w':
                                results = "P1 was hit P2 wins";
                                break;

                            case 'a':
                                results = "P1 was hit P2 wins";
                                break;

                            case 's':
                                results = "P1 was hit P2 wins";
                                break;

                            case 'd':
                                results = "P2 was hit P1 wins";
                                break;
                        }
                    }
                }

                if (p1Chose && p2Chose)
                    TurnResults();
            }


        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            alive = false;
            print("battle end");
        }

	}

    public void TurnResults()
    {

        if (results.Equals("P2 was hit P1 wins"))
        {
            Destroy(player2);
            print(results);
            alive = false;
        }
        else if (results.Equals("P1 was hit P2 wins"))
        {
            Destroy(player1);
            print(results);
            alive = false;
        }
        else
        {
            print(results);
            actionWords1 = "";
            actionWords2 = "";
            letter1 = 'x';
            letter2 = 'x';
            p1Chose = false;
            p2Chose = false;

            if(turnOfP1)
            {
                turnOfP1 = false;
                turnOfP2 = true;
            }

            if(turnOfP2)
            {
                turnOfP2 = false;
                turnOfP1 = true;
            }
        }

    }

    public void ChoosingActions()
    {
        if (turnOfP1)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                p1Chose = true;
                actionWords1 = "Magic attk";
                letter1 = 'w';
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                p1Chose = true;
                actionWords1 = "Basic attk";
                letter1 = 'a';
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                p1Chose = true;
                actionWords1 = "Skill Locked!"; //Actually does nothing for now
                letter1 = 's';
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                p1Chose = true;
                actionWords1 = "Combo Attk";
                letter1 = 'd';
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                p2Chose = true;
                actionWords2 = "Magic shield";
                letter2 = 'i';
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                p2Chose = true;
                actionWords2 = "Guard";
                letter2 = 'j';
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                p2Chose = true;
                actionWords2 = "I give up";
                letter2 = 'k';
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                p2Chose = true;
                actionWords2 = "Counter";
                letter2 = 'l';
            }
        }
        else if (turnOfP2)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                p2Chose = true;
                actionWords2 = "Magic attk";
                letter2 = 'i';
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                p2Chose = true;
                actionWords2 = "Basic attk";
                letter2 = 'j';
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                p2Chose = true;
                actionWords2 = "Skill Locked!"; //Actually does nothing for now
                letter2 = 'k';
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                p2Chose = true;
                actionWords2 = "Combo Attk";
                letter2 = 'l';
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                p2Chose = true;
                actionWords1 = "Magic shield";
                letter1 = 'w';
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                p2Chose = true;
                actionWords1 = "Guard";
                letter1 = 'a';
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                p2Chose = true;
                actionWords1 = "I give up";
                letter1 = 's';
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                p2Chose = true;
                actionWords1 = "Counter";
                letter1 = 'd';
            }
        } 
    }

    /*public void CalcingResults()
    {
        
    } */
}
