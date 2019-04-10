﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleSystem : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject p1Prefab;
    public GameObject p2Prefab;
    //public Player PlayerStats;
    public Player Fighter2;
    public BattleTurns BattleCounter;
    public Results BattleResults;
    public bool unloaded;
    public bool loaded;
    public float endDelay = 2f;
    public int scene = 1;

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
    public GameObject fighterGO1;
    public GameObject fighterGO2;


    // Use this for initialization
    void Awake()
    {
        print("Battle Start!");
        fighterGO1 = Instantiate(p1Prefab) as GameObject;
        fighterGO2 = Instantiate(p2Prefab) as GameObject;
        //alive = true;
        /*if (PlayerPrefs.HasKey("HP"))
        {
            StatStorage.GetAllStats();
        }
        else
        {
            PlayerStats.SetStats();
            StatStorage.SetAllStats(PlayerStats.GetHP(), PlayerStats.GetMaxHP(), PlayerStats.GetAttk(), PlayerStats.GetAttkBase(), PlayerStats.GetDef(), PlayerStats.GetDefBase(), PlayerStats.GetMagicAttk(), PlayerStats.GetMagicAttkBase(), PlayerStats.GetMagicDef(), PlayerStats.GetMagicDefBase());
            PlayerPrefs.Save();
        }
        
        if(StatStorage.GetHPValue() != PlayerStats.GetHP())
        {
            PlayerStats.SetHP(StatStorage.GetHPValue());
        }
        StatStorage.GetAllStats();
        StatStorage.Save();
        */
        //PlayerStats.SetStats();
        //StatStorage.SetAllStats(PlayerStats.GetHP(), PlayerStats.GetMaxHP(), PlayerStats.GetAttk(), PlayerStats.GetAttkBase(), PlayerStats.GetDef(), PlayerStats.GetDefBase(), PlayerStats.GetMagicAttk(), PlayerStats.GetMagicAttkBase(), PlayerStats.GetMagicDef(), PlayerStats.GetMagicDefBase());

        Fighter2.SetStats();
        Fighter2.SetPlayerName("Player 2 ");
        PlayerStats.InBattle = true;
        unloaded = false;
        PlayerStats.IsAttacker = true;
        Fighter2.IsAttacking(false);
        PlayerStats.SetNameBasedOnTurn();
        Fighter2.SetNameBasedOnTurn();
        /*PlayerStats.SetAlive(true);
        Fighter2.SetAlive(true);
        PlayerStats.SetInBattle(true);
        Fighter2.SetInBattle(true);
        //turnOfP1 = true;
        //turnOfP2 = false;
        //p1Chose = false;
        //p2Chose = false;
        PlayerStats.GetChoosing();
        Fighter2.GetChoosing();
        letter1 = 'x';
        letter2 = 'x';*/
    }

    // Update is called once per frame
    void Update()
    {
        if(!unloaded)
        {
            unloaded = true;

            ManagerClass.Manager.UnloadScene(scene);
        }

        if (PlayerStats.Alive && Fighter2.GetAlive())
        {
            if (!(PlayerStats.Choosing && Fighter2.GetChoosing()))
            {
                ChoosingActions();
            }
            if (PlayerStats.Choosing && Fighter2.GetChoosing())
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

    private void LateUpdate()
    {
        PlayerPrefManager.PrefManager.Save();
    }

    public void TurnResults()
    {

        if (results2.Equals("P2 was deafeated. "))
        {
            Destroy(fighterGO2);
            print(results + results2 + theWinner);
            BattleResults.NewTurnText(results + results2 + theWinner);
            Fighter2.SetAlive(false);
            PlayerStats.EXP += 5;
            if(PlayerStats.EXP >= PlayerStats.MaxEXP)
            {
                PlayerStats.LevelUp();
            }
            PlayerStats.RestoreStats();
            PlayerStats.InBattle = false;
            PlayerPrefManager.PrefManager.Save();
            DelayedOWReturn(endDelay);

        }
        else if (results2.Equals("P1 was deafeated. "))
        {
            Destroy(fighterGO1);
            print(results + results2 + theWinner);
            BattleResults.NewTurnText(results + results2 + theWinner);
            PlayerStats.Alive = false;
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

            if (PlayerStats.IsAttacker)
            {
                PlayerStats.IsAttacker = false;
                Fighter2.IsAttacking(true);
            }
            else if (Fighter2.GetAttacker())
            {
                Fighter2.IsAttacking(false);
                PlayerStats.IsAttacker = true;
            }

            PlayerStats.Choosing = false;
            Fighter2.SetChoosing(false);
            PlayerStats.SetNameBasedOnTurn();
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
            PlayerStats.Choosing = false;
            Fighter2.SetChoosing(false);
        }
    }

    public void ChoosingActions()
    {
        if (PlayerStats.IsAttacker)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                PlayerStats.Choosing = true;
                actionWords1 = PlayerStats.UpName;
                letter1 = 'w';
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                PlayerStats.Choosing = true;
                actionWords1 = PlayerStats.LeftName;
                letter1 = 'a';
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                PlayerStats.Choosing = true;
                actionWords1 = PlayerStats.DownName; //Actually does nothing for now
                letter1 = 's';
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                PlayerStats.Choosing = true;
                actionWords1 = PlayerStats.RightName;
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
                PlayerStats.Choosing = true;
                actionWords1 = PlayerStats.UpName;
                letter1 = 'w';
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                PlayerStats.Choosing = true;
                actionWords1 = PlayerStats.LeftName;
                letter1 = 'a';
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                PlayerStats.Choosing = true;
                actionWords1 = PlayerStats.DownName;
                letter1 = 's';
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                PlayerStats.Choosing = true;
                actionWords1 = PlayerStats.RightName;
                letter1 = 'd';
            }
        }
    }

    public void CalcingResults()
    {
        if (PlayerStats.IsAttacker)
        {
            if (actionWords1.Equals("Magic Attk"))
            {
                switch (letter2)
                {
                    case 'i':
                        results = "P1 used Magic Attk. P2 shielded it. ";
                        PlayerStats.SetTurnDamage(PlayerStats.MagicAttk, Fighter2.GetMagicDef());
                        Fighter2.TakeDamage(PlayerStats.GetTurnDamage());
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
                        PlayerStats.SetTurnDamage(PlayerStats.MagicAttk, -1);
                        Fighter2.TakeDamage(PlayerStats.GetTurnDamage());
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
                        Fighter2.SetARandomStatBuff(1);
                        PlayerStats.SetTurnDamage(PlayerStats.MagicAttk, -1);
                        Fighter2.TakeDamage(PlayerStats.GetTurnDamage());
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
                        PlayerStats.SetTurnDamage(PlayerStats.MagicAttk, -2);
                        Fighter2.TakeDamage(PlayerStats.GetTurnDamage());
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
                        PlayerStats.SetTurnDamage(PlayerStats.Attk, -1);
                        Fighter2.TakeDamage(PlayerStats.GetTurnDamage());
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
                        PlayerStats.SetTurnDamage(PlayerStats.Attk, Fighter2.GetDef());
                        Fighter2.TakeDamage(PlayerStats.GetTurnDamage());
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
                        PlayerStats.SetTurnDamage(PlayerStats.Attk, -1);
                        Fighter2.TakeDamage(PlayerStats.GetTurnDamage());
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
                        PlayerStats.SetTurnDamage(PlayerStats.Attk, -2);
                        Fighter2.TakeDamage(PlayerStats.GetTurnDamage());
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
                        PlayerStats.SetARandomStatBuff(1);
                        results2 = "Battle Continues";
                        break;

                    case 'j':
                        results = "P1 used Random Buff, P2 used Guard. ";
                        PlayerStats.SetARandomStatBuff(1);
                        results2 = "Battle Continues";
                        break;

                    case 'k':
                        results = "P1 used Random Buff, P2 also used Random Buff ";
                        PlayerStats.SetARandomStatBuff(1);
                        Fighter2.SetARandomStatBuff(1);
                        results2 = "Battle Continues";
                        break;

                    case 'l':
                        results = "P1 used Random Buff, P2 used Counter. Nothing happened. ";
                        PlayerStats.SetARandomStatBuff(1);
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
                        PlayerStats.SetTurnDamage((PlayerStats.Attk + PlayerStats.MagicAttk), -1);
                        Fighter2.TakeDamage(PlayerStats.GetTurnDamage());
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
                        PlayerStats.SetTurnDamage((PlayerStats.Attk + PlayerStats.MagicAttk), -1);
                        Fighter2.TakeDamage(PlayerStats.GetTurnDamage());
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
                        PlayerStats.SetTurnDamage((PlayerStats.Attk + PlayerStats.MagicAttk), -1);
                        Fighter2.TakeDamage(PlayerStats.GetTurnDamage());
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
                        PlayerStats.TakeDamage(Fighter2.GetTurnDamage());
                        if (PlayerStats.HP <= 0)
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
                        PlayerStats.TakeDamage(Fighter2.GetTurnDamage());
                        if (PlayerStats.HP <= 0)
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
                        PlayerStats.TakeDamage(Fighter2.GetTurnDamage());
                        if (PlayerStats.HP <= 0)
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
                        PlayerStats.SetARandomStatBuff(1);
                        Fighter2.SetTurnDamage(Fighter2.GetAttk(), -1);
                        PlayerStats.TakeDamage(Fighter2.GetTurnDamage());
                        if (PlayerStats.HP <= 0)
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
                        PlayerStats.TakeDamage(Fighter2.GetTurnDamage());
                        if (PlayerStats.HP <= 0)
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
                        PlayerStats.TakeDamage(Fighter2.GetTurnDamage());
                        if (PlayerStats.HP <= 0)
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
                        Fighter2.SetTurnDamage(Fighter2.GetAttk(), PlayerStats.Def);
                        PlayerStats.TakeDamage(Fighter2.GetTurnDamage());
                        if (PlayerStats.HP <= 0)
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
                        PlayerStats.SetARandomStatBuff(1);
                        Fighter2.SetTurnDamage(Fighter2.GetAttk(), -1);
                        PlayerStats.TakeDamage(Fighter2.GetTurnDamage());
                        if (PlayerStats.HP <= 0)
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
                        PlayerStats.TakeDamage(Fighter2.GetTurnDamage());
                        if (PlayerStats.HP <= 0)
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
                        PlayerStats.SetARandomStatBuff(1);
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
                        PlayerStats.TakeDamage(Fighter2.GetTurnDamage());;
                        if (PlayerStats.HP <= 0)
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
                        PlayerStats.TakeDamage(Fighter2.GetTurnDamage());
                        if (PlayerStats.HP <= 0)
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
                        PlayerStats.SetARandomStatBuff(1);
                        Fighter2.SetTurnDamage((Fighter2.GetAttk() + Fighter2.GetMagicAttk()), -1);
                        PlayerStats.TakeDamage(Fighter2.GetTurnDamage());
                        if (PlayerStats.HP <= 0)
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
                        PlayerStats.SetTurnDamage((PlayerStats.Attk + PlayerStats.MagicAttk), -1);
                        Fighter2.TakeDamage(PlayerStats.GetTurnDamage());
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
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        ManagerClass.Manager.UnloadScene(scene + 1);

    }

}