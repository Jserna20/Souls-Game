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
    public bool onMapB;
    public bool onActionB;
    public bool onItemsB;
    public bool onWeaponsB;
    public bool onShieldsB;
    public bool onStatsB;


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
        actionHalo.SetActive(true);
        itemsHalo.SetActive(true);
        weaponsHalo.SetActive(true);
        shieldHalo.SetActive(true);
        statsHalo.SetActive(true);

        onMapB = true;
        onActionB = false;
        onItemsB = false;
        onWeaponsB = false;
        onShieldsB = false;
        onStatsB = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}
}
