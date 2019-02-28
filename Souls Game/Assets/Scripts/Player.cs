using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Player S;
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
    public bool isDefender;

    public GameObject player;
    

	// Use this for initialization
	void Awake ()
    {
        SetStats();
	}
	
    public void SetStats()
    {
        maxHP = 100;
        hp = maxHP;
        attkBase = 4;
        defBase = 4;
        magicBase = 4;
        attk = attkBase;
        def = defBase;
        magic = magicBase;
        inBattle = false;
        alive = true;
        defeated = false;
        inBattle = false;
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

    public void SetPlayer()
    {
        player = Instantiate(playerPrefab) as GameObject;
    }

    public GameObject GetPlayer()
    {
        return player;
    }

    public void IsAttacking(bool cond)
    {
        isAttacker = cond;
    }

    public bool GetAttacker()
    {
        return isAttacker;
    }
}
