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
    void OnTriggerEnter(BoxCollider2D collider)
    {
        GameObject otherObj = collider.gameObject;
        Debug.Log("Triggered with: " + otherObj);
    }
}
