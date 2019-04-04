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

	// Use this for initialization
	void Awake () 
    {
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

    public void GetHPValue()
    {
        PlayerPrefs.GetFloat("HP");
    }

    public void GetMaxHPValue()
    {
        PlayerPrefs.GetFloat("MaxHP");
    }

    public void GetAttkValue()
    {
        PlayerPrefs.GetFloat("Attk");
    }

    public void GetAttkBaseValue()
    {
        PlayerPrefs.GetFloat("AttkBase");
    }

    public void GetDefValue()
    {
        PlayerPrefs.GetFloat("Def");
    }

    public void GetDefBaseValue()
    {
        PlayerPrefs.GetFloat("DefBase");
    }

    public void GetMagAttkValue()
    {
        PlayerPrefs.GetFloat("MagAttk");
    }

    public void GetMagAttkBaseValue()
    {
        PlayerPrefs.GetFloat("MagAttkBase");
    }

    public void GetMagDefValue()
    {
        PlayerPrefs.GetFloat("MagDef");
    }

    public void GetMagDefBaseValue()
    {
        PlayerPrefs.GetFloat("MagDefBase");
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
    }
}
