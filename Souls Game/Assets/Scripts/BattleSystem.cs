using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour 
{
    [Header("Set in Inspector")]
    //public GameObject p1Prefab;
    //public GameObject p2Prefab;
    public Player Fighter1;
    public Player Fighter2;

    [Header("Set Dynamically")] //Delete after fighter class complete
    //public bool alive;
    //public bool turnOfP1;
    //public bool turnOfP2;
    //public bool p1Chose;
    //public bool p2Chose;
    //public string magicAction;
    public string actionWords1; //fighter will what their moves are later on
    public string actionWords2;
    public char letter1;
    public char letter2;
    public string results;
    public string results2;

    //public GameObject fighterGO1;
    //public GameObject fighterGO2;
    

	// Use this for initialization
	void Awake() 
    {
        print("Battle Start!");
        //fighterGO1 = Instantiate(p1Prefab) as GameObject;
        //fighterGO2 = Instantiate(p2Prefab) as GameObject;
        //alive = true;
        Fighter1.SetStats();
        Fighter2.SetStats();
        Fighter1.IsAttacking(true);
        Fighter2.IsAttacking(false);
        Fighter1.SetNameBasedOnTurn();
        Fighter2.SetNameBasedOnTurn();
        /*Fighter1.SetAlive(true);
        Fighter2.SetAlive(true);
        Fighter1.SetInBattle(true);
        Fighter2.SetInBattle(true);
        //turnOfP1 = true;
        //turnOfP2 = false;
        //p1Chose = false;
        //p2Chose = false;
        Fighter1.GetChoosing();
        Fighter2.GetChoosing();
        letter1 = 'x';
        letter2 = 'x';*/
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Fighter1.GetAlive() && Fighter2.GetAlive())
        {
            if (!(Fighter1.GetChoosing() && Fighter2.GetChoosing()))
            {
                ChoosingActions();
            }
            if(Fighter1.GetChoosing() && Fighter2.GetChoosing())
            {
                CalcingResults();
                TurnResults();
            }
        }

        /*if (Input.GetKeyDown(KeyCode.Space)) 
        {
            alive = false;
            print("battle end");
        }
        */

	}

    public void TurnResults()
    {

        if (results.Equals("P2 was hit P1 wins") && results2.Equals(""))
        {
            Fighter2.DestroyMe();
            print(results + results2);
            //alive = false;
            Fighter2.SetAlive(false);
        }
        else if (results.Equals("P1 was hit P2 wins") && results2.Equals(""))
        {
            Fighter1.DestroyMe();
            print(results + results2);
            //alive = false;
            Fighter1.SetAlive(false);
        }
        else if(results2.Equals("Battle Continues"))
        {
            print(results + results2);
            actionWords1 = "";
            actionWords2 = "";
            results = "";
            results2 = "";
            letter1 = 'x';
            letter2 = 'x';
            //p1Chose = false;
            //p2Chose = false;

            if(Fighter1.GetAttacker())
            {
                Fighter1.IsAttacking(false);
                Fighter2.IsAttacking(true);
            }
            else if (Fighter2.GetAttacker())
            {
                Fighter2.IsAttacking(false);
                Fighter1.IsAttacking(true);
            }
            Fighter1.SetChoosing(false);
            Fighter2.SetChoosing(false);
            Fighter1.SetNameBasedOnTurn();
            Fighter2.SetNameBasedOnTurn();
        }
       else if(results.Equals("") && results2.Equals(""))
        {
            //Will reset the turn without changing it
            print("Results: " + results);
            actionWords1 = "";
            actionWords2 = "";
            results = "";
            results2 = "";
            letter1 = 'x';
            letter2 = 'x';
            Fighter1.SetChoosing(false);
            Fighter2.SetChoosing(false);
        }
    }

    public void ChoosingActions()
    {
        if (Fighter1.GetAttacker())
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Fighter1.SetChoosing(true);
                actionWords1 = Fighter1.GetUpName();
                letter1 = 'w';
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                Fighter1.SetChoosing(true);
                actionWords1 = Fighter1.GetLeftName();
                letter1 = 'a';
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                Fighter1.SetChoosing(true);
                actionWords1 = Fighter1.GetDownName(); //Actually does nothing for now
                letter1 = 's';
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                Fighter1.SetChoosing(true);
                actionWords1 = Fighter1.GetRightName();
                letter1 = 'd';
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                Fighter2.SetChoosing(true);
                actionWords2 = Fighter2.GetUpName();
                letter2 = 'i';
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                Fighter2.SetChoosing(true);
                actionWords2 = Fighter2.GetLeftName();
                letter2 = 'j';
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                Fighter2.SetChoosing(true);
                actionWords2 = Fighter2.GetDownName();
                letter2 = 'k';
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                Fighter2.SetChoosing(true);
                actionWords2 = Fighter2.GetRightName();
                letter2 = 'l';
            }
        }
        else if (Fighter2.GetAttacker())
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                Fighter2.SetChoosing(true);
                actionWords2 = Fighter2.GetUpName();
                letter2 = 'i';
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                Fighter2.SetChoosing(true);
                actionWords2 = Fighter2.GetLeftName();
                letter2 = 'j';
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                Fighter2.SetChoosing(true);
                actionWords2 = Fighter2.GetDownName(); //Actually does nothing for now
                letter2 = 'k';
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                Fighter2.SetChoosing(true);
                actionWords2 = Fighter2.GetRightName();
                letter2 = 'l';
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                Fighter1.SetChoosing(true);
                actionWords1 = Fighter1.GetUpName();
                letter1 = 'w';
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                Fighter1.SetChoosing(true);
                actionWords1 = Fighter1.GetLeftName();
                letter1 = 'a';
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                Fighter1.SetChoosing(true);
                actionWords1 = Fighter1.GetDownName();
                letter1 = 's';
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                Fighter1.SetChoosing(true);
                actionWords1 = Fighter1.GetRightName();
                letter1 = 'd';
            }
        } 
    }

    public void CalcingResults()
    {
        if (Fighter1.GetAttacker())
            {
                if (actionWords1.Equals("Magic Attk"))
                {
                    switch (letter2)
                    {
                        case 'i':
                            results = "P2 blocked P1's Magic Attk. ";
                            results2 = "Battle Continues";
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

                if (actionWords1.Equals("Basic Attk"))
                {
                    switch (letter2)
                    {
                        case 'i':
                            results = "P2 was hit P1 wins";
                            break;

                        case 'j':
                            results = "P2 blocked P1's Basic Attk. ";
                            results2 = "Battle Continues";
                            break;

                        case 'k':
                            results = "P2 was hit P1 wins";
                            break;

                        case 'l':
                            results = "P2 was hit P1 wins";
                            break;
                    }
                }

                if (actionWords1.Equals("Buff Attk"))
                {
                    switch (letter2)
                    {
                        case 'i':
                            results = "Nothing happened. Battle Continues";
                            results2 = "Battle Continues";
                            break;

                        case 'j':
                            results = "Nothing happened. Battle Continues";
                            results2 = "Battle Continues";
                            break;

                        case 'k':
                            results = "P2 was hit P1 wins";
                            break;

                        case 'l':
                            results = "Nothing happened. Battle Continues";
                            results2 = "Battle Continues";
                            break;
                    }
                }

                if (actionWords1.Equals("Combo Attk"))
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

            if (Fighter2.GetAttacker())
            {
                if (actionWords2.Equals("Magic Attk"))
                {
                    switch (letter1)
                    {
                        case 'w':
                            results = "P1 blocked P2's Magic Attk. ";
                            results2 = "Battle Continues";
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

                if (actionWords2.Equals("Basic Attk"))
                {
                    switch (letter1)
                    {
                        case 'w':
                            results = "P1 was hit P2 wins";
                            break;

                        case 'a':
                            results = "P1 blocked P2's Basic Attk. ";
                            results2 = "Battle Continues";
                            break;

                        case 's':
                            results = "P1 was hit P2 wins";
                            break;

                        case 'd':
                            results = "P1 was hit P2 wins";
                            break;
                    }
                }

                if (actionWords2.Equals("Buff Attk"))
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
                            results = "P1 was hit P2 wins";
                            break;

                        case 'd':
                            results = "Nothing happened. ";
                            results2 = "Battle Continues";
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
        
    } 
}
