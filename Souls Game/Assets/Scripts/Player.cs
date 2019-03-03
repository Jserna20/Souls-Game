using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject playerPrefab;
    public int hp;
    public int maxHP;
    public int attkBase;
    public int defBase;
    public int magicBase;
    public int magic;
    public int attk;
    public int def;
    public bool alive;
    public bool defeated;
    public bool inBattle;
    public bool isAttacker;
    public bool choosing;
    public string upName;
    public string leftName;
    public string downName;
    public string rightName;
    public string playerName;

    public GameObject person;
    

	// Use this for initialization
	/*void Awake ()
    {
        SetStats();
	}*/
	
    public void SetStats()
    {
        CreatePerson();
        maxHP = 40;
        hp = maxHP;
        attkBase = 2;
        defBase = 2;
        magicBase = 2;
        attk = attkBase;
        def = defBase;
        magic = magicBase;
        inBattle = false;
        alive = true;
        defeated = false;
        inBattle = false;
        choosing = false;
    }

    public void RestoreHP()
    {
        hp = maxHP;
    }

    public void SetHP(int newHP)
    {
        hp = newHP;
    }

    public int GetHP()
    {
        return hp;
    }

    public void SetAttk(int newAttk)
    {
        attk = newAttk;
    }

    public int GetAttk()
    {
        return attk;
    }

    public void SetDef(int newDef)
    {
        def = newDef;
    }

    public int GetDef()
    {
        return def;
    }

    public void SetMagic(int newMagic)
    {
        magic = newMagic;
    }

    public int GetMagic()
    {
        return magic;
    }

    public void SetAlive(bool cond)
    {
        alive = cond;
    }

    public bool GetAlive()
    {
        return alive;
    }

    public void SetDefeated(bool cond)
    {
        defeated = cond;
    }

    public bool GetDefeated()
    {
        return defeated;
    }

    public void SetInBattle(bool cond)
    {
        inBattle = cond;
    }

    public bool GetInBattle()
    {
        return inBattle;
    }

    public void CreatePerson()
    {
        person = Instantiate(playerPrefab) as GameObject;
    }

    public GameObject GetPerson()
    {
        return person;
    }

    public void IsAttacking(bool cond)
    {
        isAttacker = cond;
    }

    public bool GetAttacker()
    {
        return isAttacker;
    }

    public void SetChoosing(bool cond)
    {
        choosing = cond;
    }

    public bool GetChoosing()
    {
        return choosing;
    }

    public void DestroyMe()
    {
        Destroy(person);
    }

    public void SetUpName(string name)
    {
        upName = name;
    }

    public string GetUpName()
    {
        return upName;
    }

    public void SetLeftName(string name)
    {
        leftName = name;
    }

    public string GetLeftName()
    {
        return leftName;
    }

    public void SetDownName(string name)
    {
        downName = name;
    }

    public string GetDownName()
    {
        return downName;
    }

    public void SetRightName(string name)
    {
        rightName = name;
    }

    public string GetRightName()
    {
        return rightName;
    }

    public void SetNameBasedOnTurn()
    {
        if(GetAttacker())
        {
            SetUpName("Magic Attk");
            SetLeftName("Basic Attk");
            SetDownName("Buff Attk");
            SetRightName("Combo Attk");
        }
        else
        {
            SetUpName("Magic Shield");
            SetLeftName("Guard");
            SetDownName("I give up");
            SetRightName("Combo Attk");
        }

    }

    public void SetPlayerName(string newPlayerName)
    {
        playerName = newPlayerName;
    }

    public string GetPlayerName()
    {
        return playerName;
    }
}
