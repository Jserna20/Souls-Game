using System.Collections;
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
    public int topLayerCursor;


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

        topLayerCursor = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
        CheckForInput();
        switch(topLayerCursor)
        {
            case 0:
                if (previousSelectedHalo != null)
                {
                    previousSelectedHalo.SetActive(false);
                }

                mapHalo.SetActive(true);
                previousSelectedHalo = mapHalo;
                break;

            case 1:
                previousSelectedHalo.SetActive(false);
                actionHalo.SetActive(true);
                previousSelectedHalo = actionHalo;
                break;

            case 2:
                previousSelectedHalo.SetActive(false);
                itemsHalo.SetActive(true);
                previousSelectedHalo = itemsHalo;
                break;

            case 3:
                previousSelectedHalo.SetActive(false);
                weaponsHalo.SetActive(true);
                previousSelectedHalo = weaponsHalo;
                break;

            case 4:
                previousSelectedHalo.SetActive(false);
                shieldHalo.SetActive(true);
                previousSelectedHalo = shieldHalo;
                break;

            case 5:
                previousSelectedHalo.SetActive(false);
                statsHalo.SetActive(true);
                previousSelectedHalo = statsHalo;
                break;
        }
	}

    public void CheckForInput()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            topLayerCursor++;
            if(topLayerCursor > 5 )
            {
                topLayerCursor = 5;
            }
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            topLayerCursor--;
            if(topLayerCursor < 0)
            {
                topLayerCursor = 0;
            }
        }

    }

}
