using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public static GameMaster gm;
    public Transform playerPrefab;
    public Transform spawnPoint;


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
       /* GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject go in gos)
            Destroy(go);*/
        gm.RespawnPlayer();
        Destroy(player.gameObject);

    }

    public void RespawnPlayer()
    {
        //Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("Spawn point :)");

        Transform player = (Transform)Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        CameraFollow cameraFolow = Camera.main.GetComponent<CameraFollow>();
        cameraFolow.target = player;
    }
    


}
