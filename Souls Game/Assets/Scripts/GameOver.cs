﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void ReloadGame()
    {
        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        PlayerStats.PlayerPos = Vector3.zero;
        PlayerStats.CamPos = Vector3.zero;
        PlayerStats.RestoreHP();
        PlayerStats.RestoreStats();
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        ManagerClass.Manager.UnloadScene(3);
    }
}