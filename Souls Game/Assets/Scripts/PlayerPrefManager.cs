using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefManager : MonoBehaviour 
{
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
    public int exp;
    public int maxEXP;
    public int lvl;
    public Player PlayerStats;

	// Use this for initialization
	void Awake () 
    {
        
            PlayerStats.SetStats();
            hp = PlayerStats.GetHP();
            maxHP = PlayerStats.GetMaxHP();
            attkBase = PlayerStats.GetAttkBase();
            defBase = PlayerStats.GetDefBase();
            magicAttkBase = PlayerStats.GetMagicAttkBase();
            magicDefBase = PlayerStats.GetMagicDefBase();
            attk = PlayerStats.GetAttk();
            def = PlayerStats.GetDef();
            magicAttk = PlayerStats.GetMagicAttk();
            magicDef = PlayerStats.GetMagicDef();
            exp = PlayerStats.GetExp();
            maxEXP = PlayerStats.GetMaxEXP();
            lvl = PlayerStats.GetLvl();

            PlayerPrefs.SetFloat("HP", hp);
            PlayerPrefs.SetFloat("MaxHP", maxHP);
            PlayerPrefs.SetFloat("AttkBase", attkBase);
            PlayerPrefs.SetFloat("DefBase", defBase);
            PlayerPrefs.SetFloat("MagAttkBase", magicAttkBase);
            PlayerPrefs.SetFloat("MagDefBase", magicDefBase);
            PlayerPrefs.SetFloat("Attk", attk);
            PlayerPrefs.SetFloat("Def", def);
            PlayerPrefs.SetFloat("MagAttk", magicAttk);
            PlayerPrefs.SetFloat("MagDef", magicDef);
            PlayerPrefs.SetInt("EXP", exp);
            PlayerPrefs.SetInt("MaxExp", maxEXP);
            PlayerPrefs.SetInt("LVL", lvl);

	}

    public void GetSavedStats()
    {
        OnEnable();
    }

	public void OnEnable()
	{
        hp = PlayerPrefs.GetFloat("HP"); 
        maxHP = PlayerPrefs.GetFloat("MaxHP");
        attk = PlayerPrefs.GetFloat("Attk");
        attkBase = PlayerPrefs.GetFloat("AttkBase");
        def = PlayerPrefs.GetFloat("Def");
        defBase = PlayerPrefs.GetFloat("DefBase");
        magicAttk = PlayerPrefs.GetFloat("MagAttk");
        magicAttkBase = PlayerPrefs.GetFloat("MagAttkBase"); 
        magicDef = PlayerPrefs.GetFloat("MagDef"); 
        magicDefBase = PlayerPrefs.GetFloat("MagDefBase"); 
        exp = PlayerPrefs.GetInt("EXP"); 
        maxEXP = PlayerPrefs.GetInt("MaxExp"); 
        lvl = PlayerPrefs.GetInt("LVL");
	}

	public void Save()
    {
        PlayerPrefs.Save();
    }

    public void SetHPValue(float value)
    {
        hp = value;
        PlayerPrefs.SetFloat("HP", hp);
    }

    public void SetMaxHPValue(float value)
    {
        maxHP = value;
        PlayerPrefs.SetFloat("MaxHP", maxHP);
    }

    public void SetAttkValue(float value)
    {
        attk = value;
        PlayerPrefs.SetFloat("Attk", attk);
    }

    public void SetAttkBaseValue(float value)
    {
        attkBase = value;
        PlayerPrefs.SetFloat("AttkBase", attkBase);
    }

    public void SetDefValue(float value)
    {
        def = value;
        PlayerPrefs.SetFloat("Def", def);
    }

    public void SetDefBaseValue(float value)
    {
        defBase = value;
        PlayerPrefs.SetFloat("DefBase", defBase);
    }

    public void SetMagAttkValue(float value)
    {
        magicAttk = value;
        PlayerPrefs.SetFloat("MagAttk", magicAttk);
    }

    public void SetMagAttkBaseValue(float value)
    {
        magicAttkBase = value;
        PlayerPrefs.SetFloat("MagAttkBase", hp);
    }

    public void SetMagDefValue(float value)
    {
        magicDef = value;
        PlayerPrefs.SetFloat("MagDef", magicDef);
    }

    public void SetMagDefBaseValue(float value)
    {
        magicDefBase = value;
        PlayerPrefs.SetFloat("MagDefBase", magicDefBase);
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
        return PlayerPrefs.GetFloat("HP");
    }

    public float GetMaxHPValue()
    {
        return PlayerPrefs.GetFloat("MaxHP");
    }

    public float GetAttkValue()
    {
        return PlayerPrefs.GetFloat("Attk");
    }

    public float GetAttkBaseValue()
    {
        return PlayerPrefs.GetFloat("AttkBase");
    }

    public float GetDefValue()
    {
        return PlayerPrefs.GetFloat("Def");
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
        return PlayerPrefs.GetInt("EXP");
    }

    public int GetMaxExp()
    {
        return PlayerPrefs.GetInt("MaxExp");
    }
    public int GetLVL()
    {
        return PlayerPrefs.GetInt("LVL");
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
 * if(PlayerPrefs.HasKey("HP"))
        {
            PlayerPrefs.GetFloat("HP");
            PlayerPrefs.GetFloat("MaxHP");
            PlayerPrefs.GetFloat("AttkBase");
            PlayerPrefs.GetFloat("DefBase");
            PlayerPrefs.GetFloat("MagAttkBase");
            PlayerPrefs.GetFloat("MagDefBase");
            PlayerPrefs.GetFloat("Attk");
            PlayerPrefs.GetFloat("Def");
            PlayerPrefs.GetFloat("MagAttk");
            PlayerPrefs.GetFloat("MagDef");
            PlayerPrefs.GetInt("EXP");
            PlayerPrefs.GetInt("MaxExp");
            PlayerPrefs.GetInt("LVL");
        }
        else
        {
        
        }
        */
