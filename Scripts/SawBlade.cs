using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SawBlade : MonoBehaviour {

    public int speed = 30;
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime, Space.World);
        
	}
    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.tag == "Player")
        {
            c.GetComponent<Player>().DamagePlayer(100);
                

            Debug.Log("Mama i killed the man");
        }
    }
}
