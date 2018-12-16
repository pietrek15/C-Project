using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * ???
 * CIEZKO TEGO NEI ZROZUMIEC :) 
 * 
 * */


public class MainMenu : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Ja chce wyjsc!"); // W EDYTORZE NIE DA SIE WYJSC WIEC ZEBY BYLO WIDAC ZE TO DZIALA TO WYPISUJE KOMUNITKAT W KONSOLI
        Application.Quit();
    }

}
