using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsInWorld : MonoBehaviour 
{
    public string name1 = "Adam Apple";
    public string name2 = "Milk";
    public string name3 = "Cloak";
    public string name4 = "Tome of Offense";
    public string name5 = "Tome of Defense";

    public string description1 = "Heals 2 HP.";
    public string description2 = "Temporarily increases Attack by 1.";
    public string description3 = "Temporarily increases Defense by 1.";
    public string description4 = "Temporarily increases Magic Attk by 1.";
    public string description5 = "Temporarily increases Magic Def by 1.";

    public Item AnItem;
    public Item[] itemInOrb = new Item[5];

	// Use this for initialization
	void Awake () 
    {
        for (int i = 0; i < itemInOrb.Length; i++)
        {
            switch (i)
            {
                case 0:
                    itemInOrb[i].ItemName = name1;
                    itemInOrb[i].ItemDescription = description1;
                    break;
                case 1:
                    itemInOrb[i].ItemName = name2;
                    itemInOrb[i].ItemDescription = description2;
                    break;
                case 2:
                    itemInOrb[i].ItemName = name3;
                    itemInOrb[i].ItemDescription = description3;
                    break;
                case 3:
                    itemInOrb[i].ItemName = name4;
                    itemInOrb[i].ItemDescription = description4;
                    break;
                case 4:
                    itemInOrb[i].ItemName = name5;
                    itemInOrb[i].ItemDescription = description5;
                    break;
            }
        }
	}
	
    public Item GiveRandomItem()
    {
        int i = Random.Range(0, 5);
        return itemInOrb[i];
    }
	// Update is called once per frame
	void Update () {
		
	}
}
