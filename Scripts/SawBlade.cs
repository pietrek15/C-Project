/*
 * JAK SZYBKO OBRACA SIE TARCZA
 * JAKIE OBRAZENIA ZADAJE
 * WYKRYWANIE KOLIZJI MIEDZY OSTREZEM A GRACZEM
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SawBlade : MonoBehaviour {

    public int speed = 30;                  // PREDKOSC OBRACANIA SIE TARCZY
	
	void Update ()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime, Space.World);    // W OKOL KTOREJ OSI MA SDIE OBRACAC 
        
	}
    void OnTriggerEnter2D(Collider2D c)                                             // WYWOLUJE SIE PRZY ZETKNIECOIU
    {
        if(c.tag == "Player")
        {
            c.GetComponent<Player>().DamagePlayer(100);                             // WYKORZYSTANIE METODY Z KLASY PLAYER
                

            Debug.Log("Mama i killed the man");
        }
    }
}
