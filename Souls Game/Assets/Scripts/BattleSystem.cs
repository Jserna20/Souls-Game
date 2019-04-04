using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleSystem : MonoBehaviour
{
    [Header("Set in Inspector")]
    //public GameObject p1Prefab;
    //public GameObject p2Prefab;
    public Player Fighter1;
    public Player Fighter2;
    public BattleTurns BattleCounter;
    public Results BattleResults;
    public float endDelay = 2f;
    public PlayerPrefManager StatStorage;

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
    public string theWinner;

    //public GameObject fighterGO1;
    //public GameObject fighterGO2;


    // Use this for initialization
    void Awake()
    {
        print("Battle Start!");
        //fighterGO1 = Instantiate(p1Prefab) as GameObject;
        //fighterGO2 = Instantiate(p2Prefab) as GameObject;
        //alive = true;
        Fighter1.CreatePerson();
        Fighter2.CreatePerson();
        if (PlayerPrefs.HasKey("HP"))
        {
            StatStorage.GetAllStats();
        }
        else
        {
            Fighter1.SetStats();
            StatStorage.SetAllStats(Fighter1.GetHP(), Fighter1.GetMaxHP(), Fighter1.GetAttk(), Fighter1.GetAttkBase(), Fighter1.GetDef(), Fighter1.GetDefBase(), Fighter1.GetMagicAttk(), Fighter1.GetMagicAttkBase(), Fighter1.GetMagicDef(), Fighter1.GetMagicDefBase());
            PlayerPrefs.Save();
        }
        Fighter2.SetStats();
        Fighter1.SetPlayerName("Player 1 ");
        Fighter2.SetPlayerName("Player 2 ");
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
    void Update()
    {
        if (Fighter1.GetAlive() && Fighter2.GetAlive())
        {
            if (!(Fighter1.GetChoosing() && Fighter2.GetChoosing()))
            {
                ChoosingActions();
            }
            if (Fighter1.GetChoosing() && Fighter2.GetChoosing())
            {
                CalcingResults();
                TurnResults();
            }
        }

        //Just to not have to exit play mode to reset
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Restart();
        }

    }

    public void TurnResults()
    {

        if (results2.Equals("P2 was deafeated. "))
        {
            Fighter2.DestroyMe();
            print(results + results2 + theWinner);
            BattleResults.NewTurnText(results + results2 + theWinner);
            //alive = false;
            Fighter2.SetAlive(false);
            StatStorage.SetAllStats(Fighter1.GetHP(), Fighter1.GetMaxHP(), Fighter1.GetAttk(), Fighter1.GetAttkBase(), Fighter1.GetDef(), Fighter1.GetDefBase(), Fighter1.GetMagicAttk(), Fighter1.GetMagicAttkBase(), Fighter1.GetMagicDef(), Fighter1.GetMagicDefBase());
            PlayerPrefs.Save();
            DelayedOWReturn(endDelay);

        }
        else if (results2.Equals("P1 was deafeated. "))
        {
            Fighter1.DestroyMe();
            print(results + results2 + theWinner);
            BattleResults.NewTurnText(results + results2 + theWinner);
            //alive = false;
            Fighter1.SetAlive(false);
        }
        else if (results2.Equals("Battle Continues"))
        {
            print(results + results2);
            BattleResults.NewTurnText(results + results2);
            BattleCounter.IncreaseTurn();
            actionWords1 = "";
            actionWords2 = "";
            results = "";
            results2 = "";
            letter1 = 'x';
            letter2 = 'x';
            //p1Chose = false;
            //p2Chose = false;

            if (Fighter1.GetAttacker())
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
        else
        {
            //Will reset the turn without changing it
            print("Results: " + results);
            actionWords1 = "";
            actionWords2 = "";
            results = "";
            theWinner = "";
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

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Fighter2.SetChoosing(true);
                actionWords2 = Fighter2.GetUpName();
                letter2 = 'i';
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Fighter2.SetChoosing(true);
                actionWords2 = Fighter2.GetLeftName();
                letter2 = 'j';
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Fighter2.SetChoosing(true);
                actionWords2 = Fighter2.GetDownName();
                letter2 = 'k';
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Fighter2.SetChoosing(true);
                actionWords2 = Fighter2.GetRightName();
                letter2 = 'l';
            }
        }
        else if (Fighter2.GetAttacker())
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Fighter2.SetChoosing(true);
                actionWords2 = Fighter2.GetUpName();
                letter2 = 'i';
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Fighter2.SetChoosing(true);
                actionWords2 = Fighter2.GetLeftName();
                letter2 = 'j';
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Fighter2.SetChoosing(true);
                actionWords2 = Fighter2.GetDownName();
                letter2 = 'k';
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
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
                        results = "P1 used Magic Attk. P2 shielded it. ";
                        Fighter1.SetTurnDamage(Fighter1.GetMagicAttk(), Fighter2.GetMagicDef());
                        Fighter2.TakeDamage(Fighter1.GetTurnDamage());
                        if (Fighter2.GetHP() <= 0)
                        {
                            results2 = "P2 was deafeated. ";
                            theWinner = "P1 wins";
                        }
                        else
                        {
                            results2 = "Battle Continues";
                        }
                        break;

                    case 'j':
                        results = "P1 used Magic Attk. P2 was hit. ";
                        Fighter1.SetTurnDamage(Fighter1.GetMagicAttk(), -1);
                        Fighter2.TakeDamage(Fighter1.GetTurnDamage());
                        if (Fighter2.GetHP() <= 0)
                        {
                            results2 = "P2 was deafeated. ";
                            theWinner = "P1 wins";
                        }
                        else
                        {
                            results2 = "Battle Continues";
                        }
                        break;

                    case 'k':
                        results = "P2 used Random Buff, but was still hit by P1's Magic Attk. ";
                        Fighter2.SetAttk((Fighter2.GetMagicAttk() + 1));
                        Fighter1.SetTurnDamage(Fighter1.GetAttk(), -1);
                        Fighter2.TakeDamage(Fighter1.GetTurnDamage());
                        if (Fighter2.GetHP() <= 0)
                        {
                            results2 = "P2 was deafeated. ";
                            theWinner = "P1 wins";
                        }
                        else
                        {
                            results2 = "Battle Continues";
                        }
                        break;

                    case 'l':
                        results = "P2 used Counter, but failed and was hit harder. ";
                        Fighter1.SetTurnDamage(Fighter1.GetMagicAttk(), -2);
                        Fighter2.TakeDamage(Fighter1.GetTurnDamage());
                        if (Fighter2.GetHP() <= 0)
                        {
                            results2 = "P2 was deafeated. ";
                            theWinner = "P1 wins";
                        }
                        else
                        {
                            results2 = "Battle Continues";
                        }
                        break;
                }
            }

            if (actionWords1.Equals("Basic Attk"))
            {
                switch (letter2)
                {
                    case 'i':
                        results = "P1 used Basic Attk. P2 was hit. ";
                        Fighter1.SetTurnDamage(Fighter1.GetAttk(), -1);
                        Fighter2.TakeDamage(Fighter1.GetTurnDamage());
                        if (Fighter2.GetHP() <= 0)
                        {
                            results2 = "P2 was deafeated. ";
                            theWinner = "P1 wins";
                        }
                        else
                        {
                            results2 = "Battle Continues";
                        }
                        break;

                    case 'j':
                        results = "P1 used Basic Attk. P2 guarded it. ";
                        Fighter1.SetTurnDamage(Fighter1.GetAttk(), Fighter2.GetDef());
                        Fighter2.TakeDamage(Fighter1.GetTurnDamage());
                        if (Fighter2.GetHP() <= 0)
                        {
                            results2 = "P2 was deafeated. ";
                            theWinner = "P1 wins";
                        }
                        else
                        {
                            results2 = "Battle Continues";
                        }
                        break;

                    case 'k':
                        results = "P2 used Random Buff, but was still hit. ";
                        Fighter2.SetARandomStatBuff(1);
                        Fighter1.SetTurnDamage(Fighter1.GetAttk(), -1);
                        Fighter2.TakeDamage(Fighter1.GetTurnDamage());
                        if (Fighter2.GetHP() <= 0)
                        {
                            results2 = "P2 was deafeated. ";
                            theWinner = "P1 wins";
                        }
                        else
                        {
                            results2 = "Battle Continues";
                        }
                        break;

                    case 'l':
                        results = "P2 used Counter, but failed and was hit harder. ";
                        Fighter1.SetTurnDamage(Fighter1.GetAttk(), -2);
                        Fighter2.TakeDamage(Fighter1.GetTurnDamage());
                        if (Fighter2.GetHP() <= 0)
                        {
                            results2 = "P2 was deafeated. ";
                            theWinner = "P1 wins";
                        }
                        else
                        {
                            results2 = "Battle Continues";
                        }
                        break;
                }
            }

            if (actionWords1.Equals("Random Buff"))
            {
                switch (letter2)
                {
                    case 'i':
                        results = "P1 used Random Buff, P2 used Magic Shield ";
                        Fighter1.SetARandomStatBuff(1);
                        results2 = "Battle Continues";
                        break;

                    case 'j':
                        results = "P1 used Random Buff, P2 used Guard. ";
                        Fighter1.SetARandomStatBuff(1);
                        results2 = "Battle Continues";
                        break;

                    case 'k':
                        results = "P1 used Random Buff, P2 also used Random Buff ";
                        Fighter1.SetARandomStatBuff(1);
                        Fighter2.SetARandomStatBuff(1);
                        results2 = "Battle Continues";
                        break;

                    case 'l':
                        results = "P1 used Random Buff, P2 used Counter. Nothing happened. ";
                        Fighter1.SetARandomStatBuff(1);
                        results2 = "Battle Continues";
                        break;
                }
            }

            if (actionWords1.Equals("Combo Attk"))
            {
                switch (letter2)
                {
                    case 'i':
                        results = "P1 used Combo Attack. P2 was hit by it. ";
                        Fighter1.SetTurnDamage((Fighter1.GetAttk() + Fighter1.GetMagicAttk()), -1);
                        Fighter2.TakeDamage(Fighter1.GetTurnDamage());
                        if (Fighter2.GetHP() <= 0)
                        {
                            results2 = "P2 was deafeated. ";
                            theWinner = "P1 wins";
                        }
                        else
                        {
                            results2 = "Battle Continues";
                        }
                        break;

                    case 'j':
                        results = "P1 used Combo Attack. P2 was hit by it. ";
                        Fighter1.SetTurnDamage((Fighter1.GetAttk() + Fighter1.GetMagicAttk()), -1);
                        Fighter2.TakeDamage(Fighter1.GetTurnDamage());
                        if (Fighter2.GetHP() <= 0)
                        {
                            results2 = "P2 was deafeated. ";
                            theWinner = "P1 wins";
                        }
                        else
                        {
                            results2 = "Battle Continues";
                        }
                        break;

                    case 'k':
                        results = "P1 used Combo Attack. P2 was hit by it. ";
                        Fighter2.SetARandomStatBuff(1);
                        Fighter1.SetTurnDamage((Fighter1.GetAttk() + Fighter1.GetMagicAttk()), -1);
                        Fighter2.TakeDamage(Fighter1.GetTurnDamage());
                        if (Fighter2.GetHP() <= 0)
                        {
                            results2 = "P2 was deafeated. ";
                            theWinner = "P1 wins";
                        }
                        else
                        {
                            results2 = "Battle Continues";
                        }
                        break;

                    case 'l':
                        results = "P1 used Combo Attack. P2 used Counter. P2 hit P1. ";
                        Fighter2.SetTurnDamage((Fighter2.GetAttk() + Fighter2.GetMagicAttk()), -1);
                        Fighter1.TakeDamage(Fighter2.GetTurnDamage());
                        if (Fighter1.GetHP() <= 0)
                        {
                            results2 = "P1 was deafeated. ";
                            theWinner = "P2 wins";
                        }
                        else
                        {
                            results2 = "Battle Continues";
                        }
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
                        results = "P2 used Magic Attk. P1 shielded it. ";
                        Fighter2.SetTurnDamage(Fighter2.GetMagicAttk(), Fighter2.GetMagicDef());
                        Fighter1.TakeDamage(Fighter2.GetTurnDamage());
                        if (Fighter1.GetHP() <= 0)
                        {
                            results2 = "P1 was deafeated. ";
                            theWinner = "P2 wins";
                        }
                        else
                        {
                            results2 = "Battle Continues";
                        }
                        break;

                    case 'a':
                        results = "P2 used Magic Attk. P1 was hit. ";
                        Fighter2.SetTurnDamage(Fighter2.GetAttk(), -1);
                        Fighter1.TakeDamage(Fighter2.GetTurnDamage());
                        if (Fighter1.GetHP() <= 0)
                        {
                            results2 = "P1 was deafeated. ";
                            theWinner = "P2 wins";
                        }
                        else
                        {
                            results2 = "Battle Continues";
                        }
                        break;

                    case 's':
                        results = "P1 used Random Buff, but was still hit by P2's Magic Attk. ";
                        Fighter1.SetARandomStatBuff(1);
                        Fighter2.SetTurnDamage(Fighter2.GetAttk(), -1);
                        Fighter1.TakeDamage(Fighter2.GetTurnDamage());
                        if (Fighter1.GetHP() <= 0)
                        {
                            results2 = "P2 was deafeated. ";
                            theWinner = "P1 wins";
                        }
                        else
                        {
                            results2 = "Battle Continues";
                        }
                        break;

                    case 'd':
                        results = "P1 used Counter, but failed and was hit harder. ";
                        Fighter2.SetTurnDamage(Fighter2.GetAttk(), -2);
                        Fighter1.TakeDamage(Fighter2.GetTurnDamage());
                        if (Fighter1.GetHP() <= 0)
                        {
                            results2 = "P2 was deafeated. ";
                            theWinner = "P1 wins";
                        }
                        else
                        {
                            results2 = "Battle Continues";
                        }
                        break;
                }
            }

            if (actionWords2.Equals("Basic Attk"))
            {
                switch (letter1)
                {
                    case 'w':
                        results = "P2 used Basic Attk. P1 was hit. ";
                        Fighter2.SetTurnDamage(Fighter2.GetAttk(), -1);
                        Fighter1.TakeDamage(Fighter2.GetTurnDamage());
                        if (Fighter1.GetHP() <= 0)
                        {
                            results2 = "P1 was deafeated. ";
                            theWinner = "P2 wins";
                        }
                        else
                        {
                            results2 = "Battle Continues";
                        }
                        break;

                    case 'a':
                        results = "P2 used Basic Attk. P1 guarded it. ";
                        Fighter2.SetTurnDamage(Fighter2.GetAttk(), Fighter1.GetDef());
                        Fighter1.TakeDamage(Fighter2.GetTurnDamage());
                        if (Fighter1.GetHP() <= 0)
                        {
                            results2 = "P1 was deafeated. ";
                            theWinner = "P2 wins";
                        }
                        else
                        {
                            results2 = "Battle Continues";
                        }
                        break;

                    case 's':
                        results = "P1 used Random Buff, but was still hit. ";
                        Fighter1.SetARandomStatBuff(1);
                        Fighter2.SetTurnDamage(Fighter2.GetAttk(), -1);
                        Fighter1.TakeDamage(Fighter2.GetTurnDamage());
                        if (Fighter1.GetHP() <= 0)
                        {
                            results2 = "P1 was deafeated. ";
                            theWinner = "P2 wins";
                        }
                        else
                        {
                            results2 = "Battle Continues";
                        }
                        break;

                    case 'd':
                        results = "P1 used Counter, but failed and was hit harder. ";
                        Fighter2.SetTurnDamage(Fighter2.GetAttk(), -2);
                        Fighter1.TakeDamage(Fighter2.GetTurnDamage());
                        if (Fighter1.GetHP() <= 0)
                        {
                            results2 = "P1 was deafeated. ";
                            theWinner = "P2 wins";
                        }
                        else
                        {
                            results2 = "Battle Continues";
                        }
                        break;
                }
            }

            if (actionWords2.Equals("Random Buff"))
            {
                switch (letter1)
                {
                    case 'w':
                        results = "P2 used Random Buff, P1 used Magic Shield ";
                        Fighter2.SetARandomStatBuff(1);
                        results2 = "Battle Continues";
                        break;

                    case 'a':
                        results = "P2 used Random Buff, P1 used Guard. ";
                        Fighter2.SetARandomStatBuff(1);
                        results2 = "Battle Continues";
                        break;

                    case 's':
                        results = "P2 used Random Buff, P1 also used Random Buff ";
                        Fighter2.SetARandomStatBuff(1);
                        Fighter1.SetARandomStatBuff(1);
                        results2 = "Battle Continues";
                        break;

                    case 'd':
                        results = "P2 used Random Buff, P1 used Counter. Nothing happened. ";
                        Fighter2.SetARandomStatBuff(1);
                        results2 = "Battle Continues";
                        break;
                }
            }

            if (actionWords2.Equals("Combo Attk"))
            {
                switch (letter1)
                {
                    case 'w':
                        results = "P2 used Combo Attack. P1 was hit by it. ";
                        Fighter2.SetTurnDamage((Fighter2.GetAttk() + Fighter2.GetMagicAttk()), -1);
                        Fighter1.TakeDamage(Fighter2.GetTurnDamage());
                        if (Fighter1.GetHP() <= 0)
                        {
                            results2 = "P1 was deafeated. ";
                            theWinner = "P2 wins";
                        }
                        else
                        {
                            results2 = "Battle Continues";
                        }
                        break;

                    case 'a':
                        results = "P2 used Combo Attack. P1 was hit by it. ";
                        Fighter2.SetTurnDamage((Fighter2.GetAttk() + Fighter2.GetMagicAttk()), -1);
                        Fighter1.TakeDamage(Fighter2.GetTurnDamage());
                        if (Fighter1.GetHP() <= 0)
                        {
                            results2 = "P1 was deafeated. ";
                            theWinner = "P2 wins";
                        }
                        else
                        {
                            results2 = "Battle Continues";
                        }
                        break;

                    case 's':
                        results = "P2 used Combo Attack. P1 was hit by it. ";
                        Fighter1.SetARandomStatBuff(1);
                        Fighter2.SetTurnDamage((Fighter2.GetAttk() + Fighter2.GetMagicAttk()), -1);
                        Fighter1.TakeDamage(Fighter2.GetTurnDamage());
                        if (Fighter1.GetHP() <= 0)
                        {
                            results2 = "P1 was deafeated. ";
                            theWinner = "P2 wins";
                        }
                        else
                        {
                            results2 = "Battle Continues";
                        }
                        break;

                    case 'd':
                        results = "P2 used Combo Attack. P1 used Counter. P1 hit P2. ";
                        Fighter1.SetTurnDamage((Fighter1.GetAttk() + Fighter1.GetMagicAttk()), -1);
                        Fighter2.TakeDamage(Fighter1.GetTurnDamage());
                        if (Fighter2.GetHP() <= 0)
                        {
                            results2 = "P2 was deafeated. ";
                            theWinner = "P1 wins";
                        }
                        else
                        {
                            results2 = "Battle Continues";
                        }
                        break;
                }
            }
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene("TestBattle");
    }

    public void DelayedOWReturn(float delay)
    {
        Invoke("BackToOW", delay);
    }

    public void BackToOW()
    {
        SceneManager.LoadScene("TestBoard");
    }

}