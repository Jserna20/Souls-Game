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
    public GameObject slot0;
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;
    public GameObject slot0Halo;
    public GameObject slot1Halo;
    public GameObject slot2Halo;
    public GameObject slot3Halo;
    public GameObject slot4Halo;
    public GameObject statsBar;
    public static bool inBattle;
    public bool onItemsB;
    public bool onWeaponsB;
    public bool onShieldsB;
    public bool onStatsB;
    public bool onslot0;
    public bool onslot1;
    public bool onslot2;
    public bool onslot3;
    public bool onslot4;
    public bool viewingStats;
    public static bool inMenuMode;
    public static bool inSubMode;
    public static int layerCursor;
    public static int subLayerCursor;


    // Use this for initialization
    void Awake()
    {
        itemsHalo = GameObject.Find("ItemsHaloB");
        weaponsHalo = GameObject.Find("WeaponsHaloB");
        shieldHalo = GameObject.Find("ShieldsHaloB");
        statsHalo = GameObject.Find("StatsHaloB");
        slot0 = GameObject.Find("Slot0");
        slot1 = GameObject.Find("Slot1");
        slot2 = GameObject.Find("Slot2");
        slot3 = GameObject.Find("Slot3");
        slot4 = GameObject.Find("Slot4");
        slot0Halo = GameObject.Find("Slot0Halo");
        slot1Halo = GameObject.Find("Slot1Halo");
        slot2Halo = GameObject.Find("Slot2Halo");
        slot3Halo = GameObject.Find("Slot3Halo");
        slot4Halo = GameObject.Find("Slot4Halo");
        statsBar = GameObject.Find("StatsBar");

        canvas = GameObject.Find("Canvas");

        inMenuMode = false;
        inSubMode = false;
        itemsHalo.SetActive(false);
        weaponsHalo.SetActive(false);
        shieldHalo.SetActive(false);
        statsHalo.SetActive(false);
        canvas.SetActive(false);
        slot0.SetActive(false);
        slot1.SetActive(false);
        slot2.SetActive(false);
        slot3.SetActive(false);
        slot4.SetActive(false);
        slot0Halo.SetActive(false);
        slot1Halo.SetActive(false);
        slot2Halo.SetActive(false);
        slot3Halo.SetActive(false);
        slot4Halo.SetActive(false);
        statsBar.SetActive(false);
        layerCursor = 0;
        subLayerCursor = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerStats.InBattle)
        {
            SwitchingModes();
            //LTrigger();
            if (inMenuMode)
            {
                canvas.SetActive(true);
                CheckForInput();
                if (!inSubMode)
                {
                    switch (layerCursor)
                    {
                        case 0:
                            if (previousSelectedHalo != null)
                            {
                                previousSelectedHalo.SetActive(false);
                            }
                            itemsHalo.SetActive(true);
                            onItemsB = true;
                            MakeItemsOnly();
                            previousSelectedHalo = itemsHalo;
                            break;
                        /*mapHalo.SetActive(true);
                        onMapB = true;
                        MakeMapOnly();
                        previousSelectedHalo = mapHalo;
                        break;*/

                        case 1:
                            previousSelectedHalo.SetActive(false);
                            weaponsHalo.SetActive(true);
                            onWeaponsB = true;
                            MakeWeaponsOnly();
                            previousSelectedHalo = weaponsHalo;
                            break;
                        /*previousSelectedHalo.SetActive(false);
                        actionHalo.SetActive(true);
                        onActionB = true;
                        MakeActionOnly();
                        previousSelectedHalo = actionHalo;
                        break;*/

                        case 2:
                            previousSelectedHalo.SetActive(false);
                            shieldHalo.SetActive(true);
                            onShieldsB = true;
                            MakeShieldsOnly();
                            previousSelectedHalo = shieldHalo;
                            break;
                        /*previousSelectedHalo.SetActive(false);
                        itemsHalo.SetActive(true);
                        onItemsB = true;
                        MakeMapOnly();
                        previousSelectedHalo = itemsHalo;
                        break;*/

                        case 3:
                            previousSelectedHalo.SetActive(false);
                            statsHalo.SetActive(true);
                            onStatsB = true;
                            MakeStatsOnly();
                            previousSelectedHalo = statsHalo;
                            break;
                            /*
                            previousSelectedHalo.SetActive(false);
                            weaponsHalo.SetActive(true);
                            onWeaponsB = true;
                            MakeWeaponsOnly();
                            previousSelectedHalo = weaponsHalo;
                            break;*/
                    }
                }

                if (inSubMode)
                {
                    ResetButtonQueue();
                    SeeAllSubItems();
                    switch (subLayerCursor)
                    {
                        case 0:
                            if (previousSelectedHalo != null)
                            {
                                previousSelectedHalo.SetActive(false);
                            }
                            slot0Halo.SetActive(true);
                            onslot0 = true;
                            MakeSlot0Only();
                            previousSelectedHalo = slot0Halo;
                            break;
                        /*mapHalo.SetActive(true);
                        onMapB = true;
                        MakeMapOnly();
                        previousSelectedHalo = mapHalo;
                        break;*/

                        case 1:
                            previousSelectedHalo.SetActive(false);
                            slot1Halo.SetActive(true);
                            onslot1 = true;
                            MakeSlot1Only();
                            previousSelectedHalo = slot1Halo;
                            break;
                        /*previousSelectedHalo.SetActive(false);
                        actionHalo.SetActive(true);
                        onActionB = true;
                        MakeActionOnly();
                        previousSelectedHalo = actionHalo;
                        break;*/

                        case 2:
                            previousSelectedHalo.SetActive(false);
                            slot2Halo.SetActive(true);
                            onslot2 = true;
                            MakeSlot2Only();
                            previousSelectedHalo = slot2Halo;
                            break;
                        /*previousSelectedHalo.SetActive(false);
                        itemsHalo.SetActive(true);
                        onItemsB = true;
                        MakeMapOnly();
                        previousSelectedHalo = itemsHalo;
                        break;*/

                        case 3:
                            previousSelectedHalo.SetActive(false);
                            slot3Halo.SetActive(true);
                            onslot3 = true;
                            MakeSlot3Only();
                            previousSelectedHalo = slot3Halo;
                            break;

                        case 4:
                            previousSelectedHalo.SetActive(false);
                            slot4Halo.SetActive(true);
                            onslot4 = true;
                            MakeSlot4Only();
                            previousSelectedHalo = slot4Halo;
                            break;
                    }
                }

            }

        }
    }

    public void CheckForInput()
    {
        if (!inSubMode)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                layerCursor++;
                if (layerCursor > 3)
                {
                    layerCursor = 3;
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                layerCursor--;
                if (layerCursor < 0)
                {
                    layerCursor = 0;
                }
            }

            if ((Input.GetKeyDown(KeyCode.A)) && onStatsB)
            {
                statsBar.SetActive(true);
                viewingStats = true;
            }
            else if (Input.GetKeyDown(KeyCode.A) && onItemsB)
            {
                inSubMode = true;
            }

            if (viewingStats && (Input.GetKeyDown(KeyCode.X)))
            {
                statsBar.SetActive(false);
                viewingStats = false;
            }

        }

        if (inSubMode)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                subLayerCursor++;
                if (subLayerCursor > 4)
                {
                    subLayerCursor = 4;
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                subLayerCursor--;
                if (subLayerCursor < 0)
                {
                    subLayerCursor = 0;
                }
            }

            if(Input.GetKeyDown(KeyCode.A) && onslot0)
            {
                if(PlayerStats.Slot0Counter > 0)
                {
                    PlayerStats.Slot0Counter--;
                    PlayerStats.HP += 2;
                }
            }
            else if (Input.GetKeyDown(KeyCode.A) && onslot1)
            {
                if (PlayerStats.Slot1Counter > 0)
                {
                    PlayerStats.Slot1Counter--;
                    PlayerStats.Attk += 1;
                }
            }
            else if (Input.GetKeyDown(KeyCode.A) && onslot2)
            {
                if (PlayerStats.Slot2Counter > 0)
                {
                    PlayerStats.Slot2Counter--;
                    PlayerStats.Def += 1;
                }
            }
            else if (Input.GetKeyDown(KeyCode.A) && onslot3)
            {
                if (PlayerStats.Slot3Counter > 0)
                {
                    PlayerStats.Slot3Counter--;
                    PlayerStats.MagicAttk += 1;
                }
            }
            else if (Input.GetKeyDown(KeyCode.A) && onslot4)
            {
                if (PlayerStats.Slot4Counter > 0)
                {
                    PlayerStats.Slot4Counter--;
                    PlayerStats.MagicDef += 1;
                }
            }


            if (Input.GetKeyDown(KeyCode.X))
            {
                HideAllSubItems();
                inSubMode = false;
            }
        }
    }


    public void SwitchingModes()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !inMenuMode)
        {
            inMenuMode = true;
        }
        else if ((Input.GetKeyDown(KeyCode.Z) || (Input.GetKeyDown(KeyCode.X) && !inSubMode && !viewingStats)) && inMenuMode)
        {
            inMenuMode = false;
            canvas.SetActive(false);
            ResetButtonQueue();
        }

    }


    public void SeeAllSubItems()
    {
        slot0.SetActive(true);
        slot1.SetActive(true);
        slot2.SetActive(true);
        slot3.SetActive(true);
        slot4.SetActive(true);
    }

    public void HideAllSubItems()
    {
        slot0.SetActive(false);
        slot1.SetActive(false);
        slot2.SetActive(false);
        slot3.SetActive(false);
        slot4.SetActive(false);
    }

    public bool GetModeInOW()
    {
        return inMenuMode;
    }


    public void ResetButtonQueue()
    {
        onShieldsB = false;
        onStatsB = false;
        onItemsB = false;
        onWeaponsB = false;
        itemsHalo.SetActive(false);
        weaponsHalo.SetActive(false);
        shieldHalo.SetActive(false);
        statsHalo.SetActive(false);
    }

    public void MakeSlot0Only()
    {
        onslot1 = false;
        onslot2 = false;
        onslot3 = false;
        onslot4 = false;
    }

    public void MakeSlot1Only()
    {
        onslot0 = false;
        onslot2 = false;
        onslot3 = false;
        onslot4 = false;
    }

    public void MakeSlot2Only()
    {
        onslot1 = false;
        onslot0 = false;
        onslot3 = false;
        onslot4 = false;
    }

    public void MakeSlot3Only()
    {
        onslot1 = false;
        onslot2 = false;
        onslot0 = false;
        onslot4 = false;
    }

    public void MakeSlot4Only()
    {
        onslot1 = false;
        onslot2 = false;
        onslot3 = false;
        onslot0 = false;
    }

    public void MakeItemsOnly()
    {
        onWeaponsB = false;
        onShieldsB = false;
        onStatsB = false;
    }

    public void MakeWeaponsOnly()
    {
        onItemsB = false;
        onShieldsB = false;
        onStatsB = false;
    }

    public void MakeShieldsOnly()
    {
        onItemsB = false;
        onWeaponsB = false;
        onStatsB = false;
    }

    public void MakeStatsOnly()
    {
        onItemsB = false;
        onWeaponsB = false;
        onShieldsB = false;
    }
}
