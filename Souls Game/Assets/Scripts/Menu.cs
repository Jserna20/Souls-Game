using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour 
{
    //[Header("Set In Inspector")]
    //public GameObject canvasPF;
    /*
     * public GameObject mapHaloPF;
    public GameObject actionHaloPF;
    public GameObject itemsHaloPF;
    public GameObject weaponsHaloPF;
    public GameObject shieldHaloPF;
    public GameObject statsHaloPF;
     */

    [Header("Set Dynamically")]
    public GameObject mapHalo;
    public GameObject actionHalo;
    public GameObject itemsHalo;
    public GameObject weaponsHalo;
    public GameObject shieldHalo;
    public GameObject statsHalo;
    public GameObject previousSelectedHalo;
    public GameObject canvas;
    public GameObject mapButton;
    public GameObject actionButton;
    public GameObject itemsButton;
    public GameObject weaponsButton;
    public GameObject shieldsButton;
    public GameObject statsButton;
    public static bool inBattle;
    public bool onMapB;
    public bool onActionB;
    public bool onItemsB;
    public bool onWeaponsB;
    public bool onShieldsB;
    public bool onStatsB;
    public static bool inMenuMode;
    public int layerCursor;


	// Use this for initialization
	void Awake () 
    {
        mapHalo = GameObject.Find("MapHaloB");
        actionHalo = GameObject.Find("ActionHaloB");
        itemsHalo = GameObject.Find("ItemsHaloB");
        weaponsHalo = GameObject.Find("WeaponsHaloB");
        shieldHalo = GameObject.Find("ShieldsHaloB");
        statsHalo = GameObject.Find("StatsHaloB");
        canvas = GameObject.Find("Canvas");

        inMenuMode = false;
        mapHalo.SetActive(false);
        actionHalo.SetActive(false);
        itemsHalo.SetActive(false);
        weaponsHalo.SetActive(false);
        shieldHalo.SetActive(false);
        statsHalo.SetActive(false);
        canvas.SetActive(false);
        layerCursor = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(!inBattle)
        {
            SwitchingModes();
            if (inMenuMode)
            {
                canvas.SetActive(true);
                CheckForInput();
                switch (layerCursor)
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

    public void SwitchingModes()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            inMenuMode = true;
        } 
        
        if(Input.GetKeyDown(KeyCode.X))
        {
            inMenuMode = false;
            ResetButtonQueue();
        }


    }

    public bool GetModeInOW()
    {
        return inMenuMode;
    }
    public void ResetButtonQueue()
    {
        onMapB = false;
        onActionB = false;
        onItemsB = false;
        onWeaponsB = false;
        onShieldsB = false;
        onStatsB = false;
        mapHalo.SetActive(false);
        actionHalo.SetActive(false);
        itemsHalo.SetActive(false);
        weaponsHalo.SetActive(false);
        shieldHalo.SetActive(false);
        statsHalo.SetActive(false);
        canvas.SetActive(false);

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
