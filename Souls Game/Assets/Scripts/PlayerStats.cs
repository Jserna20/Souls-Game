using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    private static float hp;
    private static float maxHP;
    private static float attkBase;
    private static float defBase;
    private static float magicAttkBase;
    private static float magicDefBase;
    private static float magicAttk;
    private static float magicDef;
    private static float attk;
    private static float def;
    private static bool alive;
    private static bool defeated;
    private static bool inBattle;
    private static bool isAttacker;
    private static bool choosing;
    private static string upName;
    private static string leftName;
    private static string downName;
    private static string rightName;
    private static string playerName;
    private static float turndamage;
    private static int numToDetermineStatBuff;
    private static int exp;
    private static int maxEXP;
    private static int lvl;
    private static Vector3 playerPos;
    private static Vector3 camPos;

    public static void SetStats()
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
        playerName = "Spector ";
        alive = true;
        defeated = false;
    }

    public static void RestoreStats()
    {
        attk = attkBase;
        def = defBase;
        magicAttk = magicAttkBase;
        magicDef = magicDefBase;
    }

    public static void LevelUp()
    {
        exp = 0;
        maxEXP += 10;
        attkBase++;
        defBase++;
        magicAttkBase++;
        magicDefBase++;
        maxHP += 5;
        lvl++;
        RestoreStats();
        RestoreHP();

    }

    public static void RestoreHP()
    {
        hp = maxHP;
    }

    public static void SetNameBasedOnTurn()
    {
        if (IsAttacker)
        {
            UpName = "Magic Attk";
            LeftName = "Basic Attk";
            DownName = "Random Buff";
            RightName = "Combo Attk";
        }
        else
        {
            UpName = "Magic Shield";
            LeftName = "Guard";
            DownName = "Random Buff";
            RightName = "Counter";
        }

    }

    public static Vector3 PlayerPos
    {
        get
        {
            return playerPos;
        }
        set
        {
            playerPos = value;
        }
    }

    public static Vector3 CamPos
    {
        get
        {
            return camPos;
        }
        set
        {
            camPos = value;
        }
    }


    public static float HP
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }

    public static float MaxHP
    {
        get
        {
            return maxHP;
        }
        set
        {
            maxHP = value;
        }
    }

    public static float AttackBase
    {
        get
        {
            return attkBase;
        }
        set
        {
            attkBase = value;
        }
    }

    public static float DefenseBase
    {
        get
        {
            return defBase;
        }
        set
        {
            defBase = value;
        }
    }

    public static float MagicAttkBase
    {
        get
        {
            return magicAttkBase;
        }
        set
        {
            magicAttkBase = value;
        }
    }

    public static float MagicDefBase
    {
        get
        {
            return magicDefBase;
        }
        set
        {
            magicDefBase = value;
        }
    }

    public static float Attk
    {
        get
        {
            return attk;
        }
        set
        {
            attk = value;
        }
    }

    public static float Def
    {
        get
        {
            return def;
        }
        set
        {
            def = value;
        }
    }

    public static float MagicAttk
    {
        get
        {
            return magicAttk;
        }
        set
        {
            magicAttk = value;
        }
    }

    public static float MagicDef
    {
        get
        {
            return magicDef;
        }
        set
        {
            magicDef = value;
        }
    }

    public static bool Alive
    {
        get
        {
            return alive;
        }
        set
        {
            alive = value;
        }
    }

    public static bool InBattle
    {
        get
        {
            return inBattle;
        }
        set
        {
            inBattle = value;
        }
    }

    public static bool IsAttacker
    {
        get
        {
            return isAttacker;
        }
        set
        {
            isAttacker = value;
        }
    }

    public static bool Choosing
    {
        get
        {
            return choosing;
        }
        set
        {
            choosing = value;
        }
    }

    public static string UpName
    {
        get
        {
            return upName;
        }
        set
        {
            upName = value;
        }
    }

    public static string LeftName
    {
        get
        {
            return leftName;
        }
        set
        {
            leftName = value;
        }
    }

    public static string DownName
    {
        get
        {
            return downName;
        }
        set
        {
            downName = value;
        }
    }

    public static string RightName
    {
        get
        {
            return rightName;
        }
        set
        {
            rightName = value;
        }
    }

    public static string PlayerName
    {
        get
        {
            return playerName;
        }
        set
        {
            playerName = value;
        }
    }

    public static int EXP
    {
        get
        {
            return exp;
        }
        set
        {
            exp = value;
        }
    }

    public static int MaxEXP
    {
        get
        {
            return maxEXP;
        }
        set
        {
            maxEXP = value;
        }
    }

    public static int LVL
    {
        get
        {
            return lvl;
        }
        set
        {
            lvl = value;
        }
    }

    public static void SetTurnDamage(float formOfAttack, float formOfDefense)
    {
        if (formOfDefense == -2)
        {

            formOfAttack = formOfAttack * 2f; //This doubles the attack
            formOfDefense = 0;
            turndamage = formOfAttack - formOfDefense;
            if (turndamage < 0)
            {
                turndamage = 0;
            }
        }
        else if (formOfDefense == -1)
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

    public static float GetTurnDamage()
    {
        return turndamage;
    }

    public static void TakeDamage(float damage)
    {
        hp = hp - damage;
    }

    public static void SetARandomStatBuff(float buff)
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
        else //Repeats until hits 0,1,2, or 3
            SetARandomStatBuff(buff);
    }

    public static void BuffDef(float buff)
    {
        def = def + buff;
    }

    public static void BuffAttk(float buff)
    {
        attk = attk + buff;
    }

    public static void BuffMagicDef(float buff)
    {
        magicDef = magicDef + buff;
    }

    public static void BuffMagicAttk(float buff)
    {
        magicAttk = magicAttk + buff;
    }

    public static int GetNumToDetermineStatBuff()
    {
        return numToDetermineStatBuff;
    }
}

/*
 * public static float TurnDamage
    {
        get
        {
            return turndamage;
        }
        set
        {
            turndamage = value;
        }
    }
 */
