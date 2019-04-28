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
                explainText.text = "Explaination 1 text";
                break;

            case 2:
                explainText = this.GetComponent<Text>();
                explainText.text = "Explaination 2 text";
                break;

            case 3:
                explainText = this.GetComponent<Text>();
                explainText.text = "Explaination 3 text";
                break;
        }
    }
}
