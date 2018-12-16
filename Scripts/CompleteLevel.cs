using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour {

    public GameMaster gameMaster;
    

    void OnTriggerEnter2D()
    {
        gameMaster.CompleteLevel();
    }
}
