﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * 
 * MENU PAYZY W GRZE
 * 3 PRZYCISKI -> WZNOW , MENU I WYJDZ
 * ZATRZYMYWANIE CZASU PO URUCHOMIENU MANU
 */




public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenuUI;

    public static bool GameIsPause = false;     // INICJOWANIE FALSZEM PO TO ABY 
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Ja chce wyjsc!");
        Application.Quit();
    }

}
