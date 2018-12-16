using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * SPAWNOWANIE GRACZA
 * ZABIJANIE GRACZA
 * 
 */


/*TO DO TO DO TO DO TO DO TO DO TO DO TO DOOOOOOOOOOOOOO TO DO TO DO TO DO TO DO 
 * * PO WCZYTANIU POZIOMU GRA CZEKA NA PRZYCISK ALBO PO UPLYWNIE CZASU SAMA SIE ROZPOCZYNA 
 */
public class GameMaster : MonoBehaviour {

    public static GameMaster gm;
    public Transform playerPrefab;
    public Transform spawnPoint;
    public GameObject completeLevelUI;
    public Score score;

    void Start()
    { 

        RespawnPlayer();

        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }

    public static void KillPlayer(Player player)
    {
        gm.RespawnPlayer();
        Destroy(player.gameObject);

    }

    public void RespawnPlayer()
    {
        Debug.Log("Spawn point :)");

        Transform player = (Transform)Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        CameraFollow cameraFolow = Camera.main.GetComponent<CameraFollow>();
        cameraFolow.target = player;
    }
    
    public void CompleteLevel()
    {
        
        score.StopTimer(); 
        completeLevelUI.SetActive(true);
        Time.timeScale = 0f;
    }

}
