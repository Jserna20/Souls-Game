﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour 
{
    [Header("Set In Inspector")]
    public GameObject mapHaloPF;
    public GameObject actionHaloPF;
    public GameObject itemsHaloPF;
    public GameObject weaponsHaloPF;
    public GameObject shieldHaloPF;
    public GameObject statsHaloPF;

    [Header("Set Dynamically")]
    public GameObject mapHalo;
    public GameObject actionHalo;
    public GameObject itemsHalo;
    public GameObject weaponsHalo;
    public GameObject shieldHalo;
    public GameObject statsHalo;
    public GameObject previousSelectedHalo;
    public bool onMapB;
    public bool onActionB;
    public bool onItemsB;
    public bool onWeaponsB;
    public bool onShieldsB;
    public bool onStatsB;
    public int layerCursor;


	// Use this for initialization
	void Awake () 
    {
        mapHalo = Instantiate(mapHaloPF) as GameObject;
        actionHalo = Instantiate(actionHaloPF) as GameObject;
        itemsHalo = Instantiate(itemsHaloPF) as GameObject;
        weaponsHalo = Instantiate(weaponsHaloPF) as GameObject;
        shieldHalo = Instantiate(shieldHaloPF) as GameObject;
        statsHalo = Instantiate(statsHaloPF) as GameObject;

        mapHalo.SetActive(true);
        actionHalo.SetActive(false);
        itemsHalo.SetActive(false);
        weaponsHalo.SetActive(false);
        shieldHalo.SetActive(false);
        statsHalo.SetActive(false);

        layerCursor = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
        CheckForInput();
        switch(layerCursor)
        {
            case 0:
                if (previousSelectedHalo != null)
                {
                    previousSelectedHalo.SetActive(false);
                }

                mapHalo.SetActive(true);
                onMapB = true;
                MakeMapOnly();
                previousSelectedHalo = mapHalo;
                break;

            case 1:
                previousSelectedHalo.SetActive(false);
                actionHalo.SetActive(true);
                onActionB = true;
                MakeActionOnly();
                previousSelectedHalo = actionHalo;
                break;

            case 2:
                previousSelectedHalo.SetActive(false);
                itemsHalo.SetActive(true);
                onItemsB = true;
                MakeMapOnly();
                previousSelectedHalo = itemsHalo;
                break;

            case 3:
                previousSelectedHalo.SetActive(false);
                weaponsHalo.SetActive(true);
                onWeaponsB = true;
                MakeWeaponsOnly();
                previousSelectedHalo = weaponsHalo;
                break;

            case 4:
                previousSelectedHalo.SetActive(false);
                shieldHalo.SetActive(true);
                onShieldsB = true;
                MakeShieldsOnly();
                previousSelectedHalo = shieldHalo;
                break;

            case 5:
                previousSelectedHalo.SetActive(false);
                statsHalo.SetActive(true);
                onStatsB = true;
                MakeStatsOnly();
                previousSelectedHalo = statsHalo;
                break;
        }
	}

    public void CheckForInput()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            layerCursor++;
            if(layerCursor > 5 )
            {
                layerCursor = 5;
            }
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            layerCursor--;
            if(layerCursor < 0)
            {
                layerCursor = 0;
            }
        }

    }

    public void CheckForSelection()
    {
        
    }

    public void MakeMapOnly()
    {
            onActionB = false;
            onItemsB = false;
            onWeaponsB = false;
            onShieldsB = false;
            onStatsB = false;
    }

    public void MakeActionOnly()
    {
        onMapB = false;
        onItemsB = false;
        onWeaponsB = false;
        onShieldsB = false;
        onStatsB = false;
    }

    public void MakeItemsOnly()
    {
        onMapB = false;
        onActionB = false;
        onWeaponsB = false;
        onShieldsB = false;
        onStatsB = false;
    }

    public void MakeWeaponsOnly()
    {
        onMapB = false;
        onActionB = false;
        onItemsB = false;
        onShieldsB = false;
        onStatsB = false;
    }

    public void MakeShieldsOnly()
    {
        onMapB = false;
        onActionB = false;
        onItemsB = false;
        onWeaponsB = false;
        onStatsB = false;
    }

    public void MakeStatsOnly()
    {
        onMapB = false;
        onActionB = false;
        onItemsB = false;
        onWeaponsB = false;
        onShieldsB = false;
    }
}
