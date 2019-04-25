using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour 
{
    private string itemName;
    private string itemDescription;

	
	public string ItemName
    {
        get
        {
            return itemName;
        }
        set
        {
            itemName = value;
        }
    }

    public string ItemDescription
    {
        get
        {
            return itemDescription;
        }
        set
        {
            itemDescription = value;
        }
    }

}
