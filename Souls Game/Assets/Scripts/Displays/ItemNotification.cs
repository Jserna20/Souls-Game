using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemNotification : MonoBehaviour 
{
    public static bool notifyMe;
    public bool delay;
    public GameObject needForCollecting;
    public PlayerMovement CollectedItem; 
	// Use this for initialization
	void Awake () 
    {
        needForCollecting = GameObject.Find("PlayerSprite");
        CollectedItem = needForCollecting.GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
    void Update()
    {
        if(notifyMe)
        {
            if(!delay)
            {
                Message();
            }

        }
        else
        {
            Text gt = this.GetComponent<Text>();
            gt.text = "";
        }
    }

    public void Message()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "You got " + PlayerMovement.nameOfItemCollected + ".";
        delay = true;
        StartCoroutine(LetMeRead());
    }

    public IEnumerator LetMeRead()
    {
        yield return new WaitForSeconds(.2f);
        notifyMe = false;
        delay = false;
    }
}
