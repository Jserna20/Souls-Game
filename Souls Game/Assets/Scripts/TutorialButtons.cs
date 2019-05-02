using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialButtons : MonoBehaviour {

    //change this variable depending on steps are made
    public static int ALLTUTORIALSTEPS = 17;
    //are static so can be called and checked anywhere;
    public static int stepInTutorial = 1;

	private void Update()
	{
        if (stepInTutorial == ALLTUTORIALSTEPS)
        {
            Invoke("StartGame", 2f);
        }
	}

	public void NextStep()
    {
        stepInTutorial++;
    }

    public void PrevStep()
    {
        stepInTutorial--;
        if(stepInTutorial < 1)
        {
            stepInTutorial = 1;
        }
    }

    public void SkipTutorial()
    {
        stepInTutorial = ALLTUTORIALSTEPS;
    }

    void StartGame()
    {
        PlayerStats.InBattle = false;
        PlayerStats.InBossBattle = false;
        SceneManager.LoadScene(6);
    }
}
