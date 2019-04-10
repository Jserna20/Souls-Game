using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefManager : MonoBehaviour 
{
    public static PlayerPrefManager PrefManager
    {
        get;
        set;
    }

    public float hpS;
    public float maxHPS;
    public float attkBaseS;
    public float defBaseS;
    public float magicAttkBaseS;
    public float magicDefBaseS;
    public float magicAttkS;
    public float magicDefS;
    public float attkS;
    public float defS;
    public int expS;
    public int maxEXPS;
    public int lvlS;

	// Use this for initialization
	void Awake () 
    {
        PrefManager = this;
        PlayerStats.SetStats();
        hpS = PlayerStats.HP;
        maxHPS = PlayerStats.MaxHP;
        attkBaseS = PlayerStats.AttackBase;
        defBaseS = PlayerStats.DefenseBase;
        magicAttkBaseS = PlayerStats.MagicAttkBase;
        magicDefBaseS = PlayerStats.MagicDefBase;
        attkS = PlayerStats.Attk;
        defS = PlayerStats.Def;
        magicAttkS = PlayerStats.MagicAttk;
        magicDefS = PlayerStats.MagicDef;
        expS = PlayerStats.EXP;
        maxEXPS = PlayerStats.MaxEXP;
        lvlS = PlayerStats.LVL;

            PlayerPrefs.SetFloat("hpS", hpS);
            PlayerPrefs.SetFloat("MaxHP", maxHPS);
            PlayerPrefs.SetFloat("AttkBase", attkBaseS);
            PlayerPrefs.SetFloat("DefBase", defBaseS);
            PlayerPrefs.SetFloat("MagAttkBase", magicAttkBaseS);
            PlayerPrefs.SetFloat("MagDefBase", magicDefBaseS);
            PlayerPrefs.SetFloat("attkS", attkS);
            PlayerPrefs.SetFloat("defS", defS);
            PlayerPrefs.SetFloat("MagAttk", magicAttkS);
            PlayerPrefs.SetFloat("MagDef", magicDefS);
            PlayerPrefs.SetInt("expS", expS);
            PlayerPrefs.SetInt("MaxExp", maxEXPS);
            PlayerPrefs.SetInt("lvlS", lvlS);

	}

	public void Save()
    {
        PlayerPrefs.Save();
    }

    public void SetHPValue(float value)
    {
        hpS = value;
        PlayerPrefs.SetFloat("hpS", hpS);
    }

    public void SetMaxHPValue(float value)
    {
        maxHPS = value;
        PlayerPrefs.SetFloat("MaxHP", maxHPS);
    }

    public void SetAttkValue(float value)
    {
        attkS = value;
        PlayerPrefs.SetFloat("attkS", attkS);
    }

    public void SetAttkBaseValue(float value)
    {
        attkBaseS = value;
        PlayerPrefs.SetFloat("AttkBase", attkBaseS);
    }

    public void SetDefValue(float value)
    {
        defS = value;
        PlayerPrefs.SetFloat("defS", defS);
    }

    public void SetDefBaseValue(float value)
    {
        defBaseS = value;
        PlayerPrefs.SetFloat("DefBase", defBaseS);
    }

    public void SetMagAttkValue(float value)
    {
        magicAttkS = value;
        PlayerPrefs.SetFloat("MagAttk", magicAttkS);
    }

    public void SetMagAttkBaseValue(float value)
    {
        magicAttkBaseS = value;
        PlayerPrefs.SetFloat("MagAttkBase", hpS);
    }

    public void SetMagDefValue(float value)
    {
        magicDefS = value;
        PlayerPrefs.SetFloat("MagDef", magicDefS);
    }

    public void SetMagDefBaseValue(float value)
    {
        magicDefBaseS = value;
        PlayerPrefs.SetFloat("MagDefBase", magicDefBaseS);
    }

    public void SetAllStats(float newHP, float newMaxHP, float newAttk, float newAttkBase, float newDef, float newDefBase, float newMagAttk, float newMagAttkBase, float newMagDef, float newMagDefBase)
    {
        SetHPValue(newHP);
        SetMaxHPValue(newMaxHP);
        SetAttkValue(newAttk);
        SetAttkBaseValue(newAttkBase);
        SetDefValue(newDef);
        SetDefBaseValue(newDefBase);
        SetMagAttkValue(newMagAttk);
        SetAttkBaseValue(newMagAttkBase);
        SetMagDefValue(newMagDef);
        SetMagDefBaseValue(newMagDefBase);
    }

    public float GetHPValue()
    {
        return PlayerPrefs.GetFloat("hpS");
    }

    public float GetMaxHPValue()
    {
        return PlayerPrefs.GetFloat("MaxHP");
    }

    public float GetAttkValue()
    {
        return PlayerPrefs.GetFloat("attkS");
    }

    public float GetAttkBaseValue()
    {
        return PlayerPrefs.GetFloat("AttkBase");
    }

    public float GetDefValue()
    {
        return PlayerPrefs.GetFloat("defS");
    }

    public float GetDefBaseValue()
    {
        return PlayerPrefs.GetFloat("DefBase");
    }

    public float GetMagAttkValue()
    {
        return PlayerPrefs.GetFloat("MagAttk");
    }

    public float GetMagAttkBaseValue()
    {
        return PlayerPrefs.GetFloat("MagAttkBase");
    }

    public float GetMagDefValue()
    {
        return PlayerPrefs.GetFloat("MagDef");
    }

    public float GetMagDefBaseValue()
    {
        return PlayerPrefs.GetFloat("MagDefBase");
    }

    public int GetEXP()
    {
        return PlayerPrefs.GetInt("expS");
    }

    public int GetMaxExp()
    {
        return PlayerPrefs.GetInt("MaxExp");
    }
    public int GetLVL()
    {
        return PlayerPrefs.GetInt("lvlS");
    }

    public void GetAllStats()
    {
        GetHPValue();
        GetMaxHPValue();
        GetAttkValue();
        GetAttkBaseValue();
        GetDefValue();
        GetDefBaseValue();
        GetMagAttkValue();
        GetAttkBaseValue();
        GetMagDefValue();
        GetMagDefBaseValue();
        GetEXP();
        GetMaxExp();
        GetLVL();
    }

}

/*
 * if(PlayerPrefs.HasKey("hpS"))
        {
            PlayerPrefs.GetFloat("hpS");
            PlayerPrefs.GetFloat("MaxHP");
            PlayerPrefs.GetFloat("AttkBase");
            PlayerPrefs.GetFloat("DefBase");
            PlayerPrefs.GetFloat("MagAttkBase");
            PlayerPrefs.GetFloat("MagDefBase");
            PlayerPrefs.GetFloat("attkS");
            PlayerPrefs.GetFloat("defS");
            PlayerPrefs.GetFloat("MagAttk");
            PlayerPrefs.GetFloat("MagDef");
            PlayerPrefs.GetInt("expS");
            PlayerPrefs.GetInt("MaxExp");
            PlayerPrefs.GetInt("lvlS");
        }
        else
        {
        
        }
        */
