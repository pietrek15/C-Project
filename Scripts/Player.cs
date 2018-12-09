using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Controller2D))]   // teraz z posiomu Unity nie da sie usunac tego komponentu bo jest wymagany 
public class Player : MonoBehaviour {

    public float jumpHeight = 4;            // wysokosc skoku
    public float timeToJumpApex = .4f;      // czas w sek do osiągniecia szczytu
    float accelerationTimeAirbone = .2f;    // czas do osiagnieca max predkosci w locie
    float accelerationTimeGrounded = .1f;   // czas do osiagnieca max predkosci na ziemi
    public float moveSpeed = 10;

    public float wallSlideSpeedMax = 3;
    public float wallStickTime = .25f;
    float timeToWallUnstick;

    public int deathLine = -20;

    public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallLeap;

    float gravity;
    float jumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    Controller2D controller;

	//---------------------------------------------------------------------//
	void Start () {                                                 //dzieje sie to TYLKO RAZ
        controller = GetComponent<Controller2D>();

        gravity =- (2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);         // wyliczanie grawitacji
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        print("Gravity" + gravity + " Jump Velocity " + jumpVelocity);          // w konsoli printuje te wartosci
	}
	
	
    void Update()                                                               // dzieje sie co klatke
    {
        if(transform.position.y <= deathLine)
        {
            DamagePlayer(1000000);              
        }




        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        int wallDirX = (controller.collisions.left) ? -1 : 1;

        float targetVelocityX = input.x * moveSpeed;                                                                                                                            // powolne rozpoczecie ruchu
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirbone);

        bool wallSliding = false;
        if((controller.collisions.left || controller.collisions.right) && ! controller.collisions.below&& velocity.y< 0)
        {
            wallSliding = true;

            if (velocity.y < -wallSlideSpeedMax)
            {
                velocity.y = -wallSlideSpeedMax;
            }
            if(timeToWallUnstick< 0)
            {
                velocity.x = 0;
                velocityXSmoothing = 0;

                if(input.x != wallDirX && input.x !=0)
                {
                    timeToWallUnstick -= Time.deltaTime;
                }
                else
                {
                    timeToWallUnstick = wallStickTime;
                }
            }
            else
            {
                timeToWallUnstick = wallStickTime;
            }
        }

        if (controller.collisions.above || controller.collisions.below)         // skutek vertykalnej kolizji
        {
            velocity.y = 0;
        }

        
        //-------------------------------------------------------------------------------------------//
        if(Input.GetKeyDown(KeyCode.Space))                                      // !!!WAZNE wprzycisk odpowiedzialny za SKOK!!!
        {
            if (wallSliding)
            {
                if(wallDirX == input.x)
                {
                    velocity.x = -wallDirX * wallJumpClimb.x;
                    velocity.y = wallJumpClimb.y;
                }
                else if (input.x == 0)
                {
                    velocity.x = -wallDirX * wallJumpOff.x;
                    velocity.y = wallJumpOff.y;
                }
                else
                {
                    velocity.x = -wallDirX * wallLeap.x;
                    velocity.y = wallLeap.y;
                }
            }
            if (controller.collisions.below)
            {
                velocity.y = jumpVelocity;
            }     
        }

        velocity.y += gravity * Time.deltaTime;                          // sposob dzialania grawitacji
        controller.Move(velocity * Time.deltaTime);
    }

    //--------------------------------------------------------------
    [System.Serializable]
    public class PlayerStats
    {
        public int Health = 100;
    }

    public PlayerStats playerStats = new PlayerStats();

    public void DamagePlayer (int damage)
    {
        playerStats.Health -= damage;
        if (playerStats.Health <= 0)
        {
            GameMaster.KillPlayer(this);
            Debug.Log("Zabilem go!");
        }
    }

}
