using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionInMenu : MonoBehaviour 
{

    Text description;
    private void Awake()
    {
        description = this.GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Menu.inMenuMode && !Menu.inSubMode)
        {
            switch (Menu.layerCursor)
            {
                case 0:
                    description.text = "Items that will enhance certain stats";
                    break;
                case 1:
                    description.text = "Not Available In Demo Version.";
                    break;
                case 2:
                    description.text = "Not Available In Demo Version.";
                    break;
                case 3:
                    description.text = "Check your stats here";
                    break;
                    
            }
        }
        else if(Menu.inMenuMode && Menu.inSubMode)
        {
            switch(Menu.subLayerCursor)
            {
                case 0:
                    description.text = PlayerStats.Description0;
                    break;
                case 1:
                    description.text = PlayerStats.Description1;
                    break;
                case 2:
                    description.text = PlayerStats.Description2;
                    break;
                case 3:
                    description.text = PlayerStats.Description3;
                    break;
                case 4:
                    description.text = PlayerStats.Description4;
                    break;
            }
        }
    }
}
