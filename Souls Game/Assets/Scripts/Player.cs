using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject playerPrefab;
    public float hp;
    public float maxHP;
    public float attkBase;
    public float defBase;
    public float magicAttkBase;
    public float magicDefBase;
    public float magicAttk;
    public float magicDef;
    public float attk;
    public float def;
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
    public float turndamage;
    public int numToDetermineStatBuff;
    public int exp;
    public int maxEXP;
    public int lvl;

    public GameObject person;
    

	// Use this for initialization
	/*void Awake ()
    {
        SetStats();
	}*/
	
    public void SetStats()
    {
        lvl = 1;
        maxHP = 10;
        hp = maxHP;
        attkBase = 2;
        defBase = 2;
        magicAttkBase = 2;
        magicDefBase = 2;
        exp = 0;
        maxEXP = 10;
        attk = attkBase;
        def = defBase;
        magicAttk = magicAttkBase;
        magicDef = magicDefBase;
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

    public void RestoreStats()
    {
        attk = attkBase;
        def = defBase;
        magicAttk = magicAttkBase;
        magicDef = magicDefBase;
    }

    public void LevelUp()
    {
        RestoreHP();
        RestoreStats();
        exp = 0;
        maxEXP += 10;
        lvl++;
    }

    public int GetLvl()
    {
        return lvl;
    }

    public int GetMaxEXP()
    {
        return maxEXP;
    }

    public int GetExp()
    {
        return exp;
    }


    public void SetHP(float newHP)
    {
        hp = newHP;
    }

    public float GetHP()
    {
        return hp;
    }

    public void SetMaxHP(float newMax)
    {
        maxHP = newMax;
    }

    public float GetMaxHP()
    {
        return maxHP;
    }


    public void SetAttk(float newAttk)
    {
        attk = newAttk;
    }

    public float GetAttk()
    {
        return attk;
    }

    public void SetDef(float newDef)
    {
        def = newDef;
    }

    public float GetDef()
    {
        return def;
    }

    public void SetMagicAttk(float newMagic)
    {
        magicAttk = newMagic;
    }

    public float GetMagicAttk()
    {
        return magicAttk;
    }

    public void SetMagicDef(float newMagic)
    {
        magicDef = newMagic;
    }

    public float GetMagicDef()
    {
        return magicDef;
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
            SetDownName("Random Buff");
            SetRightName("Combo Attk");
        }
        else
        {
            SetUpName("Magic Shield");
            SetLeftName("Guard");
            SetDownName("Random Buff");
            SetRightName("Counter");
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

    public void SetTurnDamage(float formOfAttack, float formOfDefense)
    {
        if(formOfDefense == -2)
        {
            
            formOfAttack = formOfAttack * 2f; //This doubles the attack
            formOfDefense = 0;
            turndamage = formOfAttack - formOfDefense;
            if(turndamage < 0)
            {
                turndamage = 0;
            }
        }
        else if(formOfDefense == -1)
        {
            formOfAttack = formOfAttack * 1.5f;
            formOfDefense = 0;
            turndamage = formOfAttack - formOfDefense;
            if (turndamage < 0)
            {
                turndamage = 0;
            }
        }
        else
        {
            formOfAttack = formOfAttack * 1.5f;
            turndamage = formOfAttack - formOfDefense;
            if (turndamage < 0)
            {
                turndamage = 0;
            }
        }
    }

    public float GetTurnDamage()
    {
        return turndamage;
    }

    public void TakeDamage(float damage)
    {
        hp = hp - damage;
    }

    public void SetARandomStatBuff(float buff)
    {
        numToDetermineStatBuff = Random.Range(0, 4);

        if (numToDetermineStatBuff == 0)
            BuffAttk(buff);
        else if (numToDetermineStatBuff == 1)
            BuffDef(buff);
        else if (numToDetermineStatBuff == 2)
            BuffMagicAttk(buff);
        else if (numToDetermineStatBuff == 3)
            BuffMagicDef(buff);
        else
            print("Error did not buff one of the Stats possible");
    }

    public void BuffDef(float buff)
    {
        def = def + buff;
    }

    public void BuffAttk(float buff)
    {
        attk = attk + buff;
    }

    public void BuffMagicDef(float buff)
    {
        magicDef = magicDef + buff;
    }

    public void BuffMagicAttk(float buff)
    {
        magicAttk = magicAttk + buff;
    }

    public int GetNumToDetermineStatBuff()
    {
        return numToDetermineStatBuff;
    }
}
