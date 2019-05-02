using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplainForStep : MonoBehaviour 
{
    Text explainText;
	private void Awake()
	{
        explainText = this.GetComponent<Text>();
	}
	// Update is called once per frame
	void Update()
    {
        //add more cases depending on number of steps
        //describe each step in the cases
        switch (TutorialButtons.stepInTutorial)
        {
            case 1:
                explainText = this.GetComponent<Text>();
                explainText.text = "In the OverWorld you can move using the arrow keys to move or WASD";
                break;

            case 2:
                explainText = this.GetComponent<Text>();
                explainText.text = "You can find blue rotating spheres. These are Item Orbs. You can collect them to recieve items.";
                break;
            case 3:
                explainText = this.GetComponent<Text>();
                explainText.text = "To open up your menu in the OverWorld press Z. To select/use press A. To go back press X. You can close your menu with Z or X.";
                break;
            case 4:
                explainText = this.GetComponent<Text>();
                explainText.text = "Enemies hide in wheat in the OverWorld. You can go through the wheat. There is a chance that an enemy will attack. This will start the battle phase.";
                break;
            case 5:
                explainText = this.GetComponent<Text>();
                explainText.text = "When you are in a battle phase. You can certain actions depending on whether you are in Attacker Mode or Defender Mode.";
                    break;
            case 6:
                explainText = this.GetComponent<Text>();
                explainText.text = "When you are in Attacker Mode (AM) you can the following actions: Basic Attk, Magic Attk, Random Buff, Combo Attk.";
                break;
            case 7:
                explainText = this.GetComponent<Text>();
                explainText.text = "Press A to perform a Basic Attack.\n" +
                    "It's a safe close range attack. Enemies can guard the attack to reduce its damage.";
                break;
            case 8:
                explainText = this.GetComponent<Text>();
                explainText.text = "Press W to perform a Magic Attack\n" +
                    "It's a safe long range attack. Enemies can use a magic shield to reduce its damage.";
                break;
            case 9:
                explainText = this.GetComponent<Text>();
                explainText.text = "Press S to perform a Random Buff\n" +
                    "Allows you to boost a single stat of yours (not HP).";
                break;
            case 10:
                explainText = this.GetComponent<Text>();
                explainText.text = "Press S to perform a Combo Attack\n" +
                    "A powerful all out attack that is vunerable to counters. If an enemy counters you they will hit you while you are attacking and they take no damage.";
                break;
            case 11:
                explainText = this.GetComponent<Text>();
                explainText.text = "When you are in Defender Mode (DM) you can the following actions: Guard, Magic Guard, Random Buff, Counter.";
                break;
            case 12:
                explainText = this.GetComponent<Text>();
                explainText.text = "Press W to use a Magic Shield\n" + 
                    "Allows you to redudce magic attk damage. Not other attacks";
                break;
            case 13:
                explainText = this.GetComponent<Text>();
                explainText.text = "Press A to perform a Guard\n" + 
                    "Allows you to redudce basic attk damage. Not other attacks";
                break;
            case 14:
                explainText = this.GetComponent<Text>();
                explainText.text = "Press S to perform a Random Buff\n" +
                    "Allows you to boost a single stat of yours (not HP).";
                break;
            case 15:
                explainText = this.GetComponent<Text>();
                explainText.text = "Press D to perform a Counter.\n" +
                    "Allows you to counter attack if enemy uses a combo attk. Fails otherwise";
                break;
            case 16:
                explainText = this.GetComponent<Text>();
                explainText.text = "At the end of the World there will be a boss fight.";
                break;
            case 17:
                explainText = this.GetComponent<Text>();
                explainText.text = "Now sending you to the Farm. Good Luck.";
                break;
        }
    }
}
