using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerClass : MonoBehaviour 
{
    public static ManagerClass Manager;
    public bool gameStart;

	// Use this for initialization
	void Awake () 
    {
        if(!gameStart)
        {
            Manager = this;

            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

            gameStart = true;
        }
	}
	
    public void UnloadScene(int scene)
    {
        StartCoroutine(Unload(scene));
    }

    IEnumerator Unload(int scene)
    {
        yield return null;

        SceneManager.UnloadScene(scene);
    }
}
